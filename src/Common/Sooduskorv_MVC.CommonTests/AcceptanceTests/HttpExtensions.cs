﻿/*using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace WebMVC.Tests
{
    public static class HttpExtensions
    {
        public static HttpResponseMessage GetPage(this HttpClient c, string url)
            => c.GetAsync(url).GetAwaiter().GetResult();

        public static string GetString(this HttpResponseMessage page)
            => page.Content.ReadAsStringAsync().GetAwaiter().GetResult();

        public static string GetHeader(this HttpResponseMessage page)
            => page.Content.Headers.ContentType.ToString();

        public static HttpResponseMessage GetPage(this HttpClient c, HttpRequestMessage m)
            => c.SendAsync(m).GetAwaiter().GetResult();
    }
}*/