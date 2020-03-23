using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        [Description("Расчет площади обычного (непрямоугольного) треугольника.")]
        public void TriangleTests_CalculateSquare_Triangle_PozitiveSides_IsTriangle()
        {
            double actual = SquareCalcLibrary.SquareCalculator.CalculateSquare_Triangle(2, 4, 3);
            double expected = 2.9047375096555625;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("Расчет площади прямоугольного треугольника.")]
        public void TriangleTests_CalculateSquare_Triangle_PozitiveSides_IsRightTriangle()
        {
            double actual = SquareCalcLibrary.SquareCalculator.CalculateSquare_Triangle(5, 3, 4);
            double expected = 0.041666666666666664;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("У одной из сторон нулевое значение.")]
        [ExpectedException(typeof(ArgumentException))]
        public void TriangleTests_CalculateSquare_Triangle_ZeroSide()
        {
            double actual = SquareCalcLibrary.SquareCalculator.CalculateSquare_Triangle(3, 4.7, 0);
        }

        [TestMethod]
        [Description("У одной из сторон отрицательное значение.")]
        [ExpectedException(typeof(ArgumentException))]
        public void TriangleTests_CalculateSquare_Triangle_NegativeSide()
        {
            double actual = SquareCalcLibrary.SquareCalculator.CalculateSquare_Triangle(5.7, -7.6, 9);
        }

        [TestMethod]
        [Description("Сумма длин двух сторон треугольника должна быть больше третьей стороны.")]
        [ExpectedException(typeof(ArgumentException))]
        public void TriangleTests_CalculateSquare_Triangle_ImpossibleSides()
        {
            double actual = SquareCalcLibrary.SquareCalculator.CalculateSquare_Triangle(1, 2, 3);
        }
    }
}
