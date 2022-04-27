using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace Tests
{
    [TestClass]
    public class DataApiTest
    {
        [TestMethod]
        public void checkConnectMethodTest()
        {
            Assert.ThrowsException<System.NotImplementedException>(() => DataApi.CreateAPI().Connect());
        }
    }
}
