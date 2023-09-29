using Autofac;
using ZPets.Infra;
using ZPets.Domain;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace ZPets.Api
{
    public class Startup
    {
        private IHostEnvironment CurrentEnvironment;

        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            this.Configuration = configuration;
            this.CurrentEnvironment = env;
        }

        public IConfiguration Configuration { get; private set; }
        public ILifetimeScope AutofacContainer { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDatabaseContext();
            services.AddInfraestructureModule();
            services.AddDomainModule();
        }

        public void Configure(IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseResponseCompression();

            app.UseApiVersioning();

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var groupName in provider.ApiVersionDescriptions.Select(d => d.GroupName))
                {
                    options.SwaggerEndpoint($"../swagger/{groupName}/swagger.json", groupName);
                }
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<InfraestructureModule>();
            builder.RegisterModule<DomainModule>();
        }

        public void ConfigureProductionContainer(ContainerBuilder builder)
        {
            ConfigureContainer(builder);

            // Add only production things to ContainerBuilder
        }
    }
}