using System;
using System.Threading.Tasks;

namespace Ceiba.WPFParkingLotADN.Services.ParkingLotRelease;

public interface IReleaseParkingLot
{
    Task<decimal> ReleaseParkingLot(Guid Id);
}
