using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace TicketApp.Adapter.Tests
{
    public static class TestServers
    {
        public static IHost Create<T>() where T : class
        {
            var _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .Build();

            var host = Host.CreateDefaultBuilder()
                           .ConfigureWebHost(c=>c.UseStartup<T>().UseTestServer());

            return host.StartAsync().GetAwaiter().GetResult();
        }
    }
}

