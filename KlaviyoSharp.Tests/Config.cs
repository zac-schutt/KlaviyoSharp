namespace KlaviyoSharp.Tests;
/// <summary>
/// Configuration parameters for the KlaviyoSharp Tests
/// </summary>
internal static class Config
{
    private static Dictionary<string, string>? _keyFile;
    /// <summary>
    /// Your 6-character public key, sometimes referred to as a site ID, is a short alphanumeric string that serves as the unique identifier for your Klaviyo account.
    /// Public keys cannot be used to access secure data in your account and are safe to share. Use your public key when you need to track people and events in client-side JavaScript code.
    /// </summary>
    public static string CompanyId => Get("KLAVIYO_COMPANY");
    /// <summary>
    /// Private keys will have the prefix pk_ followed by a longer alphanumeric string. Klaviyo allows you to generate multiple private keys for your applications.
    /// Your private API keys can be used to read and write data to your Klaviyo account and should never be exposed in client-side code or made accessible from public repositories.
    /// </summary>
    public static string ApiKey => Get("KLAVIYO_API_KEY");
    /// <summary>
    /// Loads config from Environment Variable - or from file if not found.
    /// </summary>
    /// <param name="key"></param>
    private static string Get(string key)
    {
        string output = Environment.GetEnvironmentVariable(key) ?? string.Empty;
        if (string.IsNullOrEmpty(output))
        {
            _keyFile ??= LoadFromFile();
            output = _keyFile.ContainsKey(key) ? _keyFile[key] : string.Empty;
        }
        return output;
    }
    /// <summary>
    /// Loads config from file. Checks for a file called .env 3 levels above the current directory. Used for debugging.
    /// </summary>
    /// <returns></returns>
    private static Dictionary<string, string> LoadFromFile()
    {
        Dictionary<string, string> output = new();
        foreach (string x in File.ReadAllLines("../../../.env"))
        {
            string[] parts = x.Trim().Split('=');
            output.Add(parts[0], parts[1].Replace("\"", string.Empty));
        }
        return output;
    }
}
