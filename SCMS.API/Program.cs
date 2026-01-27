using FluentValidation;
using FluentValidation.AspNetCore;
using SCMS.Domain.DTOs;
using SCMS.Application.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SCMS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SCMS.Application;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using SCMS.API.Middleware;
using Serilog;
using SCMS.Infrastructure.Services;
using SCMS.Application.BackgroundServices;

// 1. Cấu hình DateTime cho Postgres (Nên đặt ngay dòng đầu)
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// 2. Lấy chuỗi kết nối
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<CreateMenuItemDto>, CreateMenuItemDtoValidator>();

// 3. Cấu hình Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    // Fix lỗi warning null reference ở Jwt:Key bằng cách kiểm tra hoặc dùng !
    var jwtKey = builder.Configuration["Jwt:Key"] ?? throw new InvalidOperationException("Jwt:Key is missing in appsettings.json");

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

// 4. Đăng ký DB Context với PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// 5. Cấu hình CORS (Đã xóa biến thừa MyAllowSpecificOrigins)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMobileAndWeb",
        policy => policy
        // Thêm các domain hoặc IP của máy ảo Android (nếu cần thiết)
        // Lưu ý: Mobile App gọi API trực tiếp thường không bị chặn CORS, nhưng Web App thì có.
        .AllowAnyOrigin() 
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// 6. Đăng ký Services
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ReportService>();
builder.Services.AddScoped<IWalletService, WalletService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddHostedService<PendingOrderCancellationService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

// Sử dụng đúng tên Policy đã đặt ở trên
app.UseCors("AllowMobileAndWeb");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();