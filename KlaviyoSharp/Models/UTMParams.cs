namespace KlaviyoSharp.Models;

/// <summary>
/// UTM Params
/// </summary>
public class UTMParams
{
    /// <summary>
    /// Name of the UTM param
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Value of the UTM param. Can be templated data.
    /// </summary>
    public string Value { get; set; }
}