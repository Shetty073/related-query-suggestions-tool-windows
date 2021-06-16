using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HelperLibrary
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            // Add headers here if any
        }
    }
}
