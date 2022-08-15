using Ceiba.WPFParkingLotADN.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ceiba.WPFParkingLotADN.Services.ParkingLotCreator;
public class ParkingLotEntityCreator : ServiceConnection, IParkingLotCreator
{
    public async Task RegisterVehicle(ParkingRecord parkingLotDto)
    {
        var parkingLotJson = new StringContent(JsonConvert.SerializeObject(parkingLotDto));
        await _client.PostAsync("", parkingLotJson);
    }
}
