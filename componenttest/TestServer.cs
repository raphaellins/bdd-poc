using System;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using pisomsapp;
using System.IO;
using Microsoft.Extensions.Configuration;
using Xunit;
using Moq;
using pisoms.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using pisoms.Service;
using componenttest.MockedServices;

namespace componenttest
{
    internal class TestServer : IClassFixture<WebApplicationFactory<Startup>>
    {

        private static WebApplicationFactory<Startup> Instance { get; set; }

        public static HttpClient GetClient() => Instance?.CreateDefaultClient()
           ?? throw new InvalidOperationException($"{nameof(TestServer)} not initialized.");

        public static void Initialize()
        {
            var projectDir = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(projectDir, "appsettings.Testing.json");

            Instance = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureAppConfiguration((context, conf) =>
                {
                    conf.AddJsonFile(configPath);
                });

                builder.ConfigureServices(s =>
                {
                   s.AddScoped<ICategoryService, CategoryServiceMock>();
                });
            }); ;

            Instance.CreateClient();

        }

        public static void Dispose() => Instance.Dispose();
    }
}