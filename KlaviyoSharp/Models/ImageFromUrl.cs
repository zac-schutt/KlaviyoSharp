namespace KlaviyoSharp.Models;

/// <summary>
/// Upload Image From Url Request
/// </summary>
public class ImageFromUrl : KlaviyoObject<ImageFromUrlRequestAttributes>
{
    /// <summary>
    /// Creates a new instance of the Image class
    /// </summary>
    /// <returns></returns>
    public static new ImageFromUrl Create()
    {
        return new() { Type = "image" };
    }
}

/// <summary>
/// Image From Url Request
/// </summary>
public class ImageFromUrlRequestAttributes
{
    /// <summary>
    /// A name for the image.
    /// Defaults to the filename if not provided.
    /// If the name matches an existing image, a suffix will be added.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// An existing image url to import the image from.
    /// Alternatively, you may specify a base-64 encoded data-uri (data:image/...).
    /// Supported image formats: jpeg,png,gif.
    /// Maximum image size: 5MB.
    /// </summary>
    public string ImportFromUrl { get; set; }
    /// <summary>
    /// If true, this image is not shown in the asset library.
    /// </summary>
    public bool Hidden { get; set; }
}
