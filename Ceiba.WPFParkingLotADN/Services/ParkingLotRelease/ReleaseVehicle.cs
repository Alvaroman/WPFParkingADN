using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ceiba.WPFParkingLotADN.Services.ParkingLotRelease;
public class ReleaseVehicle : ServiceConnection, IReleaseParkingLot
{

    public async Task<decimal> ReleaseParkingLot(Guid Id)
    {
        var response = await _client.PutAsync($"{Id}/release", null);
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<decimal>(result);
    }
}
