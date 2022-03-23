using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var program = new Program();

            var resultAdd = program.Add(2, 2);
            Assert.AreEqual(resultAdd, 4);

            var resultSubtract = program.Subtract(4, 3.5);
            Assert.AreEqual(resultSubtract, 0.5);

            var resultMultiply = program.Multiply(2.5, 2);
            Assert.AreEqual(resultMultiply, 5);

            var resultDivide = program.Divide(9, 3);
            Assert.AreEqual(resultDivide, 3);

        }
    }
}
