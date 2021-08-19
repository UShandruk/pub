using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestOOP
{
    /// <summary>
    /// Класс для записи логов в файл
    /// </summary>
    public class FileLogWriter : ILogWriter
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message"></param>
        public FileLogWriter()
        {
        }

        public void LogInfo(string message)
        {
            writeLog(message, Model.Model.MessageTypes.Info.ToString());
        }

        public void LogWarning(string message)
        {
            writeLog(message, Model.Model.MessageTypes.Warning.ToString());
        }

        public void LogError(string message)
        {
            writeLog(message, Model.Model.MessageTypes.Error.ToString());
        }

        private void writeLog(string message, string messageType)
        {
            // YYYY-MM-DDTHH:MM:SS+0000 <tab> MessageType <tab> Message, где MessageType может быть “Info”, “Warning” или “Error”.
            String strDdateTime = DateTime.Now.ToString("YYYY-MM-DDTHH:MM:SS+0000");

            string formattedMessage = strDdateTime + "\t" + messageType + "\t" + message;
            string filePath = new Config().FilePath; 
            using StreamWriter file = new(filePath, append: true);
            file.WriteLineAsync(formattedMessage);
        }
    }
}