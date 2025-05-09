namespace OpenCalligraphy.Core.Exceptions
{
    [Serializable]
    public class CalligraphyException : Exception
    {
        public CalligraphyException()
        {
        }

        public CalligraphyException(string message) : base(message)
        {
        }

        public CalligraphyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
