using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;

/// <summary>
/// Services for interacting with the Klaviyo Segments API
/// </summary>
public interface ISegmentServices
{
    /// <summary>
    /// Get all segments in an account. Filter to request a subset of all segments. Segments can be filtered by name, created, and updated fields.
    /// </summary>
    /// <param name="segmentFields">For more information please visit https://developers.klaviyo.com/en/v2023-06-15/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/v2023-06-15/reference/api-overview#filtering" />. Allowed fields: name, id, created, updated</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<Segment>> GetSegments(List<string> segmentFields, IFilter filter, CancellationToken cancellationToken);
    /// <summary>
    /// Get a segment with the given segment ID.
    /// </summary>
    /// <param name="segmentId">The ID of the segment to retrieve.</param>
    /// <param name="segmentFields">For more information please visit https://developers.klaviyo.com/en/v2023-06-15/reference/api-overview#sparse-fieldsets</param>
    /// <param name="additionalFields">Request additional fields not included by default in the response. Supported values: 'profile_count'. Heavily rate limited when used.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Segment>> GetSegment(string segmentId, List<string> segmentFields, List<string> additionalFields, CancellationToken cancellationToken);
    /// <summary>
    /// Update the name of a segment with the given segment ID.
    /// </summary>
    /// <param name="segmentId">The ID of the segment to update.</param>
    /// <param name="segment">The segment data to update.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Segment>> UpdateSegment(string segmentId, Segment segment, CancellationToken cancellationToken);
    /// <summary>
    /// Return all tags associated with the given segment ID.
    /// </summary>
    /// <param name="segmentId">The ID of the segment to retrieve tags for.</param>
    /// <param name="tagFields">For more information please visit https://developers.klaviyo.com/en/v2023-06-15/reference/api-overview#sparse-fieldsets</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<Tag>> GetSegmentTags(string segmentId, List<string> tagFields, CancellationToken cancellationToken);
    /// <summary>
    /// Get all profiles within the given segment ID. Filter to request a subset of all profiles. Profiles can be filtered by email, phone_number, and push_token fields.
    /// </summary>
    /// <param name="segmentId">The ID of the segment to retrieve profiles for.</param>
    /// <param name="profileAdditionalFields">Request additional fields not included by default in the response. Supported values: 'predictive_analytics'</param>
    /// <param name="profileFields">For more information please visit https://developers.klaviyo.com/en/v2023-06-15/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/v2023-06-15/reference/api-overview#filtering" />. Allowed fields: email, phone_number, push_token, _kx</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<Profile>> GetSegmentProfiles(string segmentId, List<string> profileAdditionalFields, List<string> profileFields, IFilter filter, CancellationToken cancellationToken);
    /// <summary>
    /// If related_resource is tags, returns the tag IDs of all tags associated with the given segment ID.
    /// </summary>
    /// <param name="id">The ID of the segment to retrieve tag relationships for.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<GenericObject>> GetSegmentRelationshipsTags(string id, CancellationToken cancellationToken);
    /// <summary>
    /// Get all profile membership relationships for the given segment ID.
    /// </summary>
    /// <param name="id">The ID of the segment to retrieve profile relationships for.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<GenericObject>> GetSegmentRelationshipsProfiles(string id, CancellationToken cancellationToken);

}