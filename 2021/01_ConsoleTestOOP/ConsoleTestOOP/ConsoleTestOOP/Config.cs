using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestOOP
{
    /// <summary>
    /// Настройки программы
    /// </summary>
    public class Config
    {
        public Config()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var config = new ConfigurationBuilder().SetBasePath(basePath)
            .AddJsonFile("Config.json").Build();
            FilePath = basePath + config.GetSection("Filepath").Value;
        }

        /// <summary>
        /// Путь к файлу с логом
        /// </summary>
        public string FilePath;
    }
}
