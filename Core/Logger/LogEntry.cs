
namespace Core.Logger
{
    public struct LogEntry
    {
        public LoggingEventType Severity { get; }
        public string Message { get; }
        public Exception Exception { get; }

        public LogEntry(LoggingEventType severity, string msg, Exception ex = null)
        {
            if (msg is null) throw new ArgumentNullException("msg");
            if (msg == string.Empty) throw new ArgumentException("empty", "msg");

            this.Severity = severity;
            this.Message = msg;
            this.Exception = ex;
        }
    }
}
