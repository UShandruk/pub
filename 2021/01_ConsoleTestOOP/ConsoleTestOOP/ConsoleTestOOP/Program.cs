using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace ConsoleTestOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            FileLogWriter fileLogWriter = new FileLogWriter();
            ConsoleLogWriter consoleLogWriter = new ConsoleLogWriter();
            
            List<ILogWriter> logwriters = new List<ILogWriter>();
            logwriters.Add(fileLogWriter);
            logwriters.Add(consoleLogWriter);
            MultipleLogWriter multipleLogWriter = new MultipleLogWriter(logwriters);

            //● Сделать по одной записи логов каждого типа,
            //чтобы убедиться, что они одновременно пишутся и в консоль и в файл.
            multipleLogWriter.Write("Тестовое сообщение LogInfo", Model.Model.MessageTypes.Info.ToString());
            multipleLogWriter.Write("Тестовое сообщение LogWarning", Model.Model.MessageTypes.Warning.ToString());
            multipleLogWriter.Write("Тестовое сообщение LogError", Model.Model.MessageTypes.Error.ToString());
        }
    }
}
