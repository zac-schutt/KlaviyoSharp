using System;
using System.Net.Http;

namespace KlaviyoSharp.Infrastructure;
public class CloneableHttpRequestMessage : HttpRequestMessage
{
    public CloneableHttpRequestMessage(HttpMethod method, Uri url, HttpContent content = null) : base(method, url)
    {
        if (content != null)
        {
            Content = content;
        }
    }
    /// <summary>
    /// Clones the request so that it can be executed again
    /// </summary>
    /// <returns></returns>
    public CloneableHttpRequestMessage Clone()
    {
        HttpContent newContent = Content;

        if (newContent != null && newContent is JsonContent c)
        {
            newContent = c.Clone();
        }

        var cloned = new CloneableHttpRequestMessage(Method, RequestUri, newContent);

        // Copy over the request's headers which includes the access token if set
        foreach (var header in Headers)
        {
            cloned.Headers.Add(header.Key, header.Value);
        }

        return cloned;
    }
}