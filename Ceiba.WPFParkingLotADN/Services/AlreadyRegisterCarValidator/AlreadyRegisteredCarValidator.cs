using Ceiba.WPFParkingLotADN.Dto;
using System;
using System.Threading.Tasks;

namespace Ceiba.WPFParkingLotADN.Services.AlreadyRegisterCarValidator;
public class AlreadyRegisteredCarValidator : ServiceConnection, IAlreadyRegisteredCarValidator
{
    public async Task<bool> AlreadyRegisteredAsync(ParkingLotDto parkingLot)
    {
        var result = await _client.GetAsync("parking");
        Console.Write(result);
        return true;
    }
}
