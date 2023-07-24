using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
    public static new Event Create()
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
    [JsonProperty("variants")]
    public DataListObject<GenericObject> Variants { get; set; }
    /// <summary>
    /// Categories associated with the Catalog Item
    /// </summary>
    [JsonProperty("categories")]
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
    [JsonProperty("external_id")]
    public string ExternalId { get; set; }
    /// <summary>
    /// The integration type. Currently only "$custom" is supported. Only used for creating catalog items.
    /// </summary>
    [JsonProperty("integration_type")]
    public string IntegrationType { get; set; }
    /// <summary>
    /// The type of catalog. Currently only "$default" is supported. Only used for creating catalog items.
    /// </summary>
    [JsonProperty("catalog_type")]
    public string CatalogType { get; set; }

    /// <summary>
    /// The title of the catalog item.
    /// </summary>
    [JsonProperty("title")]
    public string Title { get; set; }
    /// <summary>
    /// A description of the catalog item.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; }
    /// <summary>
    /// This field can be used to set the price on the catalog item, which is what gets displayed for the item when included in emails. For most price-update use cases, you will also want to update the price on any child variants, using the Update Catalog Variant Endpoint.
    /// </summary>
    [JsonProperty("price")]
    public decimal? Price { get; set; }
    /// <summary>
    /// URL pointing to the location of the catalog item on your website.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; }
    /// <summary>
    /// URL pointing to the location of a full image of the catalog item.
    /// </summary>
    [JsonProperty("image_full_url")]
    public string ImageFullUrl { get; set; }
    /// <summary>
    /// URL pointing to the location of an image thumbnail of the catalog item
    /// </summary>
    [JsonProperty("image_thumbnail_url")]
    public string ImageThumbnailUrl { get; set; }
    /// <summary>
    /// List of URLs pointing to the locations of images of the catalog item.
    /// </summary>
    [JsonProperty("images")]
    public List<string> Images { get; set; }
    /// <summary>
    /// Flat JSON blob to provide custom metadata about the catalog item. May not exceed 100kb.
    /// </summary>
    [JsonProperty("custom_metadata")]
    public Dictionary<string, object> CustomMetadata { get; set; }
    /// <summary>
    /// Boolean value indicating whether the catalog item is published.
    /// </summary>
    [JsonProperty("published")]
    public bool? Published { get; set; }
    /// <summary>
    /// Date and time when the catalog item was created, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm).
    /// </summary>
    [JsonProperty("created")]
    public DateTime? Created { get; set; }
    /// <summary>
    /// Date and time when the catalog item was last updated, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm).
    /// </summary>
    [JsonProperty("updated")]
    public DateTime? Updated { get; set; }
}