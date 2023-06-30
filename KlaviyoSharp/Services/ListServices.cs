using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Infrastructure;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;

public class ListServices : KlaviyoServiceBase, IListServices
{
    public ListServices(KlaviyoApiBase klaviyoService) : base("2023-06-15", klaviyoService) { }
    /// <inheritdoc />
    public async Task<List<DataObject<ListAttributes>>> GetLists(List<string> listFields = null, IFilter filter = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("list", listFields);
        query.AddFilters(filter);

        List<DataObject<ListAttributes>> output = new();
        string pageCursor = "";
        ResponseBody<List<DataObject<ListAttributes>>> response;
        query.Add("page[cursor]", pageCursor);
        do
        {
            query["page[cursor]"] = pageCursor;
            response = await _klaviyoService.HTTP<ResponseBody<List<DataObject<ListAttributes>>>>(HttpMethod.Get, "lists/", _revision, query, null, null, cancellationToken);
            output.AddRange(response.Data);
            pageCursor = new QueryParams(response.Links.Next).GetValueOrDefault("page[cursor]");
        } while (response.Links.Next != null);
        return output;
    }
    /// <inheritdoc />
    public async Task<DataObject<ListAttributes>> GetList(string id, List<string> listFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("list", listFields);
        return (await _klaviyoService.HTTP<ResponseBody<DataObject<ListAttributes>>>(HttpMethod.Get, $"lists/{id}/", _revision, query, null, null, cancellationToken)).Data;
    }
    /// <inheritdoc />
    public async Task<DataObject<ListAttributes>> CreateList(ListAttributes listAttributes, CancellationToken cancellationToken = default)
    {
        return (await _klaviyoService.HTTP<ResponseBody<DataObject<ListAttributes>>>(HttpMethod.Post, "lists/", _revision, null, null, new DataObject<ListAttributes>("list", listAttributes), cancellationToken)).Data;
    }
    /// <inheritdoc />
    public async Task<DataObject<ListAttributes>> UpdateList(string id, ListAttributes listAttributes, CancellationToken cancellationToken = default)
    {
        return (await _klaviyoService.HTTP<ResponseBody<DataObject<ListAttributes>>>(HttpMethod.Patch, $"lists/{id}/", _revision, null, null, new DataObject<ListAttributes>("list", id, listAttributes), cancellationToken)).Data;
    }
    /// <inheritdoc />
    public async Task DeleteList(string id, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Delete, $"lists/{id}/", _revision, null, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<List<DataObject<TagAttributes>>> GetListTags(string id, List<string> listFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("tag", listFields);
        return (await _klaviyoService.HTTP<ResponseBody<List<DataObject<TagAttributes>>>>(HttpMethod.Get, $"lists/{id}/tags/", _revision, query, null, null, cancellationToken)).Data;
    }
    /// <inheritdoc />
    public async Task AddProfileToList(string id, List<string> profileId, CancellationToken cancellationToken = default)
    {
        List<DataObject> dataObjects = new();
        profileId.ForEach(x => dataObjects.Add(new DataObject("profile", x)));
        await _klaviyoService.HTTP(HttpMethod.Post, $"lists/{id}/relationships/profiles/", _revision, null, null, dataObjects, cancellationToken);
    }

    /// <inheritdoc />
    public async Task RemoveProfileFromList(string id, List<string> profileId, CancellationToken cancellationToken = default)
    {
        List<DataObject> dataObjects = new();
        profileId.ForEach(x => dataObjects.Add(new DataObject("profile", x)));
        await _klaviyoService.HTTP(HttpMethod.Delete, $"lists/{id}/relationships/profiles/", _revision, null, null, dataObjects, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<List<DataObject<ProfileAttributes>>> GetListProfiles(string id, List<string> profileFields = null, List<string> additionalFields = null, IFilter filter = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("profile", profileFields);
        query.AddFilters(filter);
        query.AddAdditionalFields("profile", additionalFields);

        List<DataObject<ProfileAttributes>> output = new();
        string pageCursor = "";
        ResponseBody<List<DataObject<ProfileAttributes>>> response;
        query.Add("page[cursor]", pageCursor);
        do
        {
            query["page[cursor]"] = pageCursor;
            response = await _klaviyoService.HTTP<ResponseBody<List<DataObject<ProfileAttributes>>>>(HttpMethod.Get, $"lists/{id}/profiles/", _revision, query, null, null, cancellationToken);
            output.AddRange(response.Data);
            pageCursor = new QueryParams(response.Links.Next).GetValueOrDefault("page[cursor]");
        } while (response.Links.Next != null);
        return output;
    }
/// <inheritdoc />
    public async Task<List<DataObject>> GetListRelationshipsTags(string id, CancellationToken cancellationToken = default)
    {
        return (await _klaviyoService.HTTP<ResponseBody<List<DataObject>>>(HttpMethod.Get, $"lists/{id}/relationships/tags/", _revision, null, null, null, cancellationToken)).Data;
    }
/// <inheritdoc />
    public async Task<List<DataObject>> GetListRelationshipsProfiles(string id, CancellationToken cancellationToken = default)
    {
        return (await _klaviyoService.HTTP<ResponseBody<List<DataObject>>>(HttpMethod.Get, $"lists/{id}/relationships/profiles/", _revision, null, null, null, cancellationToken)).Data;
    }


}
