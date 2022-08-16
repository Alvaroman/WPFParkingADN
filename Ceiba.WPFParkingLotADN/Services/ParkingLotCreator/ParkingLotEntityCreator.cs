using Ceiba.WPFParkingLotADN.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ceiba.WPFParkingLotADN.Services.ParkingLotCreator;
public class ParkingLotEntityCreator : ServiceConnection, IParkingLotCreator
{
    public async Task RegisterVehicle(ParkingRecord parkingLotDto)
    {
        var parkingLotJson = new StringContent(JsonConvert.SerializeObject(parkingLotDto), Encoding.UTF8, "application/json");
        await _client.PostAsync("", parkingLotJson);
    }
}
    