namespace KlaviyoSharp.Models;

/// <summary>
/// A Template in Klaviyo
/// </summary>
public class Template : KlaviyoObject<TemplateAttributes>
{
    /// <summary>
    /// Creates a new instance of the Template class
    /// </summary>
    /// <returns></returns>
    public static new Template Create()
    {
        return new Template() { Type = "template" };
    }
}

/// <summary>
/// Attributes for the Template
/// </summary>
public class TemplateAttributes
{
    /// <summary>
    /// The name of the template
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// editor_type has a fixed set of values:
    /// SYSTEM_DRAGGABLE: indicates a drag-and-drop editor template
    /// SIMPLE: A rich text editor template
    /// CODE: A custom HTML template
    /// USER_DRAGGABLE: A hybrid template, using custom HTML in the drag-and-drop editor
    /// </summary>
    /// <remarks>Restricted to CODE when creating a template</remarks>
    public string EditorType { get; set; }
    /// <summary>
    /// The HTML contents of the template
    /// </summary>
    public string Html { get; set; }
    /// <summary>
    /// The plaintext version of the template
    /// </summary>
    public string Text { get; set; }
    /// <summary>
    /// The date the template was created in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm)
    /// </summary>
    public DateTime? Created { get;  }
    /// <summary>
    /// The date the template was updated in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm)
    /// </summary>
    public DateTime? Updated { get;  }
    /// <summary>
    /// Only used for template rendering. The context for the template render. This must be a JSON object which has
    /// values for any tags used in the template. See this doc for more details.
    /// </summary>
    public Dictionary<string, string> Context { get; set; }
    /// <summary>
    /// Only used for template tendering. The ID of template.
    /// </summary>
    public string Id { get; set; }
}