using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EapLab.Transport.Logging
{
    public class ConsoleLogSink : ILogSink
    {
        public void Log(LogDir dir, string message)
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff}| {Environment.CurrentManagedThreadId:D2} | {dir ,-3}|{message}");
        }
    }
}
