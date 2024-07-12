using MotoPlanck.Domain.Utils;

namespace MotoPlanck.WebApi.Extensions
{
    public static class AppSettingsExtensions //TODO
    {
        public static JwtSettings JwtSettings { get; set; }

        static AppSettingsExtensions()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            JwtSettings = configuration.GetSection("Jwt").Get<JwtSettings>() ?? new JwtSettings();
        }
    }
}
