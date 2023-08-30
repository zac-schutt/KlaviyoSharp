namespace KlaviyoSharp.Models;

/// <summary>
/// Klaviyo Catalog Item
/// </summary>
public class CatalogItem : KlaviyoObject<CatalogItemAttributes, CatalogItemRelationships>
{
    /// <summary>
    /// Creates a new instance of the CatalogItem class
    /// </summary>
    /// <returns></returns>
    public static new CatalogItem Create()
    {
        return new() { Type = "catalog-item" };
    }
}

/// <summary>
/// Klaviyo Catalog Item Relationships
/// </summary>
public class CatalogItemRelationships
{
    /// <summary>
    /// Variants associated with the Catalog Item
    /// </summary>
    public DataListObject<GenericObject> Variants { get; set; }
    /// <summary>
    /// Categories associated with the Catalog Item
    /// </summary>
    public DataListObject<GenericObject> Categories { get; set; }
}

/// <summary>
/// Klaviyo Catalog Item Attributes
/// </summary>
public class CatalogItemAttributes
{
    /// <summary>
    /// The ID of the catalog item in an external system.
    /// </summary>
    public string ExternalId { get; set; }
    /// <summary>
    /// The integration type. Currently only "$custom" is supported. Only used for creating catalog items.
    /// </summary>
    public string IntegrationType { get; set; }
    /// <summary>
    /// The type of catalog. Currently only "$default" is supported. Only used for creating catalog items.
    /// </summary>
    public string CatalogType { get; set; }
    /// <summary>
    /// The title of the catalog item.
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// A description of the catalog item.
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// This field can be used to set the price on the catalog item, which is what gets displayed for the item when included in emails. For most price-update use cases, you will also want to update the price on any child variants, using the Update Catalog Variant Endpoint.
    /// </summary>
    public decimal? Price { get; set; }
    /// <summary>
    /// URL pointing to the location of the catalog item on your website.
    /// </summary>
    public string Url { get; set; }
    /// <summary>
    /// URL pointing to the location of a full image of the catalog item.
    /// </summary>
    public string ImageFullUrl { get; set; }
    /// <summary>
    /// URL pointing to the location of an image thumbnail of the catalog item
    /// </summary>
    public string ImageThumbnailUrl { get; set; }
    /// <summary>
    /// List of URLs pointing to the locations of images of the catalog item.
    /// </summary>
    public List<string> Images { get; set; }
    /// <summary>
    /// Flat JSON blob to provide custom metadata about the catalog item. May not exceed 100kb.
    /// </summary>
    public Dictionary<string, object> CustomMetadata { get; set; }
    /// <summary>
    /// Boolean value indicating whether the catalog item is published.
    /// </summary>
    public bool? Published { get; set; }
    /// <summary>
    /// Date and time when the catalog item was created, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm).
    /// </summary>
    public DateTime? Created { get; set; }
    /// <summary>
    /// Date and time when the catalog item was last updated, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm).
    /// </summary>
    public DateTime? Updated { get; set; }
}