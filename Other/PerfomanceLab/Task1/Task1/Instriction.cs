using System;

namespace Task1
{
    public class Instriction
    {
        public void DisplayInstruction()
        {
            Console.WriteLine("Программа запущена с неверными параметрами");
            Console.WriteLine("Примеры запуска через командную строку:");
            Console.WriteLine("test.exe square 4       – расчет площади квадрата со стороной 4");
            Console.WriteLine("test.exe circle 1       – расчет площади круга с радиусом 1");
            Console.WriteLine("test.exe triangle 2 3 1 – расчет площади треугольника со сторонами 2, 3, 1");
            Console.WriteLine("test.exe hexagon 3      – расчет площади правильного шестиугольника со стороной 3");
            Console.Read();
        }
    }
}
