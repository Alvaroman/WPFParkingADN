using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ceiba.WPFParkingLotADN.Model;
public class ParkingLot
{
    private readonly ParkingRegistration _parkingRegistration;

    public ParkingLot(ParkingRegistration parkingRegistration)
    {
        _parkingRegistration = parkingRegistration;
    }
    public async Task<IEnumerable<ParkingRecord>> GetParkingRecords() => await _parkingRegistration.GetAllParkingRecords();
    public async Task ParkVehicle(ParkingRecord parkingRecord) => await _parkingRegistration.RegisterVehicle(parkingRecord);
    public async Task<decimal> ReleaseVehicle(Guid Id) => await _parkingRegistration.ReleaseVehicle(Id);
    public async Task<decimal> GetCharge(Guid Id) => await _parkingRegistration.GetCharge(Id);

}
