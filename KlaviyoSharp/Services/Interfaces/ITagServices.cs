using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;
/// <summary>
/// Interface for Klaviyo Tag Services
/// </summary>
public interface ITagServices
{
    /// <summary>
    /// List all tags in an account. Tags can be filtered by name, and sorted by name or id in ascending or descending order.
    /// </summary>
    /// <param name="tagFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/reference/api-overview#filtering" />. Allowed fields: name</param>
    /// <param name="sort">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sorting</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<Tag>> GetTags(List<string> tagFields, IFilter filter, string sort, CancellationToken cancellationToken);
    /// <summary>
    /// Create a tag. An account cannot have more than 500 unique tags. A tag belongs to a single tag group. If the tag_group_id is not specified, the tag is added to the account's default tag group.
    /// </summary>
    /// <param name="tag">Tag to create</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Tag>> CreateTag(Tag tag, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieve the tag with the given tag ID.
    /// </summary>
    /// <param name="tagId">The Tag ID</param>
    /// <param name="tagFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Tag>> GetTag(string tagId, List<string> tagFields, CancellationToken cancellationToken);
    /// <summary>
    /// Update the tag with the given tag ID. Only a tag's name can be changed. A tag cannot be moved from one tag group to another.
    /// </summary>
    /// <param name="tagId">The Tag ID</param>
    /// <param name="tag">Tag Object</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateTag(string tagId, Tag tag, CancellationToken cancellationToken);
    /// <summary>
    /// Delete the tag with the given tag ID. Any associations between the tag and other resources will also be removed.
    /// </summary>
    /// <param name="tagId">The Tag ID</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteTag(string tagId, CancellationToken cancellationToken);
    /// <summary>
    /// Returns the tag group resource for a given tag ID.
    /// </summary>
    /// <param name="tagId">The Tag ID</param>
    /// <param name="tagGroupFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<TagGroup>> GetTagTagGroup(string tagId, List<string> tagGroupFields, CancellationToken cancellationToken);
    /// <summary>
    /// ist all tag groups in an account. Every account has one default tag group. Tag groups can be filtered by name, exclusive, and default, and sorted by name or id in ascending or descending order.
    /// </summary>
    /// <param name="tagGroupFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/reference/api-overview#filtering" />. Allowed fields: name, default, exclusive</param>
    /// <param name="sort">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sorting</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<TagGroup>> GetTagGroups(List<string> tagGroupFields, IFilter filter, string sort, CancellationToken cancellationToken);
    /// <summary>
    /// Create a tag group. An account cannot have more than 50 unique tag groups. If exclusive is not specified true or false, the tag group defaults to non-exclusive. If a tag group is non-exclusive, any given related resource (campaign, flow, etc.) can be linked to multiple tags from that tag group. If a tag group is exclusive, any given related resource can only be linked to one tag from that tag group.
    /// </summary>
    /// <param name="tagGroup"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<TagGroup>> CreateTagGroup(TagGroup tagGroup, CancellationToken cancellationToken);
    /// <summary>
    /// Retrieve the tag group with the given tag group ID.
    /// </summary>
    /// <param name="tagGroupId">The Tag Group ID</param>
    /// <param name="tagGroupFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<TagGroup>> GetTagGroup(string tagGroupId, List<string> tagGroupFields, CancellationToken cancellationToken);
    /// <summary>
    /// Update the tag group with the given tag group ID. Only a tag group's name can be changed. A tag group's exclusive or default value cannot be changed.
    /// </summary>
    /// <param name="tagGroupId">The Tag Group ID</param>
    /// <param name="tagGroup"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<TagGroup>> UpdateTagGroup(string tagGroupId, TagGroup tagGroup, CancellationToken cancellationToken);
    /// <summary>
    /// Delete the tag group with the given tag group ID. Any tags inside that tag group, and any associations between those tags and other resources, will also be removed. The default tag group cannot be deleted.
    /// </summary>
    /// <param name="tagGroupId">The Tag Group ID</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<TagGroup>> DeleteTagGroup(string tagGroupId, CancellationToken cancellationToken);
    /// <summary>
    /// Return the tags for a given tag group ID.
    /// </summary>
    /// <param name="tagGroupId"></param>
    /// <param name="tagFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<Tag>> GetTagGroupTags(string tagGroupId, List<string> tagFields, CancellationToken cancellationToken);
    /// <summary>
    /// Returns the IDs of all flows associated with the given tag.
    /// </summary>
    /// <param name="tagId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<GenericObject>> GetTagRelationshipsFlows(string tagId, CancellationToken cancellationToken);
    /// <summary>
    ///Associate a tag with one or more flows. Any flow cannot be associated with more than 100 tags.
    /// </summary>
    /// <param name="tagId"></param>
    /// <param name="objects">Use the request body to pass in the ID(s) of the flow(s) that will be associated with the tag.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CreateTagRelationshipsFlows(string tagId, List<GenericObject> objects, CancellationToken cancellationToken);
    /// <summary>
    /// Remove a tag's association with one or more flows.
    /// </summary>
    /// <param name="tagId"></param>
    /// <param name="objects">Use the request body to pass in the ID(s) of the flows(s) whose association with the tag will be removed.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteTagRelationshipsFlows(string tagId, List<GenericObject> objects, CancellationToken cancellationToken);

