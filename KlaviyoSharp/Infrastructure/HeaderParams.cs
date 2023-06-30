using System.Collections.Generic;

namespace KlaviyoSharp.Infrastructure;
/// <summary>
/// Class to represent a HTTP headers. Prevents accidentally passing the params to the wrong method parameter.
/// </summary>
public class HeaderParams : Dictionary<string, string>
{
}