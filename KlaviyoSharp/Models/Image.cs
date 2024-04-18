namespace KlaviyoSharp.Models;

/// <summary>
/// Images returned from the API
/// </summary>
public class Image : KlaviyoObject<ImageAttributes>
{
    /// <summary>
    /// Creates a new instance of the Image class
    /// </summary>
    /// <returns></returns>
    public static new Image Create()
    {
        return new Image() { Type = "image" };
    }
    /// <summary>
    /// Creates a new instance of the Image class
    /// </summary>
    /// <returns></returns>
    public static ImageFromUrl CreateFromUrl()
    {
        return ImageFromUrl.Create();
    }
    /// <summary>
    /// Creates a new instance of the Image class
    /// </summary>
    /// <returns></returns>
    public static ImageFromFile CreateFromFile()
    {
        return ImageFromFile.Create();
    }
}

/// <summary>
/// Klaviyo Image for patching
/// </summary>
public class PatchImage : KlaviyoObject<PatchImageAttributes>
{
    /// <summary>
    /// Generic Constructor
    /// </summary>
    public PatchImage() { }
    /// <summary>
    /// Constructor for PatchImage from existing Image
    /// </summary>
    /// <param name="image"></param>
    public PatchImage(Image image)
    {
        Id = image.Id;
        Type = image.Type;
        Attributes = image.Attributes;
    }
    /// <summary>
    /// Creates a new instance of the Klaviyo Image with default values
    /// </summary>
    /// <returns></returns>
    public static new PatchImage Create() => new() { Type = "image" };
}

/// <summary>
/// PatchImage attributes
/// </summary>
public class PatchImageAttributes
{
    /// <summary>
    /// A name for the image.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// If true, this image is not shown in the asset library.
    /// </summary>
    public bool Hidden { get; set; }
}

/// <summary>
/// Image attributes
/// </summary>
public class ImageAttributes : PatchImageAttributes
{
    /// <summary>
    /// Undocumented
    /// </summary>
    public string ImageUrl { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    public string Format { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    public int Size { get; private set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}
