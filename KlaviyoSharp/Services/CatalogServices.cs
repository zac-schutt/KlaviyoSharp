using System.Collections.Generic;
using System.Linq.Expressions;
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
    /// <inheritdoc />
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
    /// <inheritdoc />
    public async Task<DataObject<CatalogItem>> CreateCatalogItem(CatalogItem catalogItem, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CatalogItem>>(HttpMethod.Post, "catalog-items", _revision, null, null, new DataObject<CatalogItem>(catalogItem), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogItem>> GetCatalogItem(string catalogItemId, List<string> catalogItemFields = null, List<string> catalogVariantFields = null, List<string> includedRecords = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-item", catalogItemFields);
        query.AddFieldset("catalog-variant", catalogVariantFields);
        query.AddIncludes(includedRecords);
        return await _klaviyoService.HTTP<DataObject<CatalogItem>>(HttpMethod.Get, $"catalog-items/{catalogItemId}/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogItem>> UpdateCatalogItem(string catalogItemId, CatalogItem catalogItem, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CatalogItem>>(HttpMethod.Put, $"catalog-items/{catalogItemId}/", _revision, null, null, new DataObject<CatalogItem>(catalogItem), cancellationToken);
    }
    /// <inheritdoc />
    public async Task DeleteCatalogItem(string catalogItemId, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Delete, $"catalog-items/{catalogItemId}/", _revision, null, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<CatalogItemBulkJob>> GetCreateItemsJobs(List<string> CatalogItemBulkJobFields = null, IFilter filter = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-item-bulk-create-job", CatalogItemBulkJobFields);
        query.AddFilter(filter);
        return await _klaviyoService.HTTPRecursive<CatalogItemBulkJob>(HttpMethod.Get, "catalog-item-bulk-create-jobs", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogItemBulkJob>> SpawnCreateItemsJob(CatalogItemBulkJob catalogItemBulkJob, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CatalogItemBulkJob>>(HttpMethod.Post, "catalog-item-bulk-create-jobs", _revision, null, null, new DataObject<CatalogItemBulkJob>(catalogItemBulkJob), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogItemBulkJob>> GetCreateItemsJob(string catalogItemBulkJobId, List<string> CatalogItemBulkJobFields = null, List<string> CatalogItemFields = null, List<string> includedRecords = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-item-bulk-create-job", CatalogItemBulkJobFields);
        query.AddFieldset("catalog-item", CatalogItemFields);
        query.AddIncludes(includedRecords);
        return await _klaviyoService.HTTP<DataObject<CatalogItemBulkJob>>(HttpMethod.Get, $"catalog-item-bulk-create-jobs/{catalogItemBulkJobId}/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<CatalogItemBulkJob>> GetUpdateItemsJobs(List<string> CatalogItemBulkJobFields = null, IFilter filter = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-item-bulk-update-job", CatalogItemBulkJobFields);
        query.AddFilter(filter);
        return await _klaviyoService.HTTPRecursive<CatalogItemBulkJob>(HttpMethod.Get, "catalog-item-bulk-update-jobs", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogItemBulkJob>> SpawnUpdateItemsJob(CatalogItemBulkJob catalogItemBulkJob, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CatalogItemBulkJob>>(HttpMethod.Post, "catalog-item-bulk-update-jobs", _revision, null, null, new DataObject<CatalogItemBulkJob>(catalogItemBulkJob), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogItemBulkJob>> GetUpdateItemsJob(string catalogItemBulkJobId, List<string> CatalogItemBulkJobFields = null, List<string> CatalogItemFields = null, List<string> includedRecords = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-item-bulk-update-job", CatalogItemBulkJobFields);
        query.AddFieldset("catalog-item", CatalogItemFields);
        query.AddIncludes(includedRecords);
        return await _klaviyoService.HTTP<DataObject<CatalogItemBulkJob>>(HttpMethod.Get, $"catalog-item-bulk-update-jobs/{catalogItemBulkJobId}/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<CatalogItemBulkJob>> GetDeleteItemsJobs(List<string> CatalogItemBulkJobFields = null, IFilter filter = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-item-bulk-delete-job", CatalogItemBulkJobFields);
        query.AddFilter(filter);
        return await _klaviyoService.HTTPRecursive<CatalogItemBulkJob>(HttpMethod.Get, "catalog-item-bulk-delete-jobs", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogItemBulkJob>> SpawnDeleteItemsJob(CatalogItemBulkJob catalogItemBulkJob, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CatalogItemBulkJob>>(HttpMethod.Post, "catalog-item-bulk-delete-jobs", _revision, null, null, new DataObject<CatalogItemBulkJob>(catalogItemBulkJob), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogItemBulkJob>> GetDeleteItemsJob(string catalogItemBulkJobId, List<string> CatalogItemBulkJobFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-item-bulk-delete-job", CatalogItemBulkJobFields);
        return await _klaviyoService.HTTP<DataObject<CatalogItemBulkJob>>(HttpMethod.Get, $"catalog-item-bulk-delete-jobs/{catalogItemBulkJobId}/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<CatalogItem>> GetCatalogCategoryItems(string catalogCategoryId, List<string> catalogItemFields = null, List<string> catalogVariantFields = null, IFilter filter = null, List<string> includedRecords = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-item", catalogItemFields);
        query.AddFieldset("catalog-variant", catalogVariantFields);
        query.AddFilter(filter);
        query.AddIncludes(includedRecords);
        query.AddSort(sort);
        return await _klaviyoService.HTTPRecursive<CatalogItem>(HttpMethod.Get, $"catalog-categories/{catalogCategoryId}/items", _revision, query, null, null, cancellationToken);
    }

    //TODO: Insert Variant Services


    //TODO: Insert Category Services
    /// <inheritdoc />
    public async Task<DataListObject<GenericObject>> GetCatalogCategoryRelationshipsItems(string id, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataListObject<GenericObject>>(HttpMethod.Get, $"catalog-categories/{id}/relationships/items/", _revision, null, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task CreateCatalogCategoryRelationshipsItems(string id, DataListObject<GenericObject> relationships, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Post, $"catalog-categories/{id}/relationships/items/", _revision, null, null, relationships, cancellationToken);
    }
    /// <inheritdoc />
    public async Task UpdateCatalogCategoryRelationshipsItems(string id, DataListObject<GenericObject> relationships, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(new("PATCH"), $"catalog-categories/{id}/relationships/items/", _revision, null, null, relationships, cancellationToken);
    }
    /// <inheritdoc />
    public async Task DeleteCatalogCategoryRelationshipsItems(string id, DataListObject<GenericObject> relationships, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Delete, $"catalog-categories/{id}/relationships/items/", _revision, null, null, relationships, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<GenericObject>> GetCatalogItemRelationshipsCategories(string id, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTPRecursive<GenericObject>(HttpMethod.Get, $"catalog-items/{id}/relationships/categories/", _revision, null, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task CreateCatalogItemRelationshipsCategories(string id, DataListObject<GenericObject> relationships, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Post, $"catalog-items/{id}/relationships/categories/", _revision, null, null, relationships, cancellationToken);
    }
    /// <inheritdoc />
    public async Task UpdateCatalogItemRelationshipsCategories(string id, DataListObject<GenericObject> relationships, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(new("PATCH"), $"catalog-items/{id}/relationships/categories/", _revision, null, null, relationships, cancellationToken);
    }
    /// <inheritdoc />
    public async Task DeleteCatalogItemRelationshipsCategories(string id, DataListObject<GenericObject> relationships, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Delete, $"catalog-items/{id}/relationships/categories/", _revision, null, null, relationships, cancellationToken);
    }
}
