namespace KlaviyoSharp.Models;

/// <summary>
/// Klaviyo Profile Bulk Import Job
/// </summary>
public class ProfileBulkImportJob : KlaviyoObject<ProfileBulkImportJobAttributes, ProfileBulkImportJobRelationships>
{
    /// <summary>
    /// Creates a new Profile Bulk Import Job with default values
    /// </summary>
    /// <returns></returns>
    public static new ProfileBulkImportJob Create()
    {
        return new() { Type = "profile-bulk-import-job" };
    }
}

/// <summary>
/// Klaviyo Profile Bulk Import Job Request
/// </summary>
public class ProfileBulkImportJobRequest
{
    /// <summary>
    /// Generic Constructor
    /// </summary>
    public ProfileBulkImportJobRequest() { }
    /// <summary>
    /// Constructor for Profile Bulk Import Job from existing Profiles
    /// </summary>
    /// <param name="profiles"></param>
    public ProfileBulkImportJobRequest(List<Profile> profiles)
    {
        Profiles = new()
        {
            Data = profiles
        };
    }
    /// <summary>
    /// Creates a new instance of the Klaviyo Profile with default values
    /// </summary>
    /// <returns></returns>
    public static new PatchProfile Create() => new() { Type = "profile-bulk-import-job" };

    /// <summary>
    /// Lists associated with the Job
    /// </summary>
    public DataListObject<Profile> Profiles { get; set; }
}

/// <summary>
/// Profile Bulk Import Job Relationships
/// </summary>
public class ProfileBulkImportJobRelationships
{
    /// <summary>
    /// Lists associated with the Job
    /// </summary>
    public DataListObjectRelated<GenericObject> Lists { get; set; }
    /// <summary>
    /// Profiles associated with this Job
    /// </summary>
    public DataListObject<GenericObject> Profiles { get; set; }
    /// <summary>
    /// Import Errors associated with this Job
    /// </summary>
    public DataListObject<GenericObject> ImportErrors { get; set; }
}

/// <summary>
/// Profile Bulk Import Job Relationships - Profiles
/// </summary>
public class ProfileBulkImportJobRelationshipProfiles
{
    /// <inheritdoc/>
    public Links.RelatedLink Links { get; set; }
}

/// <summary>
/// Profile Bulk Import Job Relationships - Import Errors
/// </summary>
public class ProfileBulkImportJobRelationshipImportErrors
{
    /// <inheritdoc/>
    public Links.RelatedLink Links { get; set; }
}

/// <summary>
/// Profile Bulk Import Job Attributes
/// </summary>
public class ProfileBulkImportJobAttributes
{
    /// <summary>
    /// Status of the asynchronous job.
    /// </summary>
    public string Status { get; set; }
    /// <summary>
    /// The date and time the job was created in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm).
    /// </summary>
    public DateTime? CreatedAt { get; set; }
    /// <summary>
    /// The total number of operations to be processed by the job. See <see cref="CompletedCount"/> for the job's current progress.
    /// </summary>
    public int TotalCount { get; set; }
    /// <summary>
    /// The total number of operations that have been completed by the job.
    /// </summary>
    public int CompletedCount { get; set; }
    /// <summary>
    /// The total number of operations that have failed as part of the job.
    /// </summary>
    public int FailedCount { get; set; }
    /// <summary>
    /// Date and time the job was completed in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm).
    /// </summary>
    public DateTime? CompletedAt { get; set; }
    /// <summary>
    /// Date and time the job expires in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm).
    /// </summary>
    public DateTime? ExpiresAt { get; set; }
    /// <summary>
    /// Date and time the job started processing in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm).
    /// </summary>
    public DateTime? StartedAt { get; set; }
}