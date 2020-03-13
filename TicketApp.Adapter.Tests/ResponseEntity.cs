using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TicketApp.Adapter.Tests
{
    public class ResponseEntity<T>
    {

        private readonly Lazy<T> _Data;
        public HttpResponseMessage Response { get; }
        public HttpResponseHeaders Headers => Response.Headers;
        public HttpStatusCode StatusCode => Response.StatusCode;
        public T Body => _Data.Value;
        public ResponseEntity(HttpResponseMessage response)
        {
            Response = response;
            _Data = new Lazy<T>(() =>
              {
                  var resp = response.Content.ReadAsStringAsync();
                  return JsonConvert.DeserializeObject<T>(resp.GetAwaiter().GetResult());
              });
        }
    }
}