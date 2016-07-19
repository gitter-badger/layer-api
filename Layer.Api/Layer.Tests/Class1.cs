using Layer.Api;
using Layer.Api.Contracts;

using NUnit.Framework;

namespace Layer.Tests
{
    public class Class1
    {
        [Test]
        public async void Test()
        {
            ILayerPlatformApi platformApi = new LayerPlatformApi(null, null, null, null);
        }
    }
}
