using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Tests
{
    [TestClass]
    public class BallTest
    {
        Ball ball = new Ball(1, 1, 1);

        [TestMethod]
        public void checkBallValuesTest()
        {
            Assert.AreEqual(1, ball.Radius);
            Assert.AreEqual(1, ball.XSpeed);
            Assert.AreEqual(1, ball.YSpeed);

            ball.Radius = 2;
            Assert.AreEqual(2, ball.Radius);
        }
    }
}
