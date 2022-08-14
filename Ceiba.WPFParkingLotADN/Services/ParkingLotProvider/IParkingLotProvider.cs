using Ceiba.WPFParkingLotADN.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ceiba.WPFParkingLotADN.Services.ParkingLotProvider;
public interface IParkingLotProvider
{
    Task<IEnumerable<ParkingRecord>> GetParkingRecordsAsync();
}
