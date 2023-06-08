using Core.Ultilities.Helpers;
using Core.Ultilities.Model.TestSettingsModel;
using Newtonsoft.Json;
using System.Net;

namespace Core.Ultilities.Api
{
    public class BaseApi : ApiEndpoint
    {
        /// <summary>
        /// Send API request
        /// </summary>
        /// <param name="method"> GET, POST, PUT, PATCH, DELETE </param>
        /// <param name="endPoint"> End point of the API </param>
        /// <param name="content"> Request body for POST, PUT, PATCH, DELETE method. Default is null </param>
        /// <param name="expectedStatus"> Expected response status </param>
        /// <returns> Deserialize  Model </returns>
        public async static Task<T> SendRequest<T>(HttpMethod method, string endPoint, HttpContent content = null,
    HttpStatusCode expectedStatus = HttpStatusCode.OK)
        {
            // Read the JSON file containing the base URL
            string currentDirectory = Directory.GetCurrentDirectory();
            string jsonSetting = File.ReadAllText(Path.Combine(currentDirectory, "test-settings.json"));

            var settingModel = JsonConvert.DeserializeObject<ApiTestSettingsModel>(jsonSetting);

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(settingModel?.BaseUrl ?? throw new Exception(
                    "Unable to get Base Url for API from the model or the model is null!"));

                var newUri = new Uri(client.BaseAddress, endPoint);
                using (HttpRequestMessage request = new HttpRequestMessage(method, newUri))
                {
                    if (method == HttpMethod.Post || method == HttpMethod.Put || 
                        method == HttpMethod.Patch || method == HttpMethod.Delete
                        && content != null)
                    {
                        request.Content = content;
                    }

                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        HttpStatusCode statusCode = response.StatusCode;
                        if (statusCode != expectedStatus)
                        {
                            throw new HttpRequestException($"Request failed with status code: {(int)statusCode} - {statusCode}");
                        }

                        using (HttpContent responseContent = response.Content)
                        {
                            string responseBody = await responseContent.ReadAsStringAsync();

                            if (string.IsNullOrEmpty(responseBody) && expectedStatus != HttpStatusCode.NoContent)
                            {
                                throw new ArgumentException("Response is null or empty.", nameof(responseBody));
                            }

                            return JsonConvert.DeserializeObject<T>(responseBody);
                        }
                    }
                }
            }
        }
    }
}
