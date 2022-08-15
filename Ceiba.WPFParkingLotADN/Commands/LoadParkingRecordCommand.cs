using Ceiba.WPFParkingLotADN.Stores;
using Ceiba.WPFParkingLotADN.ViewModel;
using System.Threading.Tasks;

namespace Ceiba.WPFParkingLotADN.Commands;

public class LoadParkingRecordCommand : AsyncCommandBase
{
    private readonly VehicleListingViewModel _viewModel;
    private readonly ParkingLotStore _parkingLotStore;

    public LoadParkingRecordCommand(VehicleListingViewModel viewModel, ParkingLotStore parkingLotStore)
    {
        _viewModel = viewModel;
        _parkingLotStore = parkingLotStore;
    }
    public override async Task ExecuteAsync(object? parameter)
    {
        _viewModel.ErrorMessage = string.Empty;
        try
        {
            _viewModel.IsLoading = true;
            await _parkingLotStore.Load();
            _viewModel.UpdateParkedVehicles(_parkingLotStore.ParkedVehicles);
        }
        catch (System.Exception ex)
        {
            _viewModel.ErrorMessage = $"Failed. {ex.Message}";
        }
        _viewModel.IsLoading = false;
    }
}
