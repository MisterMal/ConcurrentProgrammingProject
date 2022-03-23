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

            double resultAdd = program.Add(2, 2);
            Assert.AreEqual(resultAdd, 4);

            double resultSubtract = program.Subtract(4, 3.5);
            Assert.AreEqual(resultSubtract, 0.5);

            double resultMultiply = program.Multiply(2.5, 2);
            Assert.AreEqual(resultMultiply, 5);

            double resultDivide = program.Divide(9, 3);
            Assert.AreEqual(resultDivide, 3);

        }
    }
}
