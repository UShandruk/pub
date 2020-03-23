using System;
using System.Collections.Generic;
using System.Text;

namespace SquareCalcLibrary.Figures
{
    /// <summary>
    /// Круг
    /// </summary>
    public class Circle
    {
        /// <summary>
        /// Вычислить площадь круга по его радиусу.
        /// </summary>
        /// <param name="radius">Радиус круга.</param>
        /// <returns>Площадь круга.</returns>
        public static double CalculateSquare(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Радиус круга должен быть больше нуля.");

            double square = Math.PI * radius * radius;

            return square;
        }
    }
}