using LightBDD.Framework;
using System.Net.Http;
using LightBDD.XUnit2;
using pisoms.Models;
using System.Threading.Tasks;
using Xunit;
using System.Net;
using Moq;
using pisoms.Data;
using Microsoft.EntityFrameworkCore;
using pisoms.Service;
using pisoms.Services.Interfaces;
using System;

namespace componenttest.Features
{

    public partial class Logistica_feature : FeatureFixture
    {
        private readonly HttpClient _client;
        private State<Category> _categoryRequest;
        private State<HttpResponseMessage> _response;

        public Logistica_feature()
        {
            _client = TestServer.GetClient();
        }

        private async Task Given_iam_in()
        {
            _categoryRequest = new Category
            {
                Id = 99929,
                Title = "My Category"
            };
        }

        private async Task When_add_product()
        {

             _response = await _client.ListCategory();
        }

        private async Task Then_i_can()
        {
            Assert.Equal(HttpStatusCode.OK, _response.GetValue().StatusCode);
            var content = _response.GetValue().Content;

            Console.WriteLine(content.ReadAsStringAsync().Result);
        }

    }
}