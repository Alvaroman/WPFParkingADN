using Ceiba.WPFParkingLotADN.Exeptions;
using Ceiba.WPFParkingLotADN.Services.AlreadyRegisterCarValidator;
using Ceiba.WPFParkingLotADN.Services.ParkingLotCreator;
using Ceiba.WPFParkingLotADN.Services.ParkingLotProvider;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ceiba.WPFParkingLotADN.Model;
public class ParkingRegistration
{
    private readonly IParkingLotProvider _parkingLotProvider;
    private readonly IParkingLotCreator _parkingLotCreator;
    private readonly IAlreadyRegisteredCarValidator _alreadyRegisteredCarValidator;

    public ParkingRegistration(IParkingLotProvider parkingLotProvider, IParkingLotCreator parkingLotCreator, IAlreadyRegisteredCarValidator alreadyRegisteredCarValidator)
    {
        _parkingLotProvider = parkingLotProvider;
        _parkingLotCreator = parkingLotCreator;
        _alreadyRegisteredCarValidator = alreadyRegisteredCarValidator;
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
}
