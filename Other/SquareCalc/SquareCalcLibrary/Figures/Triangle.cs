using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SquareCalcLibrary.Figures
{
    public class Triangle
    {
        /// <summary>
        /// Вычислить площадь треугольника по трем его сторонам.
        /// </summary>
        /// <param name="a">Первая сторона треугольника.</param>
        /// <param name="b">Вторая сторона треугольника.</param>
        /// <param name="c">Третья сторона треугольника.</param>
        /// <returns>Площадь треугольника.</returns>
        public static double CalculateSquare(double a, double b, double c)
        {
            CheckParametrs(a, b, c);

            double square = 0;

            var sides = new List<double> { a, b, c }.OrderBy(x => x);
            double sideOne = sides.ElementAtOrDefault(0);
            double sideTwo = sides.ElementAtOrDefault(1);
            double sideThree = sides.ElementAtOrDefault(2);

            // если с² = a² + b², то треугольник прямоугольный
            bool isRightTriangle = sideThree * sideThree == sideOne*sideOne + sideTwo * sideTwo;

            if (isRightTriangle)
            {
                square = 0.5 / (sideOne * sideTwo);
            }
            else
            {
                // полупериметр
                double p = (a + b + c) / 2;

                // нахождение площади по формуле Герона
                square = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
            return square;
        }

        /// <summary>
        /// Проверка параметров на допустимость.
        /// </summary>
        /// <param name="a">Первая сторона треугольника.</param>
        /// <param name="b">Вторая сторона треугольника.</param>
        /// <param name="c">Третья сторона треугольника.</param>
        private static bool CheckParametrs(double a, double b, double c)
        {
            bool isCorrect = false;

            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Значение каждой стороны треугольника должно быть больше нуля.");

            if (a + b <= c || a + c <= b || c + b <= a)
                throw new ArgumentException("Сумма длин двух сторон треугольника должна быть больше третьей стороны.");

            isCorrect = true;

            return isCorrect;
        }
    }
}