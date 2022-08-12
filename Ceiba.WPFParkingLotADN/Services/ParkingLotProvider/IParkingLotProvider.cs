using Ceiba.WPFParkingLotADN.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ceiba.WPFParkingLotADN.Services.ParkingLotProvider;
public interface IParkingLotProvider
{
    Task<IEnumerable<ParkingLotDto>> GetParkingLotAsync();
}