    /// <summary>
    /// Returns the IDs of all Campaigns associated with the given tag.
    /// </summary>
    /// <param name="tagId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<GenericObject>> GetTagRelationshipsCampaigns(string tagId, CancellationToken cancellationToken);
    /// <summary>
    ///Associate a tag with one or more Campaigns. Any Campaigns cannot be associated with more than 100 tags.
    /// </summary>
    /// <param name="tagId"></param>
    /// <param name="objects">Use the request body to pass in the ID(s) of the Campaigns(s) that will be associated with the tag.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CreateTagRelationshipsCampaigns(string tagId, List<GenericObject> objects, CancellationToken cancellationToken);
    /// <summary>
    /// Remove a tag's association with one or more Campaigns.
    /// </summary>
    /// <param name="tagId"></param>
    /// <param name="objects">Use the request body to pass in the ID(s) of the Campaigns(s) whose association with the tag will be removed.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteTagRelationshipsCampaigns(string tagId, List<GenericObject> objects, CancellationToken cancellationToken);

    /// <summary>
    /// Returns the IDs of all Lists associated with the given tag.
    /// </summary>
    /// <param name="tagId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<GenericObject>> GetTagRelationshipsLists(string tagId, CancellationToken cancellationToken);
    /// <summary>
    ///Associate a tag with one or more Lists. Any Lists cannot be associated with more than 100 tags.
    /// </summary>
    /// <param name="tagId"></param>
    /// <param name="objects">Use the request body to pass in the ID(s) of the Lists(s) that will be associated with the tag.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CreateTagRelationshipsLists(string tagId, List<GenericObject> objects, CancellationToken cancellationToken);
    /// <summary>
    /// Remove a tag's association with one or more Lists.
    /// </summary>
    /// <param name="tagId"></param>
    /// <param name="objects">Use the request body to pass in the ID(s) of the Lists(s) whose association with the tag will be removed.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteTagRelationshipsLists(string tagId, List<GenericObject> objects, CancellationToken cancellationToken);

    /// <summary>
    /// Returns the IDs of all Segments associated with the given tag.
    /// </summary>
    /// <param name="tagId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<GenericObject>> GetTagRelationshipsSegments(string tagId, CancellationToken cancellationToken);
    /// <summary>
    ///Associate a tag with one or more Segments. Any Segments cannot be associated with more than 100 tags.
    /// </summary>
    /// <param name="tagId"></param>
    /// <param name="objects">Use the request body to pass in the ID(s) of the Segments(s) that will be associated with the tag.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CreateTagRelationshipsSegments(string tagId, List<GenericObject> objects, CancellationToken cancellationToken);
    /// <summary>
    /// Remove a tag's association with one or more Segments.
    /// </summary>
    /// <param name="tagId"></param>
    /// <param name="objects">Use the request body to pass in the ID(s) of the Segments(s) whose association with the tag will be removed.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteTagRelationshipsSegments(string tagId, List<GenericObject> objects, CancellationToken cancellationToken);
    /// <summary>
    /// Returns the ids of all tag groups related to the given tag.
    /// </summary>
    /// <param name="tagId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<GenericObject>> GetTagRelationshipsTagGroups(string tagId, CancellationToken cancellationToken);
    /// <summary>
    /// Returns the tag IDs of all tags inside the given tag group.
    /// </summary>
    /// <param name="tagGroupId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<GenericObject>> GetTagGroupRelationshipsTags(string tagGroupId, CancellationToken cancellationToken);
}