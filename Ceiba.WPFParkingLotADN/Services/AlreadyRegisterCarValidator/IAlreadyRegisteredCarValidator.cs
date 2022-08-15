using Ceiba.WPFParkingLotADN.Model;
using System.Threading.Tasks;

namespace Ceiba.WPFParkingLotADN.Services.AlreadyRegisterCarValidator;
public interface IAlreadyRegisteredCarValidator
{
    Task<bool> AlreadyRegisteredAsync(ParkingRecord parkingLot);
}
