using System.Runtime.Serialization;

namespace ASP_NET_gettingStarted.Model
{
    public class CountryException : Exception
    {
        public CountryException()
        {
        }

        public CountryException(string? message) : base(message)
        {
        }

        public CountryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CountryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
