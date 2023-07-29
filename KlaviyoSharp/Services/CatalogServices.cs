using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Infrastructure;
using KlaviyoSharp.Models.Filters;
using KlaviyoSharp.Models;
using System.Net.Http;

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

    /// <inheritdoc />
    public async Task<DataListObject<CatalogVariant>> GetCatalogVariants(List<string> catalogVariantFields = null, IFilter filter = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-variant", catalogVariantFields);
        query.AddFilter(filter);
        query.AddSort(sort);
        return await _klaviyoService.HTTPRecursive<CatalogVariant>(HttpMethod.Get, "catalog-variants", _revision, query, null, null, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<DataObject<CatalogVariant>> CreateCatalogVariant(CatalogVariant catalogVariant, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CatalogVariant>>(HttpMethod.Post, "catalog-variants", _revision, null, null, new DataObject<CatalogVariant>(catalogVariant), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogVariant>> GetCatalogVariant(string catalogVariantId, List<string> catalogVariantFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-variant", catalogVariantFields);
        return await _klaviyoService.HTTP<DataObject<CatalogVariant>>(HttpMethod.Get, $"catalog-variants/{catalogVariantId}/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogVariant>> UpdateCatalogVariant(string catalogVariantId, CatalogVariant catalogVariant, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CatalogVariant>>(HttpMethod.Put, $"catalog-variants/{catalogVariantId}/", _revision, null, null, new DataObject<CatalogVariant>(catalogVariant), cancellationToken);
    }
    /// <inheritdoc />
    public async Task DeleteCatalogVariant(string catalogVariantId, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Delete, $"catalog-variants/{catalogVariantId}/", _revision, null, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<CatalogVariantBulkJob>> GetCreateVariantsJobs(List<string> CatalogVariantBulkJobFields = null, IFilter filter = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-variant-bulk-create-job", CatalogVariantBulkJobFields);
        query.AddFilter(filter);
        return await _klaviyoService.HTTPRecursive<CatalogVariantBulkJob>(HttpMethod.Get, "catalog-variant-bulk-create-jobs", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogVariantBulkJob>> SpawnCreateVariantsJob(CatalogVariantBulkJob catalogVariantBulkJob, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CatalogVariantBulkJob>>(HttpMethod.Post, "catalog-variant-bulk-create-jobs", _revision, null, null, new DataObject<CatalogVariantBulkJob>(catalogVariantBulkJob), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogVariantBulkJob>> GetCreateVariantsJob(string catalogVariantBulkJobId, List<string> CatalogVariantBulkJobFields = null, List<string> CatalogVariantFields = null, List<string> includedRecords = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-variant-bulk-create-job", CatalogVariantBulkJobFields);
        query.AddFieldset("catalog-variant", CatalogVariantFields);
        query.AddIncludes(includedRecords);
        return await _klaviyoService.HTTP<DataObject<CatalogVariantBulkJob>>(HttpMethod.Get, $"catalog-variant-bulk-create-jobs/{catalogVariantBulkJobId}/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<CatalogVariantBulkJob>> GetUpdateVariantsJobs(List<string> CatalogVariantBulkJobFields = null, IFilter filter = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-variant-bulk-update-job", CatalogVariantBulkJobFields);
        query.AddFilter(filter);
        return await _klaviyoService.HTTPRecursive<CatalogVariantBulkJob>(HttpMethod.Get, "catalog-variant-bulk-update-jobs", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogVariantBulkJob>> SpawnUpdateVariantsJob(CatalogVariantBulkJob catalogVariantBulkJob, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CatalogVariantBulkJob>>(HttpMethod.Post, "catalog-variant-bulk-update-jobs", _revision, null, null, new DataObject<CatalogVariantBulkJob>(catalogVariantBulkJob), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogVariantBulkJob>> GetUpdateVariantsJob(string catalogVariantBulkJobId, List<string> CatalogVariantBulkJobFields = null, List<string> CatalogVariantFields = null, List<string> includedRecords = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-variant-bulk-update-job", CatalogVariantBulkJobFields);
        query.AddFieldset("catalog-variant", CatalogVariantFields);
        query.AddIncludes(includedRecords);
        return await _klaviyoService.HTTP<DataObject<CatalogVariantBulkJob>>(HttpMethod.Get, $"catalog-variant-bulk-update-jobs/{catalogVariantBulkJobId}/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<CatalogVariantBulkJob>> GetDeleteVariantsJobs(List<string> CatalogVariantBulkJobFields = null, IFilter filter = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-variant-bulk-delete-job", CatalogVariantBulkJobFields);
        query.AddFilter(filter);
        return await _klaviyoService.HTTPRecursive<CatalogVariantBulkJob>(HttpMethod.Get, "catalog-variant-bulk-delete-jobs", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogVariantBulkJob>> SpawnDeleteVariantsJob(CatalogVariantBulkJob catalogVariantBulkJob, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CatalogVariantBulkJob>>(HttpMethod.Post, "catalog-variant-bulk-delete-jobs", _revision, null, null, new DataObject<CatalogVariantBulkJob>(catalogVariantBulkJob), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogVariantBulkJob>> GetDeleteVariantsJob(string catalogVariantBulkJobId, List<string> CatalogVariantBulkJobFields = null, List<string> CatalogVariantFields = null, List<string> includedRecords = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-variant-bulk-delete-job", CatalogVariantBulkJobFields);
        query.AddFieldset("catalog-variant", CatalogVariantFields);
        query.AddIncludes(includedRecords);
        return await _klaviyoService.HTTP<DataObject<CatalogVariantBulkJob>>(HttpMethod.Get, $"catalog-variant-bulk-delete-jobs/{catalogVariantBulkJobId}/", _revision, query, null, null, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<DataListObject<CatalogVariant>> GetCatalogItemVariants(string catalogItemId, List<string> catalogVariantFields = null, IFilter filter = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-variant", catalogVariantFields);
        query.AddFilter(filter);
        query.AddSort(sort);
        return await _klaviyoService.HTTPRecursive<CatalogVariant>(HttpMethod.Get, $"catalog-items/{catalogItemId}/variants/", _revision, query, null, null, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<DataListObject<CatalogCategory>> GetCatalogCategories(List<string> catalogCategoryFields = null, IFilter filter = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-category", catalogCategoryFields);
        query.AddFilter(filter);
        query.AddSort(sort);
        return await _klaviyoService.HTTPRecursive<CatalogCategory>(HttpMethod.Get, "catalog-categories", _revision, query, null, null, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<DataObject<CatalogCategory>> CreateCatalogCategory(CatalogCategory catalogCategory, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CatalogCategory>>(HttpMethod.Post, "catalog-categories", _revision, null, null, new DataObject<CatalogCategory>(catalogCategory), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogCategory>> GetCatalogCategory(string catalogCategoryId, List<string> catalogCategoryFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-category", catalogCategoryFields);
        return await _klaviyoService.HTTP<DataObject<CatalogCategory>>(HttpMethod.Get, $"catalog-categories/{catalogCategoryId}/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogCategory>> UpdateCatalogCategory(string catalogCategoryId, CatalogCategory catalogCategory, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CatalogCategory>>(HttpMethod.Put, $"catalog-categories/{catalogCategoryId}/", _revision, null, null, new DataObject<CatalogCategory>(catalogCategory), cancellationToken);
    }
    /// <inheritdoc />
    public async Task DeleteCatalogCategory(string catalogCategoryId, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Delete, $"catalog-categories/{catalogCategoryId}/", _revision, null, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<CatalogCategoryBulkJob>> GetCreateCategoriesJobs(List<string> CatalogCategoryBulkJobFields = null, IFilter filter = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-category-bulk-create-job", CatalogCategoryBulkJobFields);
        query.AddFilter(filter);
        return await _klaviyoService.HTTPRecursive<CatalogCategoryBulkJob>(HttpMethod.Get, "catalog-category-bulk-create-jobs", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogCategoryBulkJob>> SpawnCreateCategoriesJob(CatalogCategoryBulkJob catalogCategoryBulkJob, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CatalogCategoryBulkJob>>(HttpMethod.Post, "catalog-category-bulk-create-jobs", _revision, null, null, new DataObject<CatalogCategoryBulkJob>(catalogCategoryBulkJob), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogCategoryBulkJob>> GetCreateCategoriesJob(string catalogCategoryBulkJobId, List<string> CatalogCategoryBulkJobFields = null, List<string> CatalogCategoryFields = null, List<string> includedRecords = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-category-bulk-create-job", CatalogCategoryBulkJobFields);
        query.AddFieldset("catalog-category", CatalogCategoryFields);
        query.AddIncludes(includedRecords);
        return await _klaviyoService.HTTP<DataObject<CatalogCategoryBulkJob>>(HttpMethod.Get, $"catalog-category-bulk-create-jobs/{catalogCategoryBulkJobId}/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<CatalogCategoryBulkJob>> GetUpdateCategoriesJobs(List<string> CatalogCategoryBulkJobFields = null, IFilter filter = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-category-bulk-update-job", CatalogCategoryBulkJobFields);
        query.AddFilter(filter);
        return await _klaviyoService.HTTPRecursive<CatalogCategoryBulkJob>(HttpMethod.Get, "catalog-category-bulk-update-jobs", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogCategoryBulkJob>> SpawnUpdateCategoriesJob(CatalogCategoryBulkJob catalogCategoryBulkJob, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CatalogCategoryBulkJob>>(HttpMethod.Post, "catalog-category-bulk-update-jobs", _revision, null, null, new DataObject<CatalogCategoryBulkJob>(catalogCategoryBulkJob), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogCategoryBulkJob>> GetUpdateCategoriesJob(string catalogCategoryBulkJobId, List<string> CatalogCategoryBulkJobFields = null, List<string> CatalogCategoryFields = null, List<string> includedRecords = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-category-bulk-update-job", CatalogCategoryBulkJobFields);
        query.AddFieldset("catalog-category", CatalogCategoryFields);
        query.AddIncludes(includedRecords);
        return await _klaviyoService.HTTP<DataObject<CatalogCategoryBulkJob>>(HttpMethod.Get, $"catalog-category-bulk-update-jobs/{catalogCategoryBulkJobId}/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<CatalogCategoryBulkJob>> GetDeleteCategoriesJobs(List<string> CatalogCategoryBulkJobFields = null, IFilter filter = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-category-bulk-delete-job", CatalogCategoryBulkJobFields);
        query.AddFilter(filter);
        return await _klaviyoService.HTTPRecursive<CatalogCategoryBulkJob>(HttpMethod.Get, "catalog-category-bulk-delete-jobs", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogCategoryBulkJob>> SpawnDeleteCategoriesJob(CatalogCategoryBulkJob catalogCategoryBulkJob, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CatalogCategoryBulkJob>>(HttpMethod.Post, "catalog-category-bulk-delete-jobs", _revision, null, null, new DataObject<CatalogCategoryBulkJob>(catalogCategoryBulkJob), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CatalogCategoryBulkJob>> GetDeleteCategoriesJob(string catalogCategoryBulkJobId, List<string> CatalogCategoryBulkJobFields = null, List<string> includedRecords = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-category-bulk-delete-job", CatalogCategoryBulkJobFields);
        query.AddIncludes(includedRecords);
        return await _klaviyoService.HTTP<DataObject<CatalogCategoryBulkJob>>(HttpMethod.Get, $"catalog-category-bulk-delete-jobs/{catalogCategoryBulkJobId}/", _revision, query, null, null, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<DataListObject<CatalogCategory>> GetCatalogItemCategories(string catalogItemId, List<string> catalogCategoryFields = null, IFilter filter = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("catalog-category", catalogCategoryFields);
        query.AddFilter(filter);
        query.AddSort(sort);
        return await _klaviyoService.HTTPRecursive<CatalogCategory>(HttpMethod.Get, $"catalog-items/{catalogItemId}/categories/", _revision, query, null, null, cancellationToken);
    }
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
