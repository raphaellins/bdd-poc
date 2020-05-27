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
using pisoms.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pisoms.Models;

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

                builder.ConfigureServices(services =>
                {


                    var serviceProvider = new ServiceCollection()
                                    .AddEntityFrameworkInMemoryDatabase()
                                    .BuildServiceProvider();

                    services.AddDbContext<DataContext>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryDbForTesting");
                        options.UseInternalServiceProvider(serviceProvider);
                    });

                    var sp = services.BuildServiceProvider();
                    using (var scope = sp.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var db = scopedServices.GetRequiredService<DataContext>();

                        db.Database.EnsureCreated();

                        try
                        {
                            initateDatabase(db);
                        }
                        catch (Exception ex)
                        {
                            //TODO An error occurred seeding the database. Error: {Message}
                        }
                    }

                    services.AddScoped<ICategoryService, CategoryServiceMock>();
                });
            }); ;

            Instance.CreateClient();

        }

        public static async void initateDatabase(DataContext db)
        {
            db.Categories.Add(new Category
            {
                Id = 9928,
                Title = "Recorded Before"
            });

            await db.SaveChangesAsync();
        }

        public static void Dispose() => Instance.Dispose();
    }
}