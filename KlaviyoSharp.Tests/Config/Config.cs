using Microsoft.Extensions.Configuration;

namespace KlaviyoSharp.Tests;
/// <summary>
/// Configuration parameters for the KlaviyoSharp Tests
/// </summary>
internal static class Config
{
    /// <summary>
    /// Configuraiton loaded from appsettings.local.json
    /// </summary>
    private static IConfiguration _config = LoadConfig();

    /// <summary>
    /// Loads config from appsettings.local.json
    /// </summary>
    /// <returns></returns>
    private static IConfiguration LoadConfig()
    {
        return new ConfigurationBuilder()
            .AddJsonFile("appsettings.local.json", true)
            .Build();
    }

    /// <summary>
    /// Your 6-character public key, sometimes referred to as a site ID, is a short alphanumeric string that serves as the unique identifier for your Klaviyo account.
    /// Public keys cannot be used to access secure data in your account and are safe to share. Use your public key when you need to track people and events in client-side JavaScript code.
    /// </summary>
    public static string CompanyId => Get("CompanyId");
    /// <summary>
    /// Private keys will have the prefix pk_ followed by a longer alphanumeric string. Klaviyo allows you to generate multiple private keys for your applications.
    /// Your private API keys can be used to read and write data to your Klaviyo account and should never be exposed in client-side code or made accessible from public repositories.
    /// </summary>
    public static string ApiKey => Get("ApiKey");
    /// <summary>
    /// Loads config value from Environment Variables or IConfiguration
    /// </summary>
    /// <param name="key"></param>
    private static string Get(string key)
    {
        string? env = Environment.GetEnvironmentVariable($"KLAVIYO_{key.ToUpper()}");
        _config ??= LoadConfig();
        return env ?? _config.GetSection("Klaviyo").GetSection(key).Value ?? throw new Exception($"Missing {key} in appsettings.local.json");
    }

}