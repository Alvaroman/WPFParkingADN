using System;
using System.Runtime.Serialization;
namespace Ceiba.WPFParkingLotADN.Exceptions;

[Serializable]
public class VehicleNotAllowedException : ApplicationException
{
    public VehicleNotAllowedException()
    {
    }

    public VehicleNotAllowedException(string? message) : base(message)
    {
    }

    public VehicleNotAllowedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected VehicleNotAllowedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
