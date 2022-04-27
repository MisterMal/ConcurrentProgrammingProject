using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Tests
{
    [TestClass]
    public class LogicApiTest
    {

        [TestMethod]
        public void checkValues()
        {
            LogicApi logicAPI = LogicApi.CreateApi();

            logicAPI.BallsCreating(1, 1, 1, 5);

            Assert.AreEqual(5, logicAPI.GetBallList().Count);

            foreach (Ball ball in logicAPI.GetBallList())
            {
                Assert.IsTrue(ball.X <= (700 - ball.Radius) && ball.X >= ball.Radius);
                Assert.IsTrue(ball.Y <= (400 - ball.Radius) && ball.Y >= ball.Radius);
                Assert.AreEqual(1, ball.Radius);
            }
        }
    }
}
