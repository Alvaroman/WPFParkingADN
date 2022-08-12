using Ceiba.WPFParkingLotADN.Dto;
using System.Threading.Tasks;

namespace Ceiba.WPFParkingLotADN.Services.AlreadyRegisterCarValidator;
public interface IAlreadyRegisteredCarValidator
{
    Task<bool> AlreadyRegisteredAsync(ParkingLotDto parkingLot);
}
