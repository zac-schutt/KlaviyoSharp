using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;
/// <summary>
/// Interface for interacting with Klaviyo Catalog API.
/// </summary>
public interface ICatalogServices
{
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
    Task<DataListObject<CatalogItem>> GetCatalogItems(List<string> catalogItemFields, List<string> catalogVariantFields, IFilter filter, List<string> includedRecords, string sort, CancellationToken cancellationToken);
    /// <summary>
    /// Create a new catalog item.
    /// </summary>
    /// <param name="catalogItem"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogItem>> CreateCatalogItem(CatalogItem catalogItem, CancellationToken cancellationToken);
    /// <summary>
    /// Get a specific catalog item with the given item ID. Include parameters can be provided to get the following related resource data: variants
    /// </summary>
    /// <param name="catalogItemId">The catalog item ID is a compound ID (string), with format: {integration}:::{catalog}:::{external_id}. Currently, the only supported integration type is $custom, and the only supported catalog is $default.</param>
    /// <param name="catalogItemFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="catalogVariantFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="includedRecords">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#relationships</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogItem>> GetCatalogItem(string catalogItemId, List<string> catalogItemFields, List<string> catalogVariantFields, List<string> includedRecords, CancellationToken cancellationToken);
    /// <summary>
    /// Update a catalog item with the given item ID.
    /// </summary>
    /// <param name="catalogItemId">The catalog item ID is a compound ID (string), with format: {integration}:::{catalog}:::{external_id}. Currently, the only supported integration type is $custom, and the only supported catalog is $default.</param>
    /// <param name="catalogItem"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogItem>> UpdateCatalogItem(string catalogItemId, CatalogItem catalogItem, CancellationToken cancellationToken);
    /// <summary>
    /// Delete a catalog item with the given item ID.
    /// </summary>
    /// <param name="catalogItemId">The catalog item ID is a compound ID (string), with format: {integration}:::{catalog}:::{external_id}. Currently, the only supported integration type is $custom, and the only supported catalog is $default.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteCatalogItem(string catalogItemId, CancellationToken cancellationToken);
    /// <summary>
    /// Get all catalog item bulk create jobs.
    /// </summary>
    /// <param name="CatalogItemBulkJobFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/reference/api-overview#filtering" /> Allowed fields: status</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<CatalogItemBulkJob>> GetCreateItemsJobs(List<string> CatalogItemBulkJobFields, IFilter filter, CancellationToken cancellationToken);
    /// <summary>
    /// Create a catalog item bulk create job to create a batch of catalog items. Accepts up to 100 catalog items per request. The maximum allowed payload size is 4MB.
    /// </summary>
    /// <param name="catalogItemBulkJob"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogItemBulkJob>> SpawnCreateItemsJob(CatalogItemBulkJob catalogItemBulkJob, CancellationToken cancellationToken);
    /// <summary>
    /// Get a catalog item bulk create job with the given job ID. An include parameter can be provided to get the following related resource data: items.
    /// </summary>
    /// <param name="catalogItemBulkJobId">ID of the job to retrieve.</param>
    /// <param name="CatalogItemBulkJobFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="CatalogItemFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="includedRecords">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#relationships</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogItemBulkJob>> GetCreateItemsJob(string catalogItemBulkJobId, List<string> CatalogItemBulkJobFields, List<string> CatalogItemFields, List<string> includedRecords, CancellationToken cancellationToken);
    /// <summary>
    /// Get all catalog item bulk update jobs.
    /// </summary>
    /// <param name="CatalogItemBulkJobFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/reference/api-overview#filtering" />. Allowed fields: status</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<CatalogItemBulkJob>> GetUpdateItemsJobs(List<string> CatalogItemBulkJobFields, IFilter filter, CancellationToken cancellationToken);
    /// <summary>
    /// Create a catalog item bulk update job to update a batch of catalog items. Accepts up to 100 catalog items per request. The maximum allowed payload size is 4MB.
    /// </summary>
    /// <param name="catalogItemBulkJob"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogItemBulkJob>> SpawnUpdateItemsJob(CatalogItemBulkJob catalogItemBulkJob, CancellationToken cancellationToken);
    /// <summary>
    /// Get a catalog item bulk update job with the given job ID. An include parameter can be provided to get the following related resource data: items.
    /// </summary>
    /// <param name="catalogItemBulkJobId">ID of the job to retrieve.</param>
    /// <param name="CatalogItemBulkJobFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="CatalogItemFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="includedRecords">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#relationships</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogItemBulkJob>> GetUpdateItemsJob(string catalogItemBulkJobId, List<string> CatalogItemBulkJobFields, List<string> CatalogItemFields, List<string> includedRecords, CancellationToken cancellationToken);
    /// <summary>
    /// Get all catalog item bulk delete jobs.
    /// </summary>
    /// <param name="CatalogItemBulkJobFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#filtering Allowed fields: status</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<CatalogItemBulkJob>> GetDeleteItemsJobs(List<string> CatalogItemBulkJobFields, IFilter filter, CancellationToken cancellationToken);
    /// <summary>
    /// Create a catalog item bulk delete job to delete a batch of catalog items. Accepts up to 100 catalog items per request. The maximum allowed payload size is 4MB.
    /// </summary>
    /// <param name="catalogItemBulkJob">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogItemBulkJob>> SpawnDeleteItemsJob(CatalogItemBulkJob catalogItemBulkJob, CancellationToken cancellationToken);
    /// <summary>
    ///Get a catalog item bulk delete job with the given job ID.
    /// </summary>
    /// <param name="catalogItemBulkJobId">ID of the job to retrieve.</param>
    /// <param name="CatalogItemBulkJobFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogItemBulkJob>> GetDeleteItemsJob(string catalogItemBulkJobId, List<string> CatalogItemBulkJobFields, CancellationToken cancellationToken);
    /// <summary>
    ///Get all items in a category with the given category ID. Items can be sorted by the following fields, in ascending and descending order: created. Include parameters can be provided to get the following related resource data: variants.
    /// </summary>
    /// <param name="catalogCategoryId"></param>
    /// <param name="catalogItemFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="catalogVariantFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/reference/api-overview#filtering" />. Allowed fields: ids, category, title, published</param>
    /// <param name="includedRecords">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#relationships</param>
    /// <param name="sort">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sorting</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<CatalogItem>> GetCatalogCategoryItems(string catalogCategoryId, List<string> catalogItemFields = null, List<string> catalogVariantFields = null, IFilter filter = null, List<string> includedRecords = null, string sort = null, CancellationToken cancellationToken = default);
}