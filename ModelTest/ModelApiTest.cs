using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace ModelTest
{
    [TestClass]
    public class ModelApiTest
    {
        [TestMethod]
        public void ModelApiTests()
        {
            ModelApi api = ModelApi.CreateApi();

            api.Visualisation(5, 5, 1, 4, 8);
            Assert.AreEqual(api.BallModelsCollection.Count, 8);

            foreach (BallModel ballModel in api.BallModelsCollection)
            {
                Assert.AreEqual(ballModel.DoubleRadius, 2);
                Assert.IsTrue(ballModel.X >= ballModel.Radius && ballModel.X <= (700 - ballModel.Radius));
                Assert.IsTrue(ballModel.Y >= ballModel.Radius && ballModel.Y <= (400 - ballModel.Radius));
            }

        }
    }
}
