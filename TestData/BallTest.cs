using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace TestData
{
    [TestClass]
    public class BallTest
    {
        [TestMethod]
        public void CreateBallTest()
        {
            Ball ballTest = new Ball(2, 5, 1);

            Assert.AreEqual(ballTest.Radius, 2);
            Assert.AreEqual(ballTest.Mass, 5);

            Assert.IsTrue(!ballTest.Flag);

            ballTest.Move();

            Assert.IsTrue(ballTest.Flag);

        }
    }
}
