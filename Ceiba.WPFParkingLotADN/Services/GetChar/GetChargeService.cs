using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Ceiba.WPFParkingLotADN.Services.GetChar;
public class GetChargeService : ServiceConnection, IGetChargeService
{
    public async Task<decimal> GetCharge(Guid Id)
    {
        var response = await _client.GetAsync($"{Id}/cost");
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<decimal>(result);
    }
}
