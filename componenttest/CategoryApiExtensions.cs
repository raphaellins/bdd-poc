using System;
using System.Net.Http;
using System.Threading.Tasks;
using pisoms.Models;

namespace componenttest
{
    internal static class CategoryApiExtensions
    {
        public static Task<HttpResponseMessage> CreateCategory(this HttpClient client, Category createCustomerRequest)
        {
            return client.PostAsync("v1/categories", createCustomerRequest.ToJsonContent());
        }

        public static Task<HttpResponseMessage> ListCategory(this HttpClient client)
        {
            return client.GetAsync($"v1/categories");
        }

        // public static Task<HttpResponseMessage> DeleteCustomerById(this HttpClient client, Guid id)
        // {
        //     return client.DeleteAsync($"v1/categories/{id}");
        // }
    }
}