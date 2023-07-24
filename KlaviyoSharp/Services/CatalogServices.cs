using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Infrastructure;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;

public class CatalogServices : KlaviyoServiceBase, ICatalogServices
{
    public CatalogServices(KlaviyoApiBase klaviyoService) : base("2023-06-15", klaviyoService) { }

    public async Task<DataListObject<CatalogItem>> GetCatalogItems(List<string> catalogItemFields = null, List<string> catalogVariantFields = null, IFilter filter = null, List<string> includedRecords = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-item", catalogItemFields);
        query.AddFieldset("catalog-variant", catalogVariantFields);
        query.AddFilter(filter);
        query.AddIncludes(includedRecords);
        return await _klaviyoService.HTTPRecursive<CatalogItem>(HttpMethod.Get, "catalog-items", _revision, query, null, null, cancellationToken);
    }
    public async Task<DataObject<CatalogItem>> CreateCatalogItem(CatalogItem catalogItem, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CatalogItem>>(HttpMethod.Post, "catalog-items", _revision, null, null, new DataObject<CatalogItem>(catalogItem), cancellationToken);
    }
    public async Task<DataObject<CatalogItem>> GetCatalogItem(string catalogItemId, List<string> catalogItemFields = null, List<string> catalogVariantFields = null, List<string> includedRecords = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-item", catalogItemFields);
        query.AddFieldset("catalog-variant", catalogVariantFields);
        query.AddIncludes(includedRecords);
        return await _klaviyoService.HTTP<DataObject<CatalogItem>>(HttpMethod.Get, $"catalog-items/{catalogItemId}/", _revision, query, null, null, cancellationToken);
    }
    public async Task<DataObject<CatalogItem>> UpdateCatalogItem(string catalogItemId, CatalogItem catalogItem, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CatalogItem>>(HttpMethod.Put, $"catalog-items/{catalogItemId}/", _revision, null, null, new DataObject<CatalogItem>(catalogItem), cancellationToken);
    }
    public async Task DeleteCatalogItem(string catalogItemId, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Delete, $"catalog-items/{catalogItemId}/", _revision, null, null, null, cancellationToken);
    }
}
