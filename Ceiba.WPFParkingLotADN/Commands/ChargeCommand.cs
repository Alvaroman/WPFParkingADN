using Ceiba.WPFParkingLotADN.Model;
using Ceiba.WPFParkingLotADN.Stores;
using Ceiba.WPFParkingLotADN.ViewModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Ceiba.WPFParkingLotADN.Commands;

public class ChargeCommand : AsyncCommandBase
{
    private readonly ParkingLotStore _parkingLotStore;
    private readonly VehicleParkedViewModel _vehicleParkedViewModel;

    public ChargeCommand(ParkingLotStore parkingLotStore, VehicleParkedViewModel vehicleParkedViewModel)
    {
        _parkingLotStore = parkingLotStore;
        _vehicleParkedViewModel = vehicleParkedViewModel;
    }
    public override async Task ExecuteAsync(object? parameter)
    {
        var cost = await _parkingLotStore.GetCharge(_vehicleParkedViewModel.Id);
        MessageBox.Show($"The charge up to now is: {cost}.", "Sucess", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}
