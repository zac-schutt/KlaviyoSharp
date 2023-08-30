namespace KlaviyoSharp.Models;

/// <summary>
/// Base class for Klaviyo objects
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class KlaviyoObjectBasic<T>
{
    /// <summary>
    /// Type of object
    /// </summary>
    public string Type { get; set; }
    /// <summary>
    /// Object attributes
    /// </summary>
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

/// <summary>
/// Klaviyo Account Object with ID and Links
/// </summary>
/// <typeparam name="T">Attributes Type</typeparam>
public abstract class KlaviyoObject<T> : KlaviyoObjectBasic<T>
{
    /// <summary>
    /// Unique identifier for the object
    /// </summary>
    public string Id { get; set; }
    /// <summary>
    /// Links to the object
    /// </summary>
    public Links.SelfLink Links { get; set; }
}

/// <summary>
/// Klaviyo Account Object with ID, Links, and Relationships
/// </summary>
/// <typeparam name="T">Attributes Type</typeparam>
/// <typeparam name="U">Relationships Type</typeparam>
public abstract class KlaviyoObject<T, U> : KlaviyoObjectBasic<T>
{
    /// <summary>
    /// Unique identifier for the object
    /// </summary>
    public string Id { get; set; }
    /// <summary>
    /// Links to the object
    /// </summary>
    public Links.SelfLink Links { get; set; }
    /// <summary>
    /// Relationships to the object
    /// </summary>
    public U Relationships { get; set; }
}