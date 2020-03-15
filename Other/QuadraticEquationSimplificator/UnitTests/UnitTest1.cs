using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuadraticEquationSimplificator.Services;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanParseString()
        {
            //Arrange
            string polynom = "1+2xy=x2+5";
            var target = new MathParserService();

            //Act
            var result = target.Parse(polynom);

            //Accert
            Assert.AreEqual(result, "2xy-x-4=0");
        }

        [TestMethod]
        public void CanParseArray()
        {
            //Arrange
            string[] polynoms = new string[] { "1+2xy=x2+5", "x2+6=x^2+7", "x2+8=3x^2" };
            var target = new MathParserService();

            //Act
            var result = target.Parse(polynoms);

            //Accert
            Assert.AreEqual(result[0], "2xy-x-4=0");
            Assert.AreEqual(result[1], "-x^2+x-=0");
            Assert.AreEqual(result[2], "-3x^2+x+8=0");
        }

        [TestMethod]
        public void CanOpenBraces()
        {
            //Arrange
            string polynom = "1x-(2x^2-3xy)=2xy";
            var target = new MathParserService();

            //Act
            var result = target.OpenBraces(polynom);

            //Accert
            Assert.AreEqual(result, "1x-2x^2+3xy=2xy");
        }
    }
}
