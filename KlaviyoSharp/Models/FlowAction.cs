namespace KlaviyoSharp.Models;

public class FlowAction : KlaviyoObject<FlowActionAttributes>
{
  /// <summary>
    /// Creates a new instance of the Template class
    /// </summary>
    /// <returns></returns>
    public static new Flow Create()
    {
        return new Flow() { Type = "flow-action" };
    }
}

public class FlowActionAttributes
{
    //TODO: Implement
}