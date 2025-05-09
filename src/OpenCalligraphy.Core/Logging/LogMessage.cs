using System.Text;

namespace OpenCalligraphy.Core.Logging
{
    /// <summary>
    /// A timestamped log message.
    /// </summary>
    public readonly struct LogMessage
    {
        private const string TimeFormat = "yyyy.MM.dd HH:mm:ss.fff";

        private static readonly StringBuilder StringBuilder = new();

        public DateTime Timestamp { get; }
        public LoggingLevel Level { get; }
        public string Logger { get; }
        public string Message { get; }

        /// <summary>
        /// Constructs a new <see cref="LogMessage"/> instance with the specified parameters.
        /// </summary>
        public LogMessage(LoggingLevel level, string logger, string message)
        {
            Timestamp = LogManager.LogTimeNow;
            Level = level;
            Logger = logger;
            Message = message;
        }

        public override string ToString()
        {
            return $"[{Timestamp.ToString(TimeFormat)}] [{Level,5}] [{Logger}] {Message}";
        }
    }
}
