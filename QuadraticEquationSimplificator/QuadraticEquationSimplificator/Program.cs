using QuadraticEquationSimplificator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquationSimplificator
{
    class Program
    {
        static void Main(string[] args)
        {
            MathParserService mathParserService = new MathParserService();
            if (args.Length == 0)
            {
                Console.Write("Введите уравнение:");
                string result = mathParserService.Parse(Console.ReadLine());
                Console.WriteLine("Результат:{0}", result);
                Console.Read();
            }
            else
            {
                string filePath = args[0];
                //string filePath = @"C:\Users\Chii\Desktop\QuadraticEquationSimplificator\Test.txt";//args[0];
                Console.WriteLine("Выбран путь к файлу: {0}", filePath);
                RWTextFile.WriteTextFile(mathParserService.Parse(RWTextFile.ReadTextFile(filePath)), filePath);
                //var dummy = Parser.Parse(RWTextFile.ReadTextFile(filePath));
                //Console.WriteLine(String.Join(Environment.NewLine, dummy));
                //Console.ReadLine();
            }
        }              
    }
}