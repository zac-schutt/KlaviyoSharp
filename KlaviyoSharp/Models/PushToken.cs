namespace KlaviyoSharp.Models;

/// <summary>
/// Klaviyo Push Token
/// </summary>
public class PushToken : KlaviyoObject<PushTokenAttributes>
{
    /// <summary>
    /// Creates a new instance of a Klaviyo Push Token with the Type property set to "push-token"
    /// </summary>
    /// <returns></returns>
    public static new PushToken Create() => new() { Type = "push-token" };
}

/// <summary>
/// Klaviyo Push Token Attributes
/// </summary>
public class PushTokenAttributes
{
    /// <summary>
    /// A push token from APNS or FCM.
    /// </summary>
    public string Token { get; set; }
    /// <summary>
    /// The platform on which the push token was created.
    /// </summary>
    public string Platform { get; set; }
    /// <summary>
    /// This is the enablement status for the individual push token.
    /// </summary>
    public string EnablementStatus { get; set; }
    /// <summary>
    /// The vendor of the push token.
    /// </summary>
    public string Vendor { get; set; }
    /// <summary>
    /// The background state of the push token.
    /// </summary>
    public string Background { get; set; }
    /// <summary>
    /// Metadata about the device that created the push token
    /// </summary>
    public PushTokenDeviceMetadata DeviceMetadata { get; set; }
    /// <summary>
    /// The profile associated with the push token to create/update
    /// </summary>
    public DataObject<Profile> Profile { get; set; }
}

/// <summary>
/// Metadata about the device that created the push token
/// </summary>
public class PushTokenDeviceMetadata
{
    /// <summary>
    /// Relatively stable ID for the device. Will update on app uninstall and reinstall
    /// </summary>
    public string DeviceId { get; set; }
    /// <summary>
    /// The name of the SDK used to create the push token.
    /// </summary>
    public string KlaviyoSdk { get; set; }
    /// <summary>
    /// The version of the SDK used to create the push token
    /// </summary>
    public string SdkVersion { get; set; }
    /// <summary>
    /// The model of the device
    /// </summary>
    public string DeviceModel { get; set; }
    /// <summary>
    /// The name of the operating system on the device.
    /// </summary>
    public string OsName { get; set; }
    /// <summary>
    /// The version of the operating system on the device
    /// </summary>
    public string OsVersion { get; set; }
    /// <summary>
    /// The manufacturer of the device
    /// </summary>
    public string Manufacturer { get; set; }
    /// <summary>
    /// The name of the app that created the push token
    /// </summary>
    public string AppName { get; set; }
    /// <summary>
    /// The version of the app that created the push token
    /// </summary>
    public string AppVersion { get; set; }
    /// <summary>
    /// The build of the app that created the push token
    /// </summary>
    public string AppBuild { get; set; }
    /// <summary>
    /// The ID of the app that created the push token
    /// </summary>
    public string AppId { get; set; }
    /// <summary>
    /// The environment in which the push token was created
    /// </summary>
    public string Environment { get; set; }
}