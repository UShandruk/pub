using System;

namespace Task1.Model
{
    public class Triangle : Figure
    {
        private double sideA;
        private double sideB;
        private double sideC;

        public Triangle(double sideA, double sideB, double sideC)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }


        public override double CalculateArea()
        {
            double p = (sideA + sideB + sideC) / 2;
            double pre = p * (p - sideA) * (p - sideB) * (p - sideC);
            double area = Math.Sqrt(Convert.ToDouble(pre));

            return Math.Round(area, 3);
        }
    }
}
