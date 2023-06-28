namespace KlaviyoSharp.Tests;

internal static class Config
{
    public static string CompanyId => Environment.GetEnvironmentVariable("KLAVIYO_COMPANY") ?? "";
    public static string ApiKey => Environment.GetEnvironmentVariable("KLAVIYO_API_KEY") ?? "";
}
