using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        public void CircleTests_CalculateSquare_PozitiveRadius()
        {
            double actual = SquareCalcLibrary.SquareCalculator.CalculateSquare_Circle(2.1);
            double expected = 13.854423602330988;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CircleTests_CalculateSquare_ZeroRadius()
        {
            double actual = SquareCalcLibrary.SquareCalculator.CalculateSquare_Circle(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CircleTests_CalculateSquare_NegativeRadius()
        {
            double actual = SquareCalcLibrary.SquareCalculator.CalculateSquare_Circle(-2.1);
        }
    }
}
