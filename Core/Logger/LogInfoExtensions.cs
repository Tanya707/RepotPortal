﻿
namespace Core.Logger
{
    public static class LogInfoExtensions
    {
        public static void Log(this ILogger logger, string message) =>
            logger.Log(new LogEntry(LoggingEventType.Information, message));

        public static void Log(this ILogger logger, Exception ex) =>
            logger.Log(new LogEntry(LoggingEventType.Error, ex.Message, ex));
    }
}