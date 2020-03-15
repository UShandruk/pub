using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquationSimplificator.Services
{
    public static class RWTextFile
    {
        public static string[] ReadTextFile(string filePath)
        {
            //string[] lines = System.IO.File.ReadAllLines("C:/Users/Chii/Desktop/QuadraticEquationSimplificator/Test.txt");
            //string[] lines = System.IO.File.ReadAllLines(@"Test.txt");  //ok
            //string[] lines = System.IO.File.ReadAllLines(@"filePath"); //ok
            string[] lines = System.IO.File.ReadAllLines(filePath); //System.NotSupportedException
            return lines;
        }
        public static void WriteTextFile(string[] parsedPolynomArray, string filePath)
        {
            System.IO.File.WriteAllLines (filePath + ".out", parsedPolynomArray);
        }
    }
}
