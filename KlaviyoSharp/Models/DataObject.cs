using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class DataObject<T>
{
    public DataObject() { }
    public DataObject(T data)
    {
        Data = data;
    }

    [JsonProperty("data")]
    public T Data { get; set; }

}

public class DataObjectWithIncluded<T> : DataObject<T>{
    [JsonProperty("included")]
    public List<object> Included { get; set; }
}

public class DataListObject<T>
{
    public DataListObject() { }
    public DataListObject(List<T> data)
    {
        Data = data;
    }

    [JsonProperty("data")]
    public List<T> Data { get; set; }
    [JsonProperty("links")]
    public Links.NavLink Links { get; set; }
}
public class DataListObjectRelated<T>
{
    public DataListObjectRelated() { }
    public DataListObjectRelated(List<T> data)
    {
        Data = data;
    }

    [JsonProperty("data")]
    public List<T> Data { get; set; }
    [JsonProperty("links")]
    public Links.RelatedLink Links { get; set; }
}