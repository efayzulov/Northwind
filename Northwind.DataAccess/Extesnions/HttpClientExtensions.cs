using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Northwind.DataAccess.Extesnions
{
    public static class HttpClientExtensions
    {
        public static HttpClient AddHeader(this HttpClient httpClient)
        {
            string baseUrl = "https://northwind.now.sh";
            string contentType = "application/json";
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
            var userAgent = "d-fens HttpClient";
            httpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);
            return httpClient;
        }

    }
}