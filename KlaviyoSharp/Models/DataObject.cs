namespace KlaviyoSharp.Models;

public abstract class DataObject
{
    public string type { get; set; }
}
public class DataObject<T> : DataObject where T : AttributesObject
{
    public DataObject(string type, T attributes) : base()
    {
        this.type = type;
        this.attributes = attributes;
    }
    public T attributes { get; set; }
}