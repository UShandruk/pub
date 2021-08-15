using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestOOP
{
    public interface ILogWriter
    {
        void LogInfo(string message)
        {

        }
        void LogWarning(string message)
        {

        }
        void LogError(string message)
        {

        }
    }
}