using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLab1Test.Helpers
{
    public class LogAnalyzer
    {
        public bool IsValidLogFileName(string fileName)
        {
            if (!fileName.EndsWith(".SLF"))
            {
                return false;
            }
            return true;
        }

        public bool SendMessageToServer(string message)
        {
            Random random = new Random();
            return random.Next(0, 1) == 1;
        }
    }
}
