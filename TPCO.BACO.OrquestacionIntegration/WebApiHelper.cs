using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace TPCO.BACO.OrquestacionIntegration
{
    public class WebApiHelper
    {
        private static HttpClient ClientHttpSingleton;
        public static string UrlAPI { get; set; }

        public WebApiHelper(string urlAPI)
        {
            UrlAPI = urlAPI;
        }

        private static HttpClient ClientHttp
        {
            get
            {
                if (ClientHttpSingleton == null)
                {
                    ClientHttpSingleton = new HttpClient
                    {
                        BaseAddress = new Uri(UrlAPI)
                    };
                    ClientHttpSingleton.DefaultRequestHeaders.Accept.Clear();
                    ClientHttpSingleton.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    ClientHttpSingleton.Timeout = new TimeSpan(0, 0, 30);

                }
                return ClientHttpSingleton;
            }
        }

        public void InvokePost<T>(string route, object data, out T responseObject)
        {
            try
            {
                var Client = ClientHttp;

                HttpResponseMessage httpResponse = Client.PostAsJsonAsync(string.Concat(UrlAPI, route), data).Result;

                if (httpResponse.IsSuccessStatusCode)
                {
                    responseObject = httpResponse.Content.ReadAsAsync<T>().Result;
                }
                else
                {
                    throw new ApplicationException($"Error ApiTools Method POST statusCode:{httpResponse.StatusCode.ToString()}, request:{string.Concat(UrlAPI, route)}, data:{JsonConvert.SerializeObject(data)}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public T InvokeGet<T>(string route)
        {
            try
            {
                var Client = ClientHttp;
                HttpResponseMessage httpResponse = Client.GetAsync(string.Concat(UrlAPI, route)).Result;
                if (httpResponse.IsSuccessStatusCode)   
                {
                    var dataResponse = httpResponse.Content.ReadAsStringAsync();
                    var response =  JsonConvert.DeserializeObject<List<T>>(dataResponse.Result);
                    return response[0];
                }
                else if (httpResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ApplicationException($"No se encontraron datos para el request: {string.Concat(UrlAPI, route)} ");
                }
                else
                {
                    throw new ApplicationException($"Error ApiTools Method GET statusCode:{httpResponse.StatusCode.ToString()}, request:{string.Concat(UrlAPI, route)}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}