using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Logger
{
    public class ConsoleLogger : ILogger
{
    public void Log(LogEntry entry) => Console.WriteLine(
      $"[{entry.Severity}] {DateTime.Now} {entry.Message} {entry.Exception}");
}
}
