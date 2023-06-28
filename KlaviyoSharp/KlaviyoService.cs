using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;
using KlaviyoSharp.Infrastructure;

namespace KlaviyoSharp;

/// <summary>
/// Base for the Klaviyo Service
/// </summary>
public abstract class KlaviyoService
{
    /// <summary>
    /// Whether or not to use authentication
    /// </summary>
    protected bool _useAuthentication = true;
    /// <summary>
    /// The server URI to use
    /// </summary>
    protected Uri _serverUri = new Uri("https://a.klaviyo.com");
    /// <summary>
    /// The API path to use. Should be /api or /client
    /// </summary>
    protected string _apiPath;
    /// <summary>
    /// The API key to use if authentication is enabled
    /// </summary>
    protected string _apiKey;
    /// <summary>
    /// The company ID to use if authentication is disabled
    /// </summary>
    protected string _companyId;
    /// <summary>
    /// The HttpClient to use for all calls
    /// </summary>
    private HttpClient _httpClient;
    /// <summary>
    /// Creates a new KlaviyoService using default options
    /// </summary>
    public KlaviyoService()
    {
        _httpClient = new HttpClient();
    }
    public KlaviyoService(Uri serverUri) : this()
    {
        _serverUri = serverUri;
    }

    private Uri BuildURI(string path)
    {
        var builder = new UriBuilder(_serverUri)
        {
            Path = $"{_apiPath}/{path}"
        };
        return builder.Uri;
    }

    public async virtual Task GET(string path, Dictionary<string, string> query, Dictionary<string, string> headers, CancellationToken cancellationToken)
    {
        await GET<object>(path, query, headers, cancellationToken);
    }
    public async virtual Task POST(string path, Dictionary<string, string> query, Dictionary<string, string> headers, DataObject data, CancellationToken cancellationToken)
    {
        await POST<object>(path, query, headers, data, cancellationToken);
    }
    public async virtual Task<T> GET<T>(string path, Dictionary<string, string> query, Dictionary<string, string> headers, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await ExecuteRequest(PrepareRequest(HttpMethod.Get, BuildURI(path), query, headers), cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(response.Content.ReadAsStringAsync().Result);
        }
        else
        {
            throw new KlaviyoException(KlaviyoError.FromHttpResponse(response));
        }
    }
    public async virtual Task<T> POST<T>(string path, Dictionary<string, string> query, Dictionary<string, string> headers, DataObject data, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await ExecuteRequest(PrepareRequest(HttpMethod.Post, BuildURI(path), query, headers, data), cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(response.Content.ReadAsStringAsync().Result);
        }
        else
        {
            throw new KlaviyoException(KlaviyoError.FromHttpResponse(response));
        }
    }
    public async virtual Task<T> PUT<T>(string path, Dictionary<string, string> query, Dictionary<string, string> headers, DataObject data, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await ExecuteRequest(PrepareRequest(HttpMethod.Put, BuildURI(path), query, headers, data), cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(response.Content.ReadAsStringAsync().Result);
        }
        else
        {
            throw new KlaviyoException(KlaviyoError.FromHttpResponse(response));
        }
    }
    public async virtual Task DELETE(string path, Dictionary<string, string> query, Dictionary<string, string> headers, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await ExecuteRequest(PrepareRequest(HttpMethod.Delete, BuildURI(path), query, headers), cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return;
        }
        else
        {
            throw new KlaviyoException(KlaviyoError.FromHttpResponse(response));
        }
    }

    /// <summary>
    /// Prepares the request for the HttpClient
    /// </summary>
    /// <param name="method">The HTTP method to use</param>
    /// <param name="uri">The URI to call</param>
    /// <param name="query">The query string to use</param>
    /// <param name="headers">The headers to use</param>
    /// <param name="content">The content to use</param>
    /// <returns>A HttpRequestMessage</returns>
    HttpRequestMessage PrepareRequest(HttpMethod method, Uri uri, Dictionary<string, string> query = null, Dictionary<string, string> headers = null, object content = null)
    {
        HttpRequestMessage req = new HttpRequestMessage(method, uri) { };

        if (_useAuthentication)
        {
            if (headers is null) { headers = new(); }
            headers.Add("Authorization", $"Basic {_apiKey}");
        }
        else
        {
            if (query is null) { query = new(); }
            query.Add("company_id", _companyId);
        }
        if (query != null)
        {
            req.RequestUri = new Uri($"{req.RequestUri}?{query.ToQueryString()}");
        }
        if (headers != null)
        {
            foreach (var header in headers)
            {
                req.Headers.Add(header.Key, header.Value);
            }
        }
        req.Headers.Add("Accept", "application/json");
        if (content != null)
        {
            req.Content = new JsonContent(content);
        }
        return req;
    }

    private async Task<HttpResponseMessage> ExecuteRequest(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return await _httpClient.SendAsync(request, cancellationToken);
    }

}