using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestOOP
{
    /// <summary>
    /// Класс для записи логов в файл
    /// </summary>
    public class MultipleLogWriter : ILogWriter
    {
        private List<ILogWriter> _logWriters;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message"></param>
        public MultipleLogWriter(List<ILogWriter> logWriters)
        {
            _logWriters = logWriters;
        }

        public void Write(string message, string messageType)
        {
            if(_logWriters.Count > 0)
            {
                foreach(ILogWriter logWriter in _logWriters)
                {
                    if(messageType.Equals(Model.Model.MessageTypes.Info.ToString()))
                    {
                        logWriter.LogInfo(message);                        
                    }
                    else if (messageType.Equals(Model.Model.MessageTypes.Warning.ToString()))
                            {
                        logWriter.LogWarning(message);
                    }
                    else
                    {
                        logWriter.LogError(message);
                    }                
                }
            }
        }

        public void LogInfo(string message)
        {
        }

        public void LogWarning(string message)
        {
        }

        public void LogError(string message)
        {
        }
    }
}
