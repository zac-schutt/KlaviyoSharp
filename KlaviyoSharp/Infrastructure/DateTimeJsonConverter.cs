using System;
using Newtonsoft.Json;

namespace KlaviyoSharp.Infrastructure;

/// <summary>
/// Converts a nullable DateTime to a string in the format yyyy-MM-ddTHH:mm:ssZ when converting to JSON
/// </summary>
internal class DateTimeNullableJsonConverter : JsonConverter<DateTime?>
{
    public override DateTime? ReadJson(JsonReader reader, Type objectType, DateTime? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.Value is null)
        {
            return null;
        }
        return DateTime.Parse(reader.Value.ToString()!);
    }

    public override void WriteJson(JsonWriter writer, DateTime? value, JsonSerializer serializer)
    {
        if (value is null)
        {
            writer.WriteNull();
        }
        else
        {
            writer.WriteValue(value.GetValueOrDefault().ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
        }
    }
}
/// <summary>
/// Converts a DateTime to a string in the format yyyy-MM-ddTHH:mm:ssZ when converting to JSON
/// </summary>
internal class DateTimeJsonConverter : JsonConverter<DateTime>
{
    public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.Value is null)
        {
            return DateTime.MinValue;
        }
        return DateTime.Parse(reader.Value.ToString()!);
    }
    public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
    }
}

/// <summary>
/// Converts a nullable DateTime to a string in the format yyyy-MM-dd when converting to JSON
/// </summary>
internal class KlaviyoDateOnlyNullableJsonConverter : JsonConverter<KlaviyoDateOnly?>
{
    public override KlaviyoDateOnly? ReadJson(JsonReader reader, Type objectType, KlaviyoDateOnly? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.Value is null)
        {
            return null;
        }
        return KlaviyoDateOnly.Parse(reader.Value.ToString()!);
    }

    public override void WriteJson(JsonWriter writer, KlaviyoDateOnly? value, JsonSerializer serializer)
    {
        if (value is null)
        {
            writer.WriteNull();
        }
        else
        {
            writer.WriteValue(value.GetValueOrDefault().ToString("yyyy-MM-dd"));
        }
    }
}