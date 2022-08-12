using Ceiba.WPFParkingLotADN.Dto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ceiba.WPFParkingLotADN.Services.ParkingLotProvider;
public class ParkingLotEntitiesProvider : ServiceConnection, IParkingLotProvider
{
    public async Task<IEnumerable<ParkingLotDto>> GetParkingLotAsync()
    {
        var client = new HttpClient();
        var result = await client.GetAsync($"{BASE_URL}parking");
        Console.Write(result);
        return null;
    }
}