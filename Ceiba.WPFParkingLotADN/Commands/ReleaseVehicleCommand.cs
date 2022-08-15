using Ceiba.WPFParkingLotADN.Stores;
using Ceiba.WPFParkingLotADN.ViewModel;
using System.Threading.Tasks;
using System.Windows;

namespace Ceiba.WPFParkingLotADN.Commands;

public class ReleaseVehicleCommand : AsyncCommandBase
{
    private readonly ParkingLotStore _parkingLotStore;
    private readonly ParkVehicleViewModel _parkVehicleViewModel;

    public ReleaseVehicleCommand(ParkingLotStore parkingLotStore, ParkVehicleViewModel parkVehicleViewModel)
    {
        _parkingLotStore = parkingLotStore;
        _parkVehicleViewModel = parkVehicleViewModel;
    }
    public override async Task ExecuteAsync(object? parameter)
    {
        var cost = await _parkingLotStore.ReleaseVehicle(_parkVehicleViewModel.Id);
        MessageBox.Show($"Vehicle releaes correctly. The cost is: {cost}.", "Sucess", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}
