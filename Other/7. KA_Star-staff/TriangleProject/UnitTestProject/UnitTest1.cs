using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculateTriangleSquare()
        {
            //Arrange - подготовка
            TriangleService triangleService = new TriangleService();

            decimal a = 3;
            decimal b = 4;
            decimal c = 5;

            //Act - выполнение тестируемого действия (вызов тестироемого метода)
            double result = triangleService.CalculateSquare(a, b, c);

            //Assert - проверка предположения
            Assert.AreEqual(6, result);

        }
    }
}
