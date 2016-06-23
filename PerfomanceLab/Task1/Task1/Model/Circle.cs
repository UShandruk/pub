using System;

namespace Task1.Model
{
    public class Circle : Figure
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
        {
            double area = 3.141 * radius;
            return Math.Round(area, 3);
        }
    }
}
