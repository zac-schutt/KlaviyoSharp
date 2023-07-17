namespace KlaviyoSharp.Models;

public class FlowMessage : KlaviyoObject<FlowMessageAttributes>
{
  /// <summary>
    /// Creates a new instance of the Template class
    /// </summary>
    /// <returns></returns>
    public static new Flow Create()
    {
        return new Flow() { Type = "flow-message" };
    }
}

public class FlowMessageAttributes
{
    //TODO: Implement
}