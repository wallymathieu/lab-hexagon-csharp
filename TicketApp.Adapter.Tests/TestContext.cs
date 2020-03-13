using System;
using System.Net.Http.Headers;

namespace TicketApp.Adapter.Tests
{
    public static class TestContext
    {
        public static HttpRequestHeaders SetHeaders(HttpRequestHeaders headers)
        {
            headers.Add("Accept", "application/json");
            return headers;
        }
    }
}

