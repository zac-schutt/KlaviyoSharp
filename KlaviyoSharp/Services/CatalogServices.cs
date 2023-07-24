using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Infrastructure;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;
/// <summary>
/// Service for interacting with Klaviyo Catalog API.
/// </summary>
public class CatalogServices : KlaviyoServiceBase, ICatalogServices
{
    /// <summary>
    /// Creates a new instance of the CatalogServices class.
    /// </summary>
    /// <param name="klaviyoService"></param>
    public CatalogServices(KlaviyoApiBase klaviyoService) : base("2023-06-15", klaviyoService) { }
    /// <summary>
    /// Get all catalog items in an account. Catalog items can be sorted by the following fields, in ascending and descending order: created. Include parameters can be provided to get the following related resource data: variants.
    /// </summary>
    /// <param name="catalogItemFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="catalogVariantFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit <s href="https://developers.klaviyo.com/en/reference/api-overview#filtering" />Allowed fields: ids, category, title, published</param>
    /// <param name="includedRecords">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#relationships</param>
    /// <param name="sort">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sorting</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<DataListObject<CatalogItem>> GetCatalogItems(List<string> catalogItemFields = null, List<string> catalogVariantFields = null, IFilter filter = null, List<string> includedRecords = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-item", catalogItemFields);
        query.AddFieldset("catalog-variant", catalogVariantFields);
        query.AddFilter(filter);
        query.AddIncludes(includedRecords);
        query.AddSort(sort);
        return await _klaviyoService.HTTPRecursive<CatalogItem>(HttpMethod.Get, "catalog-items", _revision, query, null, null, cancellationToken);
    }
    /// <summary>
    /// Create a new catalog item.
    /// </summary>
    /// <param name="catalogItem"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<DataObject<CatalogItem>> CreateCatalogItem(CatalogItem catalogItem, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CatalogItem>>(HttpMethod.Post, "catalog-items", _revision, null, null, new DataObject<CatalogItem>(catalogItem), cancellationToken);
    }
    /// <summary>
    /// Get a specific catalog item with the given item ID. Include parameters can be provided to get the following related resource data: variants
    /// </summary>
    /// <param name="catalogItemId">The catalog item ID is a compound ID (string), with format: {integration}:::{catalog}:::{external_id}. Currently, the only supported integration type is $custom, and the only supported catalog is $default.</param>
    /// <param name="catalogItemFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="catalogVariantFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="includedRecords">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#relationships</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<DataObject<CatalogItem>> GetCatalogItem(string catalogItemId, List<string> catalogItemFields = null, List<string> catalogVariantFields = null, List<string> includedRecords = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-item", catalogItemFields);
        query.AddFieldset("catalog-variant", catalogVariantFields);
        query.AddIncludes(includedRecords);
        return await _klaviyoService.HTTP<DataObject<CatalogItem>>(HttpMethod.Get, $"catalog-items/{catalogItemId}/", _revision, query, null, null, cancellationToken);
    }
    /// <summary>
    /// Update a catalog item with the given item ID.
    /// </summary>
    /// <param name="catalogItemId">The catalog item ID is a compound ID (string), with format: {integration}:::{catalog}:::{external_id}. Currently, the only supported integration type is $custom, and the only supported catalog is $default.</param>
    /// <param name="catalogItem"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<DataObject<CatalogItem>> UpdateCatalogItem(string catalogItemId, CatalogItem catalogItem, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CatalogItem>>(HttpMethod.Put, $"catalog-items/{catalogItemId}/", _revision, null, null, new DataObject<CatalogItem>(catalogItem), cancellationToken);
    }
    /// <summary>
    /// Delete a catalog item with the given item ID.
    /// </summary>
    /// <param name="catalogItemId">The catalog item ID is a compound ID (string), with format: {integration}:::{catalog}:::{external_id}. Currently, the only supported integration type is $custom, and the only supported catalog is $default.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task DeleteCatalogItem(string catalogItemId, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Delete, $"catalog-items/{catalogItemId}/", _revision, null, null, null, cancellationToken);
    }
}
