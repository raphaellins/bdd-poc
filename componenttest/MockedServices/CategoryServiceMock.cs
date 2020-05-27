
using pisoms.Services.Interfaces;

namespace componenttest.MockedServices
{
    public class CategoryServiceMock : ICategoryService
    {
        public string ReturnMessage()
        {
           return "MOCKEDDDDD";
        }
    }
}