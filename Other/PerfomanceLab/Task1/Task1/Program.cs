using System;
using Task1.Model;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] figures = new string[]
            {
                "circle",
                "hexagon",
                "square",
                "triangle"
            };

            try
            {
                string caseSwitch = args[0];

                switch (caseSwitch)
                {
                    case ("circle"):
                        Circle circle = new Circle(Convert.ToDouble(args[1]));
                        Console.WriteLine("Площадь круга с радиусом {0} равна {1}", args[1], circle.CalculateArea());
                        Console.Read();
                        break;
                    case "hexagon":
                        Hexagon hexagon = new Hexagon(Convert.ToDouble(args[1]));
                        Console.WriteLine("Площадь правильного шестиугольника со стороной {0} равна {1}", args[1], hexagon.CalculateArea());
                        Console.Read();
                        break;
                    case "square":
                        Square square = new Square(Convert.ToDouble(args[1]));
                        Console.WriteLine("Площадь квадрата со стороной {0} равна {1}", args[1], square.CalculateArea());
                        Console.Read();
                        break;
                    case "triangle":
                        Triangle triangle = new Triangle(Convert.ToDouble(args[1]), Convert.ToDouble(args[2]), Convert.ToDouble(args[3]));
                        Console.WriteLine("Площадь треугольника со сторонами {0}, {1} и {2} равна {3}", args[1], args[2], args[3], triangle.CalculateArea());
                        Console.Read();
                        break;
                    default:
                        Instriction instruction = new Instriction();
                        instruction.DisplayInstruction();
                        break;
                }
            }
            catch
            {
                Instriction instruction = new Instriction();
                instruction.DisplayInstruction();
            }
        }
    }
}
