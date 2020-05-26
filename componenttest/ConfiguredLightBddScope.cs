using componenttest;
using LightBDD.XUnit2;

[assembly: ClassCollectionBehavior(AllowTestParallelization = true)]
[assembly: ConfiguredLightBddScope]

namespace componenttest
{
    internal class ConfiguredLightBddScopeAttribute : LightBddScopeAttribute
    {
        protected override void OnSetUp()
        {
            TestServer.Initialize();
        }

        protected override void OnTearDown()
        {
            TestServer.Dispose();
        }
    }
}