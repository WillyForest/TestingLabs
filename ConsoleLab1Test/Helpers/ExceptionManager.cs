using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLab1Test.Helpers
{
    public class ExceptionManager
    {
        public static int exceptionsCount = 0, criticalExceptionsCount = 0, sendingErrors = 0;
        public static string _configFile = "F:/Projects/config.txt";

        public List<string> GetCriticalExceptions()
        {
            if (!File.Exists(_configFile))
            {
                var contents = new List<string>()
                {
                    new FileNotFoundException().GetType().FullName,
                    new OutOfMemoryException().GetType().FullName,
                    new ArgumentOutOfRangeException().GetType().FullName,
                    new ArgumentNullException().GetType().FullName,
                    new ArgumentOutOfRangeException().GetType().FullName,
                    new FormatException().GetType().FullName
                };
                File.WriteAllLines(_configFile, contents);
            }
            return File.ReadAllLines(_configFile).ToList();
        }

        public bool IsExceptionCritical (Exception exception)
        {
            if (GetCriticalExceptions().Contains(exception.GetType().FullName))
            {
                return true;
            }
            return false;
        }

        public void ProcessException (Exception exception)
        {
            if (IsExceptionCritical(exception))
            {
                criticalExceptionsCount++;
                if (SendWarningToServer(exception))
                {
                    sendingErrors++;
                }
            }
            else
            {
                exceptionsCount++;
            }
        }

        public bool SendWarningToServer(Exception exception)
        {
            LogAnalyzer logAnalyzer = new LogAnalyzer();
            return logAnalyzer.SendMessageToServer(string.Format("[WARNING]: {0}", exception.Message));
        }

        public int GetCriticalExceptionsCount()
        {
            return criticalExceptionsCount;
        }

        public int GetNonCriticalExceptionsCount()
        {
            return exceptionsCount;
        }
    }
}
