namespace KlaviyoSharp.Models;

/// <summary>
/// Klaviyo Catalog Category
/// </summary>
public class CatalogCategory : KlaviyoObject<CatalogCategoryAttributes, CatalogCategoryRelationships>
{
    /// <summary>
    /// Create a new CatalogCategory with default values
    /// </summary>
    /// <returns></returns>
    public static new CatalogCategory Create() => new() { Type = "catalog-category" };
}

/// <summary>
/// Klaviyo Catalog Category Relationships
/// </summary>
public class CatalogCategoryRelationships
{
    /// <summary>
    /// Related Items
    /// </summary>
    public DataListObject<GenericObject> Items { get; set; }
}

/// <summary>
/// Klaviyo Catalog Category Attributes
/// </summary>
public class CatalogCategoryAttributes
{
    /// <summary>
    /// The ID of the catalog category in an external system.
    /// </summary>
    public string ExternalId { get; set; }
    /// <summary>
    /// The name of the catalog category.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Date and time when the catalog category was last updated, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm).
    /// </summary>
    public DateTime? Updated { get; set; }
    /// <summary>
    /// The type of catalog. Currently only "$default" is supported.
    /// </summary>
    public string CatalogType { get; set; }
    /// <summary>
    /// The integration type. Currently only "$custom" is supported.
    /// </summary>
    public string IntegrationType { get; set; }
}