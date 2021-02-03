using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Northwind.Web.UI.Extensions
{
    public static class HttpClientExtensions
    {
        public static HttpClient AddHeader(this HttpClient httpClient)
        {
            string baseUrl = "http://localhost:62437/";
            string contentType = "application/json";
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
            var userAgent = "d-fens HttpClient";
            httpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);
            return httpClient;
        }
    }
}