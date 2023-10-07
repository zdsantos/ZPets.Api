using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ZPets.Api.Configuration
{
    public static class ControllersConfiguration
    {
        public static IServiceCollection AddControllers(this IServiceCollection services, IHostEnvironment currentEnvironment)
        {
            services.AddControllers(options =>
            {
                options.OutputFormatters.RemoveType<Microsoft.AspNetCore.Mvc.Formatters.StringOutputFormatter>();
                options.OutputFormatters.RemoveType<Microsoft.AspNetCore.Mvc.Formatters.HttpNoContentOutputFormatter>();
            })
                .AddDataAnnotationsLocalization()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                    options.SerializerSettings.Converters.Add(new TrimmingConverter());
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());

#if DEBUG
                    options.SerializerSettings.Formatting = currentEnvironment.IsDevelopment() ? Formatting.Indented : Formatting.None;
#else
                    options.SerializerSettings.Formatting = Formatting.None;
#endif
                });

            return services;
        }

        private sealed class TrimmingConverter : JsonConverter
        {
            public override bool CanRead => true;
            public override bool CanWrite => false;

            public override bool CanConvert(Type objectType) => objectType == typeof(string);

            public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
            {
                return reader.Value != null ? Convert.ToString(reader.Value)!.Trim() : null;
            }

            public override void WriteJson(JsonWriter writer, object value,
                                           JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
    }
}
