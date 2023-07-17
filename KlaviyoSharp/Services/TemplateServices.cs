using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Infrastructure;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;
/// <summary>
/// Template Services
/// </summary>
public class TemplateServices : KlaviyoServiceBase, ITemplateServices
{
    /// <summary>
    /// Creates a new instance of the TemplateServices class
    /// </summary>
    /// <param name="klaviyoService"></param>
    public TemplateServices(KlaviyoApiBase klaviyoService) : base("2023-06-15", klaviyoService) { }

    /// <inheritdoc />
    public async Task<DataListObject<Template>> GetTemplates(List<string> templateFields = null, IFilter filter = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("template", templateFields);
        query.AddFilters(filter);
        query.AddSort(sort);
        return await _klaviyoService.HTTPRecursive<Template>(HttpMethod.Get, "templates/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<Template>> CreateTemplate(Template template, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<Template>>(HttpMethod.Post, "templates/", _revision, null, null, new DataObject<Template>(template), cancellationToken);
    }

    /// <inheritdoc />
    public async Task<DataObject<Template>> GetTemplate(string templateId, List<string> templateFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("template", templateFields);
        return await _klaviyoService.HTTP<DataObject<Template>>(HttpMethod.Get, $"templates/{templateId}/", _revision, query, null, null, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<DataObject<Template>> UpdateTemplate(string templateId, Template template, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<Template>>(new("PATCH"), $"templates/{templateId}/", _revision, null, null, new DataObject<Template>(template), cancellationToken);
    }

    /// <inheritdoc />
    public async Task DeleteTemplate(string templateId, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Delete, $"templates/{templateId}/", _revision, null, null, null, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<DataObject<Template>> CreateTemplateRender(Template template, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<Template>>(HttpMethod.Post, "template-render/", _revision, null, null, new DataObject<Template>(template), cancellationToken);
    }

    /// <inheritdoc />
    public async Task<DataObject<Template>> CreateTemplateClone(Template template, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<Template>>(HttpMethod.Post, "template-clone/", _revision, null, null, new DataObject<Template>(template), cancellationToken);
    }
}
