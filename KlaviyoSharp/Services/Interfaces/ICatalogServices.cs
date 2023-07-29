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
    Task<DataListObject<CatalogItem>> GetCatalogCategoryItems(string catalogCategoryId, List<string> catalogItemFields, List<string> catalogVariantFields, IFilter filter, List<string> includedRecords, string sort, CancellationToken cancellationToken);
    /// <summary>
    /// Get all variants in an account. Variants can be sorted by the following fields, in ascending and descending order: created
    /// </summary>
    /// <param name="catalogVariantFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/reference/api-overview#filtering" />. Allowed fields: ids, item.id, sku, title, published</param>
    /// <param name="sort">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sorting</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<CatalogVariant>> GetCatalogVariants(List<string> catalogVariantFields, IFilter filter, string sort, CancellationToken cancellationToken);
    /// <summary>
    /// Create a new variant for a related catalog item.
    /// </summary>
    /// <param name="catalogVariant"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogVariant>> CreateCatalogVariant(CatalogVariant catalogVariant, CancellationToken cancellationToken);
    /// <summary>
    /// Get a catalog item variant with the given variant ID.
    /// </summary>
    /// <param name="catalogVariantId">The catalog variant ID is a compound ID (string), with format: {integration}:::{catalog}:::{external_id}. Currently, the only supported integration type is $custom, and the only supported catalog is $default.</param>
    /// <param name="catalogVariantFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogVariant>> GetCatalogVariant(string catalogVariantId, List<string> catalogVariantFields, CancellationToken cancellationToken);
    /// <summary>
    /// Update a catalog item variant with the given variant ID.
    /// </summary>
    /// <param name="catalogVariantId">The catalog variant ID is a compound ID (string), with format: {integration}:::{catalog}:::{external_id}. Currently, the only supported integration type is $custom, and the only supported catalog is $default.</param>
    /// <param name="catalogVariant"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogVariant>> UpdateCatalogVariant(string catalogVariantId, CatalogVariant catalogVariant, CancellationToken cancellationToken);
    /// <summary>
    /// Delete a catalog item variant with the given variant ID.
    /// </summary>
    /// <param name="catalogVariantId">The catalog variant ID is a compound ID (string), with format: {integration}:::{catalog}:::{external_id}. Currently, the only supported integration type is $custom, and the only supported catalog is $default.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteCatalogVariant(string catalogVariantId, CancellationToken cancellationToken);
    /// <summary>
    /// Get all catalog variant bulk create jobs.
    /// </summary>
    /// <param name="CatalogVariantBulkJobFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/reference/api-overview#filtering" />. Allowed fields: status</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<CatalogVariantBulkJob>> GetCreateVariantsJobs(List<string> CatalogVariantBulkJobFields, IFilter filter, CancellationToken cancellationToken);
    /// <summary>
    /// Create a catalog variant bulk create job to create a batch of catalog variants.Accepts up to 100 catalog variants per request. The maximum allowed payload size is 4MB.
    /// </summary>
    /// <param name="catalogVariantBulkJob"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogVariantBulkJob>> SpawnCreateVariantsJob(CatalogVariantBulkJob catalogVariantBulkJob, CancellationToken cancellationToken);
    /// <summary>
    /// Get a catalog variant bulk create job with the given job ID. An include parameter can be provided to get the following related resource data: variants.
    /// </summary>
    /// <param name="catalogVariantBulkJobId">ID of the job to retrieve.</param>
    /// <param name="CatalogVariantBulkJobFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="CatalogVariantFields"></param>
    /// <param name="includedRecords"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogVariantBulkJob>> GetCreateVariantsJob(string catalogVariantBulkJobId, List<string> CatalogVariantBulkJobFields, List<string> CatalogVariantFields, List<string> includedRecords, CancellationToken cancellationToken);


    /// <summary>
    /// Get all catalog variant bulk update jobs.
    /// </summary>
    /// <param name="CatalogVariantBulkJobFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/reference/api-overview#filtering" />. Allowed fields: status</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<CatalogVariantBulkJob>> GetUpdateVariantsJobs(List<string> CatalogVariantBulkJobFields, IFilter filter, CancellationToken cancellationToken);
    /// <summary>
    /// Create a catalog variant bulk update job to update a batch of catalog variants. Accepts up to 100 catalog variants per request. The maximum allowed payload size is 4MB.
    /// </summary>
    /// <param name="catalogVariantBulkJob"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogVariantBulkJob>> SpawnUpdateVariantsJob(CatalogVariantBulkJob catalogVariantBulkJob, CancellationToken cancellationToken);
    /// <summary>
    /// Get a catalog variant bulk update job with the given job ID. An include parameter can be provided to get the following related resource data: variants.
    /// </summary>
    /// <param name="catalogVariantBulkJobId">ID of the job to retrieve.</param>
    /// <param name="CatalogVariantBulkJobFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="CatalogVariantFields"></param>
    /// <param name="includedRecords"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogVariantBulkJob>> GetUpdateVariantsJob(string catalogVariantBulkJobId, List<string> CatalogVariantBulkJobFields, List<string> CatalogVariantFields, List<string> includedRecords, CancellationToken cancellationToken);

    /// <summary>
    /// Get all catalog variant bulk delete jobs.
    /// </summary>
    /// <param name="CatalogVariantBulkJobFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/reference/api-overview#filtering" />. Allowed fields: status</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<CatalogVariantBulkJob>> GetDeleteVariantsJobs(List<string> CatalogVariantBulkJobFields, IFilter filter, CancellationToken cancellationToken);
    /// <summary>
    /// Create a catalog variant bulk delete job to delete a batch of catalog variants.Accepts up to 100 catalog variants per request. The maximum allowed payload size is 4MB.
    /// </summary>
    /// <param name="catalogVariantBulkJob"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogVariantBulkJob>> SpawnDeleteVariantsJob(CatalogVariantBulkJob catalogVariantBulkJob, CancellationToken cancellationToken);
    /// <summary>
    /// Get a catalog variant bulk delete job with the given job ID. An include parameter can be provided to get the following related resource data: variants.
    /// </summary>
    /// <param name="catalogVariantBulkJobId">ID of the job to retrieve.</param>
    /// <param name="CatalogVariantBulkJobFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="CatalogVariantFields"></param>
    /// <param name="includedRecords"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogVariantBulkJob>> GetDeleteVariantsJob(string catalogVariantBulkJobId, List<string> CatalogVariantBulkJobFields, List<string> CatalogVariantFields, List<string> includedRecords, CancellationToken cancellationToken);
    /// <summary>
    /// Get all variants related to the given item ID. Variants can be sorted by the following fields, in ascending and descending order: created
    /// </summary>
    /// <param name="catalogItemId"></param>
    /// <param name="catalogVariantFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/reference/api-overview#filtering" />. Allowed fields: ids, item, sku, title, published</param>
    /// <param name="sort">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sorting</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<CatalogVariant>> GetCatalogItemVariants(string catalogItemId, List<string> catalogVariantFields, IFilter filter, string sort, CancellationToken cancellationToken);
    /// <summary>
    /// Get all catalog categories in an account. Catalog categories can be sorted by the following fields, in ascending and descending order: created
    /// </summary>
    /// <param name="catalogCategoryFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/reference/api-overview#filtering" />. Allowed fields: ids, item, name</param>
    /// <param name="sort">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sorting</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<CatalogCategory>> GetCatalogCategories(List<string> catalogCategoryFields, IFilter filter, string sort, CancellationToken cancellationToken);
    /// <summary>
    /// Create a new catalog category.
    /// </summary>
    /// <param name="catalogCategory"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogCategory>> CreateCatalogCategory(CatalogCategory catalogCategory, CancellationToken cancellationToken);
    /// <summary>
    /// Get a catalog category with the given category ID.
    /// </summary>
    /// <param name="catalogCategoryId">The catalog category ID is a compound ID (string), with format: {integration}:::{catalog}:::{external_id}. Currently, the only supported integration type is $custom, and the only supported catalog is $default.</param>
    /// <param name="catalogCategoryFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogCategory>> GetCatalogCategory(string catalogCategoryId, List<string> catalogCategoryFields, CancellationToken cancellationToken);
    /// <summary>
    /// Update a catalog category with the given category ID.
    /// </summary>
    /// <param name="catalogCategoryId">The catalog category ID is a compound ID (string), with format: {integration}:::{catalog}:::{external_id}. Currently, the only supported integration type is $custom, and the only supported catalog is $default.</param>
    /// <param name="catalogCategory"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogCategory>> UpdateCatalogCategory(string catalogCategoryId, CatalogCategory catalogCategory, CancellationToken cancellationToken);
    /// <summary>
    /// Delete a catalog category using the given category ID.
    /// </summary>
    /// <param name="catalogCategoryId">The catalog category ID is a compound ID (string), with format: {integration}:::{catalog}:::{external_id}. Currently, the only supported integration type is $custom, and the only supported catalog is $default.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteCatalogCategory(string catalogCategoryId, CancellationToken cancellationToken);
    /// <summary>
    /// Get all catalog category bulk create jobs.
    /// </summary>
    /// <param name="CatalogCategoryBulkJobFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/reference/api-overview#filtering" />. Allowed fields: status</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<CatalogCategoryBulkJob>> GetCreateCategoriesJobs(List<string> CatalogCategoryBulkJobFields, IFilter filter, CancellationToken cancellationToken);
    /// <summary>
    /// Create a catalog category bulk create job to create a batch of catalog categories. Accepts up to 100 catalog categories per request. The maximum allowed payload size is 4MB.
    /// </summary>
    /// <param name="catalogCategoryBulkJob"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogCategoryBulkJob>> SpawnCreateCategoriesJob(CatalogCategoryBulkJob catalogCategoryBulkJob, CancellationToken cancellationToken);
    /// <summary>
    /// Get a catalog category bulk create job with the given job ID. An include parameter can be provided to get the following related resource data: categories.
    /// </summary>
    /// <param name="catalogCategoryBulkJobId">ID of the job to retrieve.</param>
    /// <param name="CatalogCategoryBulkJobFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="CatalogCategoryFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="includedRecords">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#relationships</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogCategoryBulkJob>> GetCreateCategoriesJob(string catalogCategoryBulkJobId, List<string> CatalogCategoryBulkJobFields, List<string> CatalogCategoryFields, List<string> includedRecords, CancellationToken cancellationToken);
    /// <summary>
    /// Get all catalog category bulk update jobs.
    /// </summary>
    /// <param name="CatalogCategoryBulkJobFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/reference/api-overview#filtering" />. Allowed fields: status</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<CatalogCategoryBulkJob>> GetUpdateCategoriesJobs(List<string> CatalogCategoryBulkJobFields, IFilter filter, CancellationToken cancellationToken);
    /// <summary>
    /// Create a catalog category bulk update job to update a batch of catalog categories. Accepts up to 100 catalog categories per request. The maximum allowed payload size is 4MB.
    /// </summary>
    /// <param name="catalogCategoryBulkJob"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogCategoryBulkJob>> SpawnUpdateCategoriesJob(CatalogCategoryBulkJob catalogCategoryBulkJob, CancellationToken cancellationToken);
    /// <summary>
    /// Get a catalog category bulk update job with the given job ID. An include parameter can be provided to get the following related resource data: categories.
    /// </summary>
    /// <param name="catalogCategoryBulkJobId">ID of the job to retrieve.</param>
    /// <param name="CatalogCategoryBulkJobFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="CatalogCategoryFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="includedRecords">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#relationships</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogCategoryBulkJob>> GetUpdateCategoriesJob(string catalogCategoryBulkJobId, List<string> CatalogCategoryBulkJobFields, List<string> CatalogCategoryFields, List<string> includedRecords, CancellationToken cancellationToken);
    /// <summary>
    /// Get all catalog category bulk delete jobs.
    /// </summary>
    /// <param name="CatalogCategoryBulkJobFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/reference/api-overview#filtering" />. Allowed fields: status</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<CatalogCategoryBulkJob>> GetDeleteCategoriesJobs(List<string> CatalogCategoryBulkJobFields, IFilter filter, CancellationToken cancellationToken);
    /// <summary>
    /// Create a catalog category bulk delete job to delete a batch of catalog categories. Accepts up to 100 catalog categories per request. The maximum allowed payload size is 4MB.
    /// </summary>
    /// <param name="catalogCategoryBulkJob"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogCategoryBulkJob>> SpawnDeleteCategoriesJob(CatalogCategoryBulkJob catalogCategoryBulkJob, CancellationToken cancellationToken);
    /// <summary>
    /// Get a catalog category bulk delete job with the given job ID.
    /// </summary>
    /// <param name="catalogCategoryBulkJobId">ID of the job to retrieve.</param>
    /// <param name="CatalogCategoryBulkJobFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="includedRecords"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CatalogCategoryBulkJob>> GetDeleteCategoriesJob(string catalogCategoryBulkJobId, List<string> CatalogCategoryBulkJobFields, List<string> includedRecords, CancellationToken cancellationToken);
    /// <summary>
    /// Get all catalog categories that an item with the given item ID is in. Catalog categories can be sorted by the following fields, in ascending and descending order: created
    /// </summary>
    /// <param name="catalogItemId"></param>
    /// <param name="catalogCategoryFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/reference/api-overview#filtering" />. Allowed fields: ids, item, name</param>
    /// <param name="sort">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sorting</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<CatalogCategory>> GetCatalogItemCategories(string catalogItemId, List<string> catalogCategoryFields, IFilter filter, string sort, CancellationToken cancellationToken);



    /// <summary>
    /// Get all items in the given category ID.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<GenericObject>> GetCatalogCategoryRelationshipsItems(string id, CancellationToken cancellationToken);
    /// <summary>
    /// Create a new item relationship for the given category ID.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="relationships"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CreateCatalogCategoryRelationshipsItems(string id, DataListObject<GenericObject> relationships, CancellationToken cancellationToken);
    /// <summary>
    /// Update item relationships for the given category ID.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="relationships"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateCatalogCategoryRelationshipsItems(string id, DataListObject<GenericObject> relationships, CancellationToken cancellationToken);
    /// <summary>
    /// Delete item relationships for the given category ID.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="relationships"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteCatalogCategoryRelationshipsItems(string id, DataListObject<GenericObject> relationships, CancellationToken cancellationToken);
    /// <summary>
    /// Get all catalog categories that a particular item is in.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<GenericObject>> GetCatalogItemRelationshipsCategories(string id, CancellationToken cancellationToken);
    /// <summary>
    /// Create a new catalog category relationship for the given item ID.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="relationships"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CreateCatalogItemRelationshipsCategories(string id, DataListObject<GenericObject> relationships, CancellationToken cancellationToken);
    /// <summary>
    /// Update catalog category relationships for the given item ID.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="relationships"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateCatalogItemRelationshipsCategories(string id, DataListObject<GenericObject> relationships, CancellationToken cancellationToken);
    /// <summary>
    /// Delete catalog category relationships for the given item ID.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="relationships"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteCatalogItemRelationshipsCategories(string id, DataListObject<GenericObject> relationships, CancellationToken cancellationToken);
}