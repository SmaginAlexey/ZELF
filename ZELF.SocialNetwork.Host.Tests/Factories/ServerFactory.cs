using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZELF.SocialNetwork.EFData;

namespace ZELF.SocialNetwork.Host.Tests.Factories
{
    public static class ServerFactory
    {
        public static HttpClient CreateHttpClient()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var host = new WebHostBuilder().UseConfiguration(configuration).ConfigureServices(services =>
            {
                services.AddDbContext<SocialNetworkContext>(builder =>
                {
                    builder.UseInMemoryDatabase($"InMemoryDatabase{Guid.NewGuid()}");
                });
            }).UseStartup<Startup>();
            var server = new TestServer(host);
            var client = server.CreateClient();
            return client;
        }
    }
}
