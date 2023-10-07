using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;
using ZPets.Infra.Data;
using ZPets.Infra.Models;
using ZPets.Infra.Swagger;

namespace ZPets.Infra
{
    public static class StartupSetup
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, AppSettings settings)
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.EnableDetailedErrors();
                options.UseSqlServer(settings.ConnectionStrings.Database);
            });

            return services;
        }

        public static IServiceCollection AddAuthentication(this IServiceCollection services, AppSettings settings)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.JwtSettings.Issuer,
                    ValidAudience = settings.JwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtSettings.Key)),
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });

            services.AddAuthorization();

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
