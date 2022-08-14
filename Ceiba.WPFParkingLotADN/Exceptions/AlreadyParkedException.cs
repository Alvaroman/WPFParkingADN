using System;
using System.Runtime.Serialization;

namespace Ceiba.WPFParkingLotADN.Exeptions
{
    [Serializable]
    public class AlreadyParkedException : ApplicationException
    {
        public AlreadyParkedException()
        {
        }

        public AlreadyParkedException(string? message) : base(message)
        {
        }

        public AlreadyParkedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AlreadyParkedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
