using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;
using KlaviyoSharp.Infrastructure;
using Newtonsoft.Json;
using System.Diagnostics;

namespace KlaviyoSharp;

/// <summary>
/// Base for the Klaviyo Service
/// </summary>
public abstract class KlaviyoApiBase
{
    private readonly KlaviyoConfig _config;

    /// <summary>
    /// The HttpClient to use for all calls
    /// </summary>
    private readonly HttpClient _httpClient;
    /// <summary>
    /// Creates a new KlaviyoService using the provided config
    /// </summary>
    /// <param name="config">The config to use</param>
    public KlaviyoApiBase(KlaviyoConfig config)
    {
        _config = config;
        _httpClient = new HttpClient();
    }
    /// <summary>
    /// Execute HTTP request and follow all pagination links
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="method">HTTP method to use</param>
    /// <param name="path">Path on the API to call</param>
    /// <param name="revision">The API revision</param>
    /// <param name="query">The query string parameters to use</param>
    /// <param name="headers">The headers to use</param>
    /// <param name="data">The data to send in the body of the request</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    internal async Task<DataListObjectWithIncluded<T>> HTTPRecursiveWithIncluded<T>(HttpMethod method,
                                                                                    string path,
                                                                                    string revision,
                                                                                    QueryParams query,
                                                                                    HeaderParams headers,
                                                                                    object data,
                                                                                    CancellationToken cancellationToken)
    {
        DataListObjectWithIncluded<T> output = new()
        {
            Data = new(),
            Included = new()
        };
        string pageCursor = "";
        DataListObjectWithIncluded<T> response;
        query.Add("page[cursor]", pageCursor);
        do
        {
            query["page[cursor]"] = pageCursor;
            response = await HTTP<DataListObjectWithIncluded<T>>(method, path, revision, query, headers, data,
                                                                 cancellationToken);
            output.Data.AddRange(response.Data);
            output.Included.AddRange(response.Included ?? Enumerable.Empty<object>());
            new QueryParams(response.Links.Next)?.TryGetValue("page[cursor]", out pageCursor);
        } while (response.Links.Next != null);
        return output;
    }
    /// <summary>
    /// Execute HTTP request and follow all pagination links
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="method">HTTP method to use</param>
    /// <param name="path">Path on the API to call</param>
    /// <param name="revision">The API revision</param>
    /// <param name="query">The query string parameters to use</param>
    /// <param name="headers">The headers to use</param>
    /// <param name="data">The data to send in the body of the request</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    internal async Task<DataListObject<T>> HTTPRecursive<T>(HttpMethod method,
                                                            string path,
                                                            string revision,
                                                            QueryParams query,
                                                            HeaderParams headers,
                                                            object data,
                                                            CancellationToken cancellationToken)
    {
        DataListObject<T> output = new()
        {
            Data = new()
        };
        string pageCursor = "";
        DataListObject<T> response;
        query.Add("page[cursor]", pageCursor);
        do
        {
            query["page[cursor]"] = pageCursor;
            response = await HTTP<DataListObject<T>>(method, path, revision, query, headers, data, cancellationToken);
            output.Data.AddRange(response.Data);
            new QueryParams(response.Links.Next)?.TryGetValue("page[cursor]", out pageCursor);
        } while (response.Links.Next != null);
        return output;
    }

    /// <summary>
    /// Performs an HTTP request to the Klaviyo API and returns the response
    /// </summary>
    /// <param name="method">HTTP method to use</param>
    /// <param name="path">Path on the API to call</param>
    /// <param name="revision">The API revision</param>
    /// <param name="query">The query string parameters to use</param>
    /// <param name="headers">The headers to use</param>
    /// <param name="data">The data to send in the body of the request</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    internal async Task<T> HTTP<T>(HttpMethod method,
                                   string path,
                                   string revision,
                                   QueryParams query,
                                   HeaderParams headers,
                                   object data,
                                   CancellationToken cancellationToken)
    {
        CloneableHttpRequestMessage requestMessage = PrepareRequest(method, BuildURI(path), revision, query, headers, data);
#if NET6_0
        string TextResult = (await GetResponse(requestMessage, cancellationToken)).Content.ReadAsStringAsync(cancellationToken).Result;
#else
        string TextResult = (await GetResponse(requestMessage, cancellationToken)).Content.ReadAsStringAsync().Result;
#endif
        return JsonConvert.DeserializeObject<T>(TextResult, JsonContent.KlaviyoJsonSerializerSettings);
    }
    /// <summary>
    /// Performs an HTTP request to the Klaviyo API and does not return a response
    /// </summary>
    /// <param name="method">HTTP method to use</param>
    /// <param name="path">Path on the API to call</param>
    /// <param name="revision">The API revision</param>
    /// <param name="query">The query string parameters to use</param>
    /// <param name="headers">The headers to use</param>
    /// <param name="data">The data to send in the body of the request</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    internal async Task HTTP(HttpMethod method,
                             string path,
                             string revision,
                             QueryParams query,
                             HeaderParams headers,
                             object data,
                             CancellationToken cancellationToken)
    {
        CloneableHttpRequestMessage requestMessage = PrepareRequest(method, BuildURI(path), revision, query, headers, data);
        await GetResponse(requestMessage, cancellationToken);
    }

    /// <summary>
    /// Build a URI from the provided path
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private Uri BuildURI(string path)
    {
        var builder = new UriBuilder(_config.ApiDomain)
        {
            Path = $"{_config.ApiPath}/{path}"
        };
        return builder.Uri;
    }

    /// <summary>
    /// Prepares the request for the HttpClient
    /// </summary>
    /// <param name="method">The HTTP method to use</param>
    /// <param name="uri">The URI to call</param>
    /// <param name="revision">The API revision</param>
    /// <param name="query">The query string to use</param>
    /// <param name="headers">The headers to use</param>
    /// <param name="content">The content to use</param>
    /// <returns>A CloneableHttpRequestMessage</returns>
    internal CloneableHttpRequestMessage PrepareRequest(HttpMethod method,
                                                        Uri uri,
                                                        string revision,
                                                        QueryParams query = null,
                                                        HeaderParams headers = null,
                                                        object content = null)
    {
        CloneableHttpRequestMessage req = new(method, uri) { };
        headers ??= new();
        query ??= new();
        headers.Add("revision", revision);
        //headers.Add("Accept", "application/json");
        if (_config.UseAuthentication)
        {
            headers.Add("Authorization", $"Klaviyo-API-Key {_config.ApiKey}");
        }
        else
        {
            query.Add("company_id", _config.ApiKey);
        }

        req.RequestUri = new Uri($"{req.RequestUri}?{query}");
        foreach (var header in headers)
        {
            req.Headers.Add(header.Key, header.Value);
        }
        if (content != null)
        {
            req.Content = new JsonContent(content);
        }
        return req;
    }

    /// <summary>
    /// Gets the response from the API. Respects the rate limiting.
    /// </summary>
    /// <param name="requestMessage"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ApplicationException"></exception>
    /// <exception cref="KlaviyoException"></exception>
    internal async Task<HttpResponseMessage> GetResponse(CloneableHttpRequestMessage requestMessage,
                                                         CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await _httpClient.SendAsync(requestMessage, cancellationToken);
        int retryCount = 0;
        while (response.StatusCode.ToString() == "TooManyRequests")
        {
            if (retryCount >= _config.MaxRetries) { throw new ApplicationException("Too many retries. Aborted."); }
            retryCount++;
            response.Headers.TryGetValues("Retry-After", out IEnumerable<string> retryAfters);
            int retryAfter = retryAfters.FirstOrDefault() != null ? Convert.ToInt32(retryAfters.FirstOrDefault()) : 10;
            if (retryAfter > _config.MaxDelay) { throw new ApplicationException("Rate limiting applied and Retry-After is too high. Aborted."); }
            Debug.WriteLine($"Warning! Too many requests. Retrying in {retryAfter} seconds...");
            await Task.Delay(1000 * retryAfter, cancellationToken);
            response = await _httpClient.SendAsync(requestMessage.Clone(), cancellationToken);
        }
        if (!response.IsSuccessStatusCode)
        {
            throw new KlaviyoException(KlaviyoError.FromHttpResponse(response));
        }
        return response;
    }
}