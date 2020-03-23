using SquareCalcLibrary.Figures;
using System;
using System.Collections.Generic;
using System.Text;

namespace SquareCalcLibrary
{
    public static class SquareCalculator
    {
        /// <summary>
        /// Вычислить площадь круга по его радиусу.
        /// </summary>
        /// <param name="radius">Радиус круга. Значение должно быть больше нуля.</param>
        /// <returns>Площадь круга.</returns>
        public static double CalculateSquare_Circle(double radius)
        {
            double square = Circle.CalculateSquare(radius);
            return square;
        }

        /// <summary>
        /// Вычислить площадь треугольника по трем его сторонам.
        /// </summary>
        /// <param name="a">Первая сторона треугольника. Значение должно быть больше нуля.</param>
        /// <param name="b">Вторая сторона треугольника. Значение должно быть больше нуля.</param>
        /// <param name="c">Третья сторона треугольника. Значение должно быть больше нуля.</param>
        /// <returns>Площадь треугольника.</returns>
        public static double CalculateSquare_Triangle(double a, double b, double c)
        {
            double square = Triangle.CalculateSquare(a, b, c);
            return square;
        }
    }
}
