using System;
using System.IO;
using System.Text.Json;
using api.Models;
using Shared.Models;

namespace api;

public static class HttpRequestDataExtensions
{
    /// <summary>
    /// Create an HttpStatus No Content based response.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The <see cref="HttpStatusCode.NoContent"/> based response.</returns>
    public static HttpResponseData NoContentResponse(this HttpRequestData request) => request.CreateResponse(HttpStatusCode.NoContent);

    /// <summary>
    /// Creates an Ok Response with string based content. This response has a text/plain content type.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="content">The string content to add to the response.</param>
    /// <returns>The <see cref="HttpStatusCode.OK"/> based response.</returns>
    public static async Task<HttpResponseData> OkResponse(this HttpRequestData request, string content)
    {
        var response = request.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
        await response.WriteStringAsync(content).ConfigureAwait(false);
        return response;
    }

    /// <summary>
    /// Creates an Ok Response with object based content.
    /// </summary>
    /// <typeparam name="T">The type of the <param name="data"></param>.</typeparam>
    /// <param name="request">The request.</param>
    /// <param name="data">The data payload to serialize into the body of the response.</param>
    /// <returns>The <see cref="HttpStatusCode.OK"/> based response.</returns>
    public static async Task<HttpResponseData> OkObjectResponse<T>(this HttpRequestData request, T data)
    {
        var response = request.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(data).ConfigureAwait(false);
        return response;
    }
    /// <summary>
    /// Creates a not found based response.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns></returns>
    public static HttpResponseData NotFoundResponse(this HttpRequestData request) => request.CreateResponse(HttpStatusCode.NotFound);

    public static async Task<T> DeserializeRequest<T>(this HttpRequestData request)
    {
        string requestBody = null;
        
        using (var streamReader =  new  StreamReader(request.Body))
        {
            requestBody = await streamReader.ReadToEndAsync();
        }

        var returnObject = JsonSerializer.Deserialize<T>(requestBody);
        
        returnObject = (T)Convert.ChangeType(returnObject, typeof(T));

        return returnObject;
    }
}