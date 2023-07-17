namespace KlaviyoSharp.Models;

public class Flow : KlaviyoObject<FlowAttributes>
{
  /// <summary>
    /// Creates a new instance of the Template class
    /// </summary>
    /// <returns></returns>
    public static new Flow Create()
    {
        return new Flow() { Type = "flow" };
    }
}

public class FlowAttributes
{
    //TODO: Implement
}