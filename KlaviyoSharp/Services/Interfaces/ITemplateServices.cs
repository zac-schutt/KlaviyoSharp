using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;

internal interface ITemplateServices
{
    /// <summary>
    /// Get all templates in an account. Filter to request a subset of all templates. Templates can be sorted by the following fields, in ascending and descending order: id, name, created, updated.
    /// </summary>
    /// <param name="templateFields">For more information please visit https://developers.klaviyo.com/en/v2023-06-15/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/v2023-06-15/reference/api-overview#filtering" />Allowed fields: id, name, created, updated</param>
    /// <param name="sort">For more information please visit https://developers.klaviyo.com/en/v2023-06-15/reference/api-overview#sorting</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<Template>> GetTemplates(List<string> templateFields, IFilter filter, string sort, CancellationToken cancellationToken);


    /// <summary>
    /// Create a new custom HTML template. If there are 1,000 or more templates in an account, creation will fail as there is a limit of 1,000 templates that can be created via the API.
    /// </summary>
    /// <param name="template">The template to create</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Template>> CreateTemplate(Template template, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a template with the given template ID.
    /// </summary>
    /// <param name="templateId">The ID of template</param>
    /// <param name="templateFields">For more information please visit https://developers.klaviyo.com/en/v2023-06-15/reference/api-overview#sparse-fieldsets</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Template>> GetTemplate(string templateId, List<string> templateFields, CancellationToken cancellationToken);

    /// <summary>
    /// Update a template with the given template ID. Does not currently update drag &amp; drop templates.
    /// </summary>
    /// <param name="templateId">The ID of template</param>
    /// <param name="template">The template to update</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Template>> UpdateTemplate(string templateId, Template template, CancellationToken cancellationToken = default);
    /// <summary>
    /// Delete a template with the given template ID.
    /// </summary>
    /// <param name="templateId">The ID of template</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteTemplate(string templateId, CancellationToken cancellationToken);
    /// <summary>
    /// Render a template with the given template ID and context attribute. Returns the HTML and plain text versions of the email template.
    /// </summary>
    /// <param name="template"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Template>> CreateTemplateRender(Template template, CancellationToken cancellationToken);
    /// <summary>
    /// Create a clone of a template with the given template ID.
    /// </summary>
    /// <param name="template">The id of the template to be cloned, and the name of the new template</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Template>> CreateTemplateClone(Template template, CancellationToken cancellationToken);
}