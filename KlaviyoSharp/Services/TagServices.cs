using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Infrastructure;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;
/// <summary>
/// Tag Services
/// </summary>
public class TagServices : KlaviyoServiceBase, ITagServices
{
    /// <summary>
    /// Creates a new instance of the Tag Services
    /// </summary>
    /// <param name="klaviyoService"></param>
    public TagServices(KlaviyoApiBase klaviyoService) : base("2023-06-15", klaviyoService) { }
    /// <inheritdoc />
    public async Task<DataListObject<Tag>> GetTags(List<string> tagFields = null, IFilter filter = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams queryParams = new();
        queryParams.AddFieldset("tag", tagFields);
        queryParams.AddFilter(filter);
        queryParams.AddSort(sort);
        return await _klaviyoService.HTTPRecursive<Tag>(HttpMethod.Get, "tags/", _revision, queryParams, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<Tag>> CreateTag(Tag tag, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<Tag>>(HttpMethod.Post, "tags/", _revision, null, null, new DataObject<Tag>(tag), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<Tag>> GetTag(string tagId, List<string> tagFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams queryParams = new();
        queryParams.AddFieldset("tag", tagFields);
        return await _klaviyoService.HTTP<DataObject<Tag>>(HttpMethod.Get, $"tags/{tagId}/", _revision, queryParams, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task UpdateTag(string tagId, Tag tag, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(new("PATCH"), $"tags/{tagId}/", _revision, null, null, new DataObject<Tag>(tag), cancellationToken);
    }
    /// <inheritdoc />
    public async Task DeleteTag(string tagId, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Delete, $"tags/{tagId}/", _revision, null, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<TagGroup>> GetTagTagGroup(string tagId, List<string> tagGroupFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams queryParams = new();
        queryParams.AddFieldset("tag-group", tagGroupFields);
        return await _klaviyoService.HTTP<DataObject<TagGroup>>(HttpMethod.Get, $"tags/{tagId}/tag-group/", _revision, queryParams, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<TagGroup>> GetTagGroups(List<string> tagGroupFields = null, IFilter filter = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams queryParams = new();
        queryParams.AddFieldset("tag-group", tagGroupFields);
        queryParams.AddFilter(filter);
        queryParams.AddSort(sort);
        return await _klaviyoService.HTTPRecursive<TagGroup>(HttpMethod.Get, "tag-groups/", _revision, queryParams, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<TagGroup>> CreateTagGroup(TagGroup tagGroup, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<TagGroup>>(HttpMethod.Post, "tag-groups/", _revision, null, null, new DataObject<TagGroup>(tagGroup), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<TagGroup>> GetTagGroup(string tagGroupId, List<string> tagGroupFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams queryParams = new();
        queryParams.AddFieldset("tag-group", tagGroupFields);
        return await _klaviyoService.HTTP<DataObject<TagGroup>>(HttpMethod.Get, $"tag-groups/{tagGroupId}/", _revision, queryParams, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<TagGroup>> UpdateTagGroup(string tagGroupId, TagGroup tagGroup, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<TagGroup>>(new("PATCH"), $"tag-groups/{tagGroupId}/", _revision, null, null, new DataObject<TagGroup>(tagGroup), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<TagGroup>> DeleteTagGroup(string tagGroupId, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<TagGroup>>(HttpMethod.Delete, $"tag-groups/{tagGroupId}/", _revision, null, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<Tag>> GetTagGroupTags(string tagGroupId, List<string> tagFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams queryParams = new();
        queryParams.AddFieldset("tag", tagFields);
        return await _klaviyoService.HTTPRecursive<Tag>(HttpMethod.Get, $"tag-groups/{tagGroupId}/tags/", _revision, queryParams, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<GenericObject>> GetTagRelationshipsFlows(string tagId, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataListObject<GenericObject>>(HttpMethod.Get, $"tags/{tagId}/relationships/flows/", _revision, null, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task CreateTagRelationshipsFlows(string tagId, List<GenericObject> objects, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Post, $"tags/{tagId}/relationships/flows/", _revision, null, null, new DataListObject<GenericObject>(objects), cancellationToken);
    }
    /// <inheritdoc />
    public async Task DeleteTagRelationshipsFlows(string tagId, List<GenericObject> objects, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Delete, $"tags/{tagId}/relationships/flows/", _revision, null, null, new DataListObject<GenericObject>(objects), cancellationToken);
    }

    /// <inheritdoc />
    public async Task<DataListObject<GenericObject>> GetTagRelationshipsCampaigns(string tagId, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataListObject<GenericObject>>(HttpMethod.Get, $"tags/{tagId}/relationships/campaigns/", _revision, null, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task CreateTagRelationshipsCampaigns(string tagId, List<GenericObject> objects, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Post, $"tags/{tagId}/relationships/campaigns/", _revision, null, null, new DataListObject<GenericObject>(objects), cancellationToken);
    }
    /// <inheritdoc />
    public async Task DeleteTagRelationshipsCampaigns(string tagId, List<GenericObject> objects, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Delete, $"tags/{tagId}/relationships/campaigns/", _revision, null, null, new DataListObject<GenericObject>(objects), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<GenericObject>> GetTagRelationshipsLists(string tagId, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataListObject<GenericObject>>(HttpMethod.Get, $"tags/{tagId}/relationships/lists/", _revision, null, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task CreateTagRelationshipsLists(string tagId, List<GenericObject> objects, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Post, $"tags/{tagId}/relationships/lists/", _revision, null, null, new DataListObject<GenericObject>(objects), cancellationToken);
    }
    /// <inheritdoc />
    public async Task DeleteTagRelationshipsLists(string tagId, List<GenericObject> objects, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Delete, $"tags/{tagId}/relationships/lists/", _revision, null, null, new DataListObject<GenericObject>(objects), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<GenericObject>> GetTagRelationshipsSegments(string tagId, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataListObject<GenericObject>>(HttpMethod.Get, $"tags/{tagId}/relationships/segments/", _revision, null, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task CreateTagRelationshipsSegments(string tagId, List<GenericObject> objects, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Post, $"tags/{tagId}/relationships/segments/", _revision, null, null, new DataListObject<GenericObject>(objects), cancellationToken);
    }
    /// <inheritdoc />
    public async Task DeleteTagRelationshipsSegments(string tagId, List<GenericObject> objects, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Delete, $"tags/{tagId}/relationships/segments/", _revision, null, null, new DataListObject<GenericObject>(objects), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<GenericObject>> GetTagRelationshipsTagGroups(string tagId, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataListObject<GenericObject>>(HttpMethod.Get, $"tags/{tagId}/relationships/tag-groups/", _revision, null, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<GenericObject>> GetTagGroupRelationshipsTags(string tagGroupId, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataListObject<GenericObject>>(HttpMethod.Get, $"tag-groups/{tagGroupId}/relationships/tags/", _revision, null, null, null, cancellationToken);
    }
}