using Ceiba.WPFParkingLotADN.Exeptions;
using Ceiba.WPFParkingLotADN.Services.AlreadyRegisterCarValidator;
using Ceiba.WPFParkingLotADN.Services.ParkingLotCreator;
using Ceiba.WPFParkingLotADN.Services.ParkingLotProvider;
using Ceiba.WPFParkingLotADN.Services.ParkingLotRelease;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ceiba.WPFParkingLotADN.Model;
public class ParkingRegistration
{
    private readonly IParkingLotProvider _parkingLotProvider;
    private readonly IParkingLotCreator _parkingLotCreator;
    private readonly IAlreadyRegisteredCarValidator _alreadyRegisteredCarValidator;
    private readonly IReleaseParkingLot _releaseParkingLot;

    public ParkingRegistration(IParkingLotProvider parkingLotProvider,
                               IParkingLotCreator parkingLotCreator,
                               IAlreadyRegisteredCarValidator alreadyRegisteredCarValidator,
                               IReleaseParkingLot releaseParkingLot)
    {
        _parkingLotProvider = parkingLotProvider;
        _parkingLotCreator = parkingLotCreator;
        _alreadyRegisteredCarValidator = alreadyRegisteredCarValidator;
        _releaseParkingLot = releaseParkingLot;
    }
    public async Task<IEnumerable<ParkingRecord>> GetAllParkingRecords() => await _parkingLotProvider.GetParkingRecordsAsync();

    public async Task RegisterVehicle(ParkingRecord parkingRecord)
    {
        var isRegistered = await _alreadyRegisteredCarValidator.AlreadyRegisteredAsync(parkingRecord);
        if (isRegistered)
        {
            throw new AlreadyParkedException($"Vehicle {parkingRecord.Plate} is already parked.");
        }
        await _parkingLotCreator.RegisterVehicle(parkingRecord);
    }
    public async Task<decimal> ReleaseVehicle(Guid Id) => await _releaseParkingLot.ReleaseParkingLot(Id);

}
