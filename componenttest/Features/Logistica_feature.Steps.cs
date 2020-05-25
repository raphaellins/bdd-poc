using System.Linq;
using LightBDD.Framework;
using LightBDD.NUnit3;
using NUnit.Framework;
using System.Net.Http;

namespace componenttest.Features
{

    public partial class Logistica_feature : FeatureFixture
    {
        static HttpClient client = new HttpClient();

        [SetUp]
        public void SetUp()
        {
        }

        private void Given_iam_in()
        {
            Assert.That(true, Is.True);
        }

        private void When_add_product()
        {
            Assert.That(true, Is.False);
        }

        private void Then_i_can()
        {
            Assert.That(true, Is.True);
        }

    }
}