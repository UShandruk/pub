using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleLibrary;

namespace TriangleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal a = 3;
            decimal b = 4;
            decimal c = 5;
            double result;

            //var result = new TriangleService().CalculateSquare(a, b, c);
            var triangleService = new TriangleService();
            result = triangleService.CalculateSquare(a, b, c);

            Console.WriteLine("Площадь равна {0}", result);

            Console.ReadKey();
        }
    }
}
