namespace KlaviyoSharp.Models;

/// <summary>
/// Profiles Merge returned from the Klaviyo API
/// </summary>
public class ProfileMerge : GenericObject
{
    /// <summary>
    /// 
    /// </summary>
    public ProfileMerge() : base() { }
    /// <inheritdoc/>
    public ProfileMerge(string type, string id) : base(type, id) { }

    /// <summary>
    /// Creates a new instance of the Profile Merge class
    /// </summary>
    /// <returns></returns>
    public static ProfileMerge Create() => new() { Type = "profile-merge" };
}

/// <summary>
/// Profile Merge Request
/// </summary>
public class ProfileMergeRequest : ProfileMerge
{
    /// <inheritdoc/>
    public ProfileMergeRequest() : base() { }
    /// <inheritdoc/>
    public ProfileMergeRequest(string type, string id) : base(type, id) { }
    /// <summary>
    /// Creates a new instance of the Profile Merge Request class
    /// </summary>
    /// <returns></returns>
    public static new ProfileMergeRequest Create() => new() { Type = "profile-merge" };

    /// <summary>
    /// Lists associated with the Profile Merge
    /// </summary>
    public ProfileMergeRelationships Relationships { get; set; } = new();
}
/// <summary>
/// Profile Merge Relationships
/// </summary>
public class ProfileMergeRelationships
{
    /// <summary>
    /// Creates a new instance of the ProfileMergeRelationships class
    /// </summary>
    public ProfileMergeRelationships() {
        Profiles.Data = new();
    }
    /// <summary>
    /// Creates a new instance of the ProfileMergeRelationships class with the provided data
    /// </summary>
    /// <param name="data"></param>
    public ProfileMergeRelationships(List<GenericObject> data)
    {
        Profiles.Data = data;
    }
    /// <summary>
    /// 
    /// </summary>
    public DataObject<List<GenericObject>> Profiles { get; set; } = new();

}
