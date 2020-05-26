using LightBDD.Framework;
using System.Threading.Tasks;
using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;

namespace componenttest.Features
{

    [FeatureDescription(
        @"In order to buy products
        As a costumer
        I want to add products to basket"
    )]
    public partial class Logistica_feature : FeatureFixture
    {
        [Scenario]
        public async Task No_product_in_stock()
        {
            await Runner.RunScenarioAsync(
                   _ => Given_iam_in(),
                    _ => When_add_product(),
                    _ => Then_i_can());
        }
    }
}