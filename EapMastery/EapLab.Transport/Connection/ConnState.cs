using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EapLab.Transport.Connection
{
    public enum ConnState
    {
        Disconnected,
        Listening,
        Connecting,
        Connected
    }
}
