using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    public class TriangleService
    {
        public double CalculateSquare(decimal a, decimal b, decimal c)
        {
            decimal p = (a + b + c) / 2;

            decimal pre = p * (p - a) * (p - b) * (p - c);

            double result = Math.Sqrt(Convert.ToDouble(pre));
            return result;
        }
    }
}
