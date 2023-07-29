using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Infrastructure;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;
/// <summary>
/// Services for interacting with the Klaviyo Segments API
/// </summary>
public class SegmentServices : KlaviyoServiceBase, ISegmentServices
{
    /// <summary>
    /// Creates a new instance of the Segment Services class.
    /// </summary>
    /// <param name="revision"></param>
    /// <param name="klaviyoService"></param>
    public SegmentServices(string revision, KlaviyoApiBase klaviyoService) : base(revision, klaviyoService) { }
    /// <inheritdoc/>
    public async Task<DataListObject<Segment>> GetSegments(List<string> segmentFields = null, IFilter filter = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("segment", segmentFields);
        query.AddFilter(filter);
        return await _klaviyoService.HTTPRecursive<Segment>(HttpMethod.Get, $"segments/", _revision, query, null, null, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DataObject<Segment>> GetSegment(string segmentId, List<string> segmentFields = null, List<string> additionalFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("segment", segmentFields);
        query.AddAdditionalFields("segment", additionalFields);
        return await _klaviyoService.HTTP<DataObject<Segment>>(HttpMethod.Get, $"segments/{segmentId}/", _revision, query, null, null, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DataObject<Segment>> UpdateSegment(string segmentId, Segment segment, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<Segment>>(new("PATCH"), $"segments/{segmentId}/", _revision, null, null, new DataObject<Segment>(segment), cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DataListObject<Tag>> GetSegmentTags(string segmentId, List<string> tagFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("tag", tagFields);
        return await _klaviyoService.HTTP<DataListObject<Tag>>(HttpMethod.Get, $"segments/{segmentId}/tags/", _revision, query, null, null, cancellationToken);

    }

    /// <inheritdoc/>
    public async Task<DataListObject<Profile>> GetSegmentProfiles(string segmentId, List<string> profileAdditionalFields = null, List<string> profileFields = null, IFilter filter = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddAdditionalFields("profile", profileAdditionalFields);
        query.AddFieldset("profile", profileFields);
        query.AddFilter(filter);
        return await _klaviyoService.HTTPRecursive<Profile>(HttpMethod.Get, $"segments/{segmentId}/profiles/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<GenericObject>> GetSegmentRelationshipsTags(string id, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataListObject<GenericObject>>(HttpMethod.Get, $"segments/{id}/relationships/tags/", _revision, null, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<GenericObject>> GetSegmentRelationshipsProfiles(string id, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataListObject<GenericObject>>(HttpMethod.Get, $"segments/{id}/relationships/profiles/", _revision, null, null, null, cancellationToken);
    }

}
