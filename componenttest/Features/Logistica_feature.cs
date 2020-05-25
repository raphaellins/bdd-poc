using LightBDD.Framework;
using LightBDD.NUnit3;
using System.Threading.Tasks;
using LightBDD.Framework.Scenarios;

namespace componenttest.Features
{

    [FeatureDescription(
        @"In order to buy products
        As a costumer
        I want to add products to basket"
    )]
    public partial class Logistica_feature
    {
        [Scenario]
        [Label("Ticket-6")]
        public async Task No_product_in_stock()
        {
            await Runner.AddSteps(
                    Given_iam_in,
                    When_add_product,
                    Then_i_can)
                .RunAsync();
        }
    }
}