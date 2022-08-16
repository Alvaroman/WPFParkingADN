using Ceiba.WPFParkingLotADN.Model;
using Ceiba.WPFParkingLotADN.Stores;
using Ceiba.WPFParkingLotADN.ViewModel;
using System.Threading.Tasks;
using System.Windows;

namespace Ceiba.WPFParkingLotADN.Commands;

public class ReleaseVehicleCommand : AsyncCommandBase
{
    private readonly ParkingLotStore _parkingLotStore;
    private readonly VehicleParkedViewModel _vehicleParkedViewModel;
    private readonly VehicleListingViewModel _vehicleListingViewModel;

    public ReleaseVehicleCommand(ParkingLotStore parkingLotStore, 
                                 VehicleParkedViewModel vehicleParkedViewModel,
                                 VehicleListingViewModel vehicleListingViewModel)
    {
        _parkingLotStore = parkingLotStore;
        _vehicleParkedViewModel = vehicleParkedViewModel;
        _vehicleListingViewModel = vehicleListingViewModel;
    }
    public override async Task ExecuteAsync(object? parameter)
    {
        var cost = await _parkingLotStore.ReleaseVehicle(_vehicleParkedViewModel.Id);
        _vehicleListingViewModel.UpdateParkedVehicles(_parkingLotStore.ParkedVehicles);
        MessageBox.Show($"Vehicle released correctly. The cost is: {cost}.", "Sucess", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}
