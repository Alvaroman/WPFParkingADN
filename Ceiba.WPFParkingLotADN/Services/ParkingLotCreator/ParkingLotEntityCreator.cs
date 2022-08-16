using Ceiba.WPFParkingLotADN.Exceptions;
using Ceiba.WPFParkingLotADN.Model;
using Ceiba.WPFParkingLotADN.Services.Response;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ceiba.WPFParkingLotADN.Services.ParkingLotCreator;
public class ParkingLotEntityCreator : ServiceConnection, IParkingLotCreator
{
    public async Task RegisterVehicle(ParkingRecord parkingLotDto)
    {
        var parkingLotJson = new StringContent(JsonConvert.SerializeObject(parkingLotDto), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("", parkingLotJson);
        if (!response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var message = JsonConvert.DeserializeObject<Result>(result);
            throw new ApplicationException(message.message);
        }
    }
}
