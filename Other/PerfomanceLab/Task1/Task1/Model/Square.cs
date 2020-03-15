using System;

namespace Task1.Model
{
    public class Square : Figure
    {
        private double side;

        public Square(double side)
        {
            this.side = side;
        }

        public override double CalculateArea()
        {
            double area = side * side;
            return Math.Round(area, 3);
        }
    }
}
