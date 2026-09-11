using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EapLab.Transport.Logging
{
    public enum LogDir {TX ,TR ,EVT,ERR }
    public interface ILogSink
    {
        void Log(LogDir dir,string message);
    }
}
