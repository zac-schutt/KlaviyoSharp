namespace KlaviyoSharp.Models;

public class Location
{
    /// <summary>
    /// First line of street address
    /// </summary>
    public string address1 { get; set; }
    /// <summary>
    /// First line of street address
    /// </summary>
    public string address2 { get; set; }
    /// <summary>
    /// City name
    /// </summary>
    public string city { get; set; }
    /// <summary>
    /// Country name
    /// </summary>
    public string country { get; set; }
    /// <summary>
    /// Latitude coordinate. We recommend providing a precision of four decimal places.
    /// </summary>
    public decimal? latitude { get; set; }
    /// <summary>
    /// Longitude coordinate. We recommend providing a precision of four decimal places.
    /// </summary>
    public decimal? longitude { get; set; }
    /// <summary>
    /// Region within a country, such as state or province
    /// </summary>
    public string region { get; set; }
    /// <summary>
    /// Zip code
    /// </summary>
    public string zip { get; set; }
    /// <summary>
    /// Time zone name. We recommend using time zones from the IANA Time Zone Database.
    /// </summary>
    public string timezone { get; set; }
}