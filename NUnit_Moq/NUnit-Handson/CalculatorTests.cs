using NUnit.Framework;

namespace NUnitHandson
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void Add_Test()
        {
            Assert.AreEqual(10, calculator.Add(5, 5));
        }

        [Test]
        public void Subtract_Test()
        {
            Assert.AreEqual(5, calculator.Subtract(10, 5));
        }

        [Test]
        public void Multiply_Test()
        {
            Assert.AreEqual(20, calculator.Multiply(4, 5));
        }

        [Test]
        public void Divide_Test()
        {
            Assert.AreEqual(2, calculator.Divide(10, 5));
        }
    }
}