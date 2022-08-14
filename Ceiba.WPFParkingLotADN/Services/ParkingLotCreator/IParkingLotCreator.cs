using Ceiba.WPFParkingLotADN.Model;
using System.Threading.Tasks;
namespace Ceiba.WPFParkingLotADN.Services.ParkingLotCreator;

public interface IParkingLotCreator
{
    Task RegisterVehicle(ParkingRecord parkingLotDto);
}
