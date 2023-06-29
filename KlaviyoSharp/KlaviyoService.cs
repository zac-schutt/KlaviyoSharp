using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;
using KlaviyoSharp.Infrastructure;
using Newtonsoft.Json;

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
    protected Uri _serverUri = new("https://a.klaviyo.com");
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
    private readonly HttpClient _httpClient;
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

    public async virtual Task GET(string path, string revision, Dictionary<string, string> query, Dictionary<string, string> headers, CancellationToken cancellationToken)
    {
        await GET<object>(path, revision, query, headers, cancellationToken);
    }
    public async virtual Task POST(string path, string revision, Dictionary<string, string> query, Dictionary<string, string> headers, DataObject data, CancellationToken cancellationToken)
    {
        await POST<object>(path, revision, query, headers, data, cancellationToken);
    }
    public async virtual Task<T> GET<T>(string path, string revision, Dictionary<string, string> query, Dictionary<string, string> headers, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await ExecuteRequest(PrepareRequest(HttpMethod.Get, BuildURI(path), revision, query, headers), cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync(cancellationToken).Result);
        }
        else
        {
            throw new KlaviyoException(KlaviyoError.FromHttpResponse(response));
        }
    }
    public async virtual Task<T> POST<T>(string path, string revision, Dictionary<string, string> query, Dictionary<string, string> headers, DataObject data, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await ExecuteRequest(PrepareRequest(HttpMethod.Post, BuildURI(path), revision, query, headers, new RequestBody(data)), cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync(cancellationToken).Result);
        }
        else
        {
            throw new KlaviyoException(KlaviyoError.FromHttpResponse(response));
        }
    }
    public async virtual Task<T> PUT<T>(string path, string revision, Dictionary<string, string> query, Dictionary<string, string> headers, DataObject data, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await ExecuteRequest(PrepareRequest(HttpMethod.Put, BuildURI(path), revision, query, headers, new RequestBody(data)), cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync(cancellationToken).Result);
        }
        else
        {
            throw new KlaviyoException(KlaviyoError.FromHttpResponse(response));
        }
    }
    public async virtual Task DELETE(string path, string revision, Dictionary<string, string> query, Dictionary<string, string> headers, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await ExecuteRequest(PrepareRequest(HttpMethod.Delete, BuildURI(path), revision, query, headers), cancellationToken);
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
    HttpRequestMessage PrepareRequest(HttpMethod method, Uri uri, string revision, Dictionary<string, string> query = null, Dictionary<string, string> headers = null, RequestBody content = null)
    {
        HttpRequestMessage req = new(method, uri) { };
        headers ??= new();
        query ??= new();
        headers.Add("revision", revision);
        //headers.Add("Accept", "application/json");
        if (_useAuthentication)
        {
            headers.Add("Authorization", $"Basic {_apiKey}");
        }
        if (!string.IsNullOrEmpty(_companyId))
        {
            query.Add("company_id", _companyId);
        }
        req.RequestUri = new Uri($"{req.RequestUri}?{query.ToQueryString()}");

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

    private async Task<HttpResponseMessage> ExecuteRequest(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return await _httpClient.SendAsync(request, cancellationToken);
    }

}