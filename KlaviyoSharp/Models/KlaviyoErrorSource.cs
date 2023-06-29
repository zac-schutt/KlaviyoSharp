namespace KlaviyoSharp.Models;
/// <summary>
/// Source of the error in the request
/// </summary>
public class KlaviyoErrorSource
{
    /// <summary>
    /// Pointer to the error in the request body
    /// </summary>
    public string Pointer { get; set; }
    /// <summary>
    /// Parameter in the request that caused the error
    /// </summary>
    public string Parameter { get; set; }
}