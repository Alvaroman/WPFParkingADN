using Ceiba.WPFParkingLotADN.Model;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Ceiba.WPFParkingLotADN.Services.AlreadyRegisterCarValidator;
public class AlreadyRegisteredCarValidator : ServiceConnection, IAlreadyRegisteredCarValidator
{
    public async Task<bool> AlreadyRegisteredAsync(string plate)
    {
        var response = await _client.GetAsync($"{plate}/IsInParkingLot");
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<bool>(result);
    }
}
