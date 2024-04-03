using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Logger
{
    public interface ILogger
    {
        void Log(LogEntry entry);
    }
}
