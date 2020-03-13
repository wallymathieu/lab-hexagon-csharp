using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TicketApp.Adapter.Tests.test_data;
using TicketApp.Application.Domain;
using TicketApp.Application.Repositories;
using Xunit;

namespace TicketApp.Adapter.Tests
{
    public class WebApiTest
    {
        [Fact]
        public async Task TestCreateTicket()
        {
            using var adapter = TestServers.Create<Startup>();
            using var httpClient = adapter.GetTestClient();
            ResponseEntity<Ticket> response = await CreateTicket(httpClient);
            var code = (int)response.StatusCode;
            if (code >= 400)
            {
                throw new Exception($"StatusCode: {response.StatusCode}");
            }
            var path = response.Headers.Location.PathAndQuery;

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.StartsWith("/api/v1/tickets", path);
            Ticket entity = response.Body;

            Assert.Equal(5, entity.Priority);
        }
        [Fact]
        public async Task GetSwagger()
        {
            using var adapter = TestServers.Create<Startup>();
            using var httpClient = adapter.GetTestClient();
            var response = await httpClient.GetAsync("/swagger/v1/swagger.json");
            var code = (int)response.StatusCode;
            if (code >= 400)
            {
                throw new Exception($"StatusCode: {response.StatusCode}");
            }

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content=await response.Content.ReadAsStringAsync();
            File.WriteAllText("./swagger.json",content);
        }

        private async Task<ResponseEntity<Ticket>> CreateTicket(HttpClient httpClient) =>
            new ResponseEntity<Ticket>(
                await httpClient.PostAsync("/api/v1/tickets",
                    new StringContent(Read("ticket-sample.json"), Encoding.UTF8, "application/json")));

        public static string Read(string file)
        {
            using var stream = typeof(WebApiTest).Assembly.GetManifestResourceStream(typeof(TestData), file);
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}

