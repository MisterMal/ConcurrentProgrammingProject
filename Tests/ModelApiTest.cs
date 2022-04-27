using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace Tests
{
    [TestClass]
    public class ModelApiTest
    {

        [TestMethod]
        public void checkValues()
        {
            ModelApi modelAPI = ModelApi.CreateApi();

            modelAPI.Visualisation(1, 1, 1, 5);
            Assert.AreEqual(modelAPI.BallModelsCollection.Count, 5);

            foreach (BallModel ballModel in modelAPI.BallModelsCollection)
            {
                Assert.IsTrue(ballModel.X <= (700 - ballModel.Radius) && ballModel.X >= ballModel.Radius);
                Assert.IsTrue(ballModel.Y <= (400 - ballModel.Radius) && ballModel.Y >= ballModel.Radius);
                Assert.AreEqual(ballModel.DoubleRadius, 2);
            }

        }
    }
}
