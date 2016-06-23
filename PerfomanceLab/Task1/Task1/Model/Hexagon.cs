using System;

namespace Task1.Model
{
    public class Hexagon : Figure
    {
        private double side;

        public Hexagon(double side)
        {
            this.side = side;
        }


        public override double CalculateArea()
        {
            double area = (3 * Math.Sqrt(3) * (side*side))/2;
            return Math.Round(area, 3);
        }
    }
}
