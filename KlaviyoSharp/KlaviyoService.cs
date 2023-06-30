using System;
using System.Linq;
using System.Collections.Generic;
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
    /// <summary>
    /// The server URI to use
    /// </summary>
    protected Uri _serverUri = new("https://a.klaviyo.com");
    /// <summary>
    /// The API path to use. Should be /api or /client
    /// </summary>
    protected string _apiPath;
    /// <summary>
    /// The API key to use
    /// </summary>
    protected string _apiKey;
    /// <summary>
    /// The company ID to use
    /// </summary>
    protected string _companyId;
    /// <summary>
    /// The HttpClient to use for all calls
    /// </summary>
    private readonly HttpClient _httpClient;
    /// <summary>
    /// Creates a new KlaviyoService using default options
    /// </summary>
    public KlaviyoApiBase()
    {
        _httpClient = new HttpClient();
    }
    /// <summary>
    /// Creates a new KlaviyoService using a custom Uri
    /// </summary>
    /// <param name="serverUri"></param>
    public KlaviyoApiBase(Uri serverUri) : this()
    {
        _serverUri = serverUri;
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
    internal async Task<T> HTTP<T>(HttpMethod method, string path, string revision, QueryParams query, HeaderParams headers, object data, CancellationToken cancellationToken)
    {
        RequestBody requestBody = null;
        if (data != null) { requestBody = new RequestBody(data); }
        CloneableHttpRequestMessage requestMessage = PrepareRequest(method, BuildURI(path), revision, query, headers, requestBody);
        return JsonConvert.DeserializeObject<T>((await GetResponse(requestMessage, cancellationToken)).Content.ReadAsStringAsync(cancellationToken).Result);
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
    internal async Task HTTP(HttpMethod method, string path, string revision, QueryParams query, HeaderParams headers, object data, CancellationToken cancellationToken)
    {
        RequestBody requestBody = null;
        if (data != null) { requestBody = new RequestBody(data); }
        CloneableHttpRequestMessage requestMessage = PrepareRequest(method, BuildURI(path), revision, query, headers, requestBody);
        await GetResponse(requestMessage, cancellationToken);
    }

    /// <summary>
    /// Build a URI from the provided path
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private Uri BuildURI(string path)
    {
        var builder = new UriBuilder(_serverUri)
        {
            Path = $"{_apiPath}/{path}"
        };
        return builder.Uri;
    }

    /// <summary>
    /// Prepares the request for the HttpClient
    /// </summary>
    /// <param name="method">The HTTP method to use</param>
    /// <param name="uri">The URI to call</param>
    /// <param name="query">The query string to use</param>
    /// <param name="headers">The headers to use</param>
    /// <param name="content">The content to use</param>
    /// <returns>A CloneableHttpRequestMessage</returns>
    internal CloneableHttpRequestMessage PrepareRequest(HttpMethod method, Uri uri, string revision, QueryParams query = null, HeaderParams headers = null, RequestBody content = null)
    {
        CloneableHttpRequestMessage req = new(method, uri) { };
        headers ??= new();
        query ??= new();
        headers.Add("revision", revision);
        //headers.Add("Accept", "application/json");
        if (!string.IsNullOrEmpty(_apiKey))
        {
            headers.Add("Authorization", $"Klaviyo-API-Key {_apiKey}");
        }
        if (!string.IsNullOrEmpty(_companyId))
        {
            query.Add("company_id", _companyId);
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
    internal async Task<HttpResponseMessage> GetResponse(CloneableHttpRequestMessage requestMessage, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await _httpClient.SendAsync(requestMessage, cancellationToken);
        int retryCount = 0;
        while (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
        {
            if (retryCount >= 10) { throw new ApplicationException("Too many retries. Aborted."); }
            retryCount++;
            response.Headers.TryGetValues("Retry-After", out IEnumerable<string> retryAfters);
            int retryAfter = retryAfters.FirstOrDefault() != null ? Convert.ToInt32(retryAfters.FirstOrDefault()) : 10;
            if (retryAfter > 60) { throw new ApplicationException("Rate limiting applied and Retry-After is too high. Aborted."); }
            Debug.WriteLine($"Warning! Too many requests. Retrying in {retryAfter} seconds...");
            await Task.Delay(1000 * retryAfter, cancellationToken);
            response = await _httpClient.SendAsync(requestMessage.Clone(), cancellationToken);
        }
        if (!response.IsSuccessStatusCode) { throw new KlaviyoException(KlaviyoError.FromHttpResponse(response)); }
        return response;
    }
}