using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Infrastructure;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;
using System.Linq;

namespace KlaviyoSharp.Services;
/// <summary>
/// Klaviyo List Services
/// </summary>
public class ListServices : KlaviyoServiceBase, IListServices
{
    /// <summary>
    /// Constructor for Klaviyo List Services
    /// </summary>
    /// <param name="klaviyoService"></param>
    public ListServices(KlaviyoApiBase klaviyoService) : base("2023-06-15", klaviyoService) { }
    /// <inheritdoc />
    public async Task<DataListObject<List>> GetLists(List<string> listFields = null, IFilter filter = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("list", listFields);
        query.AddFilter(filter);

        DataListObject<List> output = new(new());
        string pageCursor = "";
        DataListObject<List> response;
        query.Add("page[cursor]", pageCursor);
        do
        {
            query["page[cursor]"] = pageCursor;
            response = await _klaviyoService.HTTP<DataListObject<List>>(HttpMethod.Get, "lists/", _revision, query, null, null, cancellationToken);
            output.Data.AddRange(response.Data);
            new QueryParams(response.Links.Next)?.TryGetValue("page[cursor]", out pageCursor);
        } while (response.Links.Next != null);
        return output;
    }
    /// <inheritdoc />
    public async Task<DataObject<List>> GetList(string id, List<string> listFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("list", listFields);
        return await _klaviyoService.HTTP<DataObject<List>>(HttpMethod.Get, $"lists/{id}/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<List>> CreateList(List list, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<List>>(HttpMethod.Post, "lists/", _revision, null, null, new DataObject<List>(list), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<List>> UpdateList(string id, List listAttributes, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<List>>(new("PATCH"), $"lists/{id}/", _revision, null, null, new DataObject<List>(listAttributes), cancellationToken);
    }
    /// <inheritdoc />
    public async Task DeleteList(string id, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Delete, $"lists/{id}/", _revision, null, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<Tag>> GetListTags(string id, List<string> listFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("tag", listFields);
        return await _klaviyoService.HTTP<DataListObject<Tag>>(HttpMethod.Get, $"lists/{id}/tags/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task AddProfileToList(string id, List<string> profileId, CancellationToken cancellationToken = default)
    {
        DataListObject<GenericObject> dataObjects = new(new());
        profileId.ForEach(profileId => dataObjects.Data.Add(new() { Type = "profile", Id = profileId }));
        await _klaviyoService.HTTP(HttpMethod.Post, $"lists/{id}/relationships/profiles/", _revision, null, null, dataObjects, cancellationToken);
    }

    /// <inheritdoc />
    public async Task RemoveProfileFromList(string id, List<string> profileId, CancellationToken cancellationToken = default)
    {
        DataListObject<GenericObject> dataObjects = new(new());
        profileId.ForEach(profileId => dataObjects.Data.Add(new() { Type = "profile", Id = profileId }));
        await _klaviyoService.HTTP(HttpMethod.Delete, $"lists/{id}/relationships/profiles/", _revision, null, null, dataObjects, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<DataListObject<Profile>> GetListProfiles(string id, List<string> profileFields = null, List<string> additionalFields = null, IFilter filter = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("profile", profileFields);
        query.AddFilter(filter);
        query.AddAdditionalFields("profile", additionalFields);

        DataListObject<Profile> output = new(new());
        string pageCursor = "";
        DataListObject<Profile> response;
        query.Add("page[cursor]", pageCursor);
        do
        {
            query["page[cursor]"] = pageCursor;
            response = await _klaviyoService.HTTP<DataListObject<Profile>>(HttpMethod.Get, $"lists/{id}/profiles/", _revision, query, null, null, cancellationToken);
            output.Data.AddRange(response.Data);
            new QueryParams(response.Links.Next)?.TryGetValue("page[cursor]", out pageCursor);
        } while (response.Links.Next != null);
        return output;
    }
    /// <inheritdoc />
    public async Task<DataListObject<GenericObject>> GetListRelationshipsTags(string id, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataListObject<GenericObject>>(HttpMethod.Get, $"lists/{id}/relationships/tags/", _revision, null, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<GenericObject>> GetListRelationshipsProfiles(string id, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataListObject<GenericObject>>(HttpMethod.Get, $"lists/{id}/relationships/profiles/", _revision, null, null, null, cancellationToken);
    }


}
