using Autofac;
using ZPets.Infra;
using ZPets.Domain;
using Microsoft.AspNetCore.Mvc;
using ZPets.Infra.Models;
using ZPets.Api.Configuration;

namespace ZPets.Api
{
    public class Startup
    {
        public ILifetimeScope AutofacContainer { get; private set; }

        private readonly IConfiguration _configuration;
        private readonly IHostEnvironment _currentEnvironment;

        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            _configuration = configuration;
            _currentEnvironment = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            AppSettings settings = new AppSettings();
            _configuration.Bind(settings);
            services.AddSingleton(settings);

            services.AddMvcCore()
                .AddApiExplorer();

            services.AddAuthentication(settings);
            services.AddControllers(_currentEnvironment);
            services.AddEndpointsApiExplorer();
            services.AddSwagger();

            services.AddApiVersioning(p =>
            {
                p.DefaultApiVersion = new ApiVersion(1, 0);
                p.ReportApiVersions = true;
                p.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddDatabaseContext(settings);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseApiVersioning();

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<InfraestructureModule>();
            builder.RegisterModule<DomainModule>();
            builder.RegisterModule<ApiModule>();
        }

        public void ConfigureProductionContainer(ContainerBuilder builder)
        {
            ConfigureContainer(builder);

            // Add only production things to ContainerBuilder
        }
    }
}