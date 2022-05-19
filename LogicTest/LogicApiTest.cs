using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using Data;

namespace LogicTest
{
    [TestClass]
    public class LogicApiTest
    {
        [TestMethod]
        public void LogicApiTests()
        {
            LogicApi logicApi = LogicApi.CreateApi();
            DataApi dataApi = DataApi.CreateAPI();

            logicApi.BallsCreating(1, 4, 5);
            Assert.AreEqual(5, logicApi.GetBalls().Count);

            foreach (LogicBall ball in logicApi.GetBalls())
            {
                Assert.AreEqual(ball.Radius, 1);
                Assert.IsTrue(ball.X >= ball.Radius && ball.X <= (700 - ball.Radius));
                Assert.IsTrue(ball.Y >= ball.Radius && ball.Y <= (400 - ball.Radius));
            }

            logicApi.Start();

            foreach (LogicBall ball in logicApi.GetBalls())
            {           
                Assert.IsTrue(ball.X >= ball.Radius && ball.X <= (700 - ball.Radius));
                Assert.IsTrue(ball.Y >= ball.Radius && ball.Y <= (400 - ball.Radius));
            }

            logicApi.Stop();

        }
    }
}
