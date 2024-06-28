namespace KlaviyoSharp.Models;

/// <summary>
/// Generic object with a single property called "data"
/// </summary>
/// <typeparam name="T"></typeparam>
public class DataObject<T>
{
    /// <summary>
    /// Creates a new instance of the DataObject class
    /// </summary>
    public DataObject() { }
    /// <summary>
    /// Creates a new instance of the DataObject class with the provided data
    /// </summary>
    /// <param name="data"></param>
    public DataObject(T data)
    {
        Data = data;
    }
    /// <summary>
    /// The data property
    /// </summary>
    public T Data { get; set; }
}

/// <summary>
/// A generic data object with an additional property called "included"
/// </summary>
/// <typeparam name="T"></typeparam>
public class DataObjectWithIncluded<T> : DataObject<T>
{
    /// <summary>
    /// Included records
    /// </summary>
    public List<object> Included { get; set; }
}

/// <summary>
/// A generic data object for relationships
/// </summary>
/// <typeparam name="T"></typeparam>
public class DataObjectRelated<T>
{
    /// <summary>
    /// Creates a new instance of the DataObjectRelated class
    /// </summary>
    public DataObjectRelated() { }
    /// <summary>
    /// Creates a new instance of the DataObjectRelated class with the provided data
    /// </summary>
    /// <param name="data"></param>
    public DataObjectRelated(T data)
    {
        Data = data;
    }
    /// <summary>
    /// The data property
    /// </summary>
    public T Data { get; set; }
    /// <summary>
    /// Links to paginate through the list
    /// </summary>
    public Links.RelatedLink Links { get; set; }
}

/// <summary>
/// A generic data object for with navigation links
/// </summary>
/// <typeparam name="T"></typeparam>
public class DataObjectWithNavigate<T>
{
    /// <summary>
    /// Creates a new instance of the DataObjectRelated class
    /// </summary>
    public DataObjectWithNavigate() { }
    /// <summary>
    /// Creates a new instance of the DataObjectRelated class with the provided data
    /// </summary>
    /// <param name="data"></param>
    public DataObjectWithNavigate(T data)
    {
        Data = data;
    }
    /// <summary>
    /// The data property
    /// </summary>
    public T Data { get; set; }
    /// <summary>
    /// Links to paginate through the list
    /// </summary>
    public Links.NavLink Links { get; set; }
}

/// <summary>
/// Generic object with a single list property called "data"
/// </summary>
/// <typeparam name="T"></typeparam>
public class DataListObject<T>
{
    /// <summary>
    /// Creates a new instance of the DataListObject class
    /// </summary>
    public DataListObject() { }
    /// <summary>
    /// Creates a new instance of the DataListObject class with the provided data
    /// </summary>
    /// <param name="data"></param>
    public DataListObject(List<T> data)
    {
        Data = data;
    }
    /// <summary>
    /// The data property
    /// </summary>
    public List<T> Data { get; set; }
    /// <summary>
    /// Links to paginate through the list
    /// </summary>
    public Links.NavLink Links { get; set; }
}

/// <summary>
/// A generic data list object with an additional property called "included"
/// </summary>
/// <typeparam name="T"></typeparam>
public class DataListObjectWithIncluded<T> : DataListObject<T>
{
    /// <summary>
    /// Included records
    /// </summary>
    public List<object> Included { get; set; }
}

/// <summary>
/// A generic data list object for relationships
/// </summary>
/// <typeparam name="T"></typeparam>
public class DataListObjectRelated<T>
{
    /// <summary>
    /// Creates a new instance of the DataListObjectRelated class
    /// </summary>
    public DataListObjectRelated() { }
    /// <summary>
    /// Creates a new instance of the DataListObjectRelated class with the provided data
    /// </summary>
    /// <param name="data"></param>
    public DataListObjectRelated(List<T> data)
    {
        Data = data;
    }
    /// <summary>
    /// The data property
    /// </summary>
    public List<T> Data { get; set; }
    /// <summary>
    /// Links to paginate through the list
    /// </summary>
    public Links.RelatedLink Links { get; set; }
}