using System;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;
public abstract class KlaviyoObjectBasic<T>
{
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("attributes")]
    public T Attributes { get; set; }
    /// <summary>
    /// Creates a new instance of this type and sets the default properties
    /// </summary>
    /// <remarks>Must be overridden in child classes to set the correct properties.</remarks>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static Account Create()
    {
        throw new NotImplementedException("Method not implemented for type");
    }
}

public abstract class KlaviyoObject<T> : KlaviyoObjectBasic<T>
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("links")]
    public Links.SelfLink Links { get; set; }
}