using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace TestData
{
    [TestClass]
    public class DataApiTest
    {
        [TestMethod]
        public void DataApiTests()
        {
            DataApi api = DataApi.CreateAPI();

            api.CreateBalls(1, 5, 4);
            Assert.AreEqual(4, api.GetBalls().Count);

            foreach (Ball ball in api.GetBalls())
            {
                Assert.AreEqual(ball.Flag, false);
                Assert.AreEqual(ball.Mass, 5);
                Assert.AreEqual(ball.Radius, 1);
            }
        }
    }
}
