using Ceiba.WPFParkingLotADN.Commands;
using Ceiba.WPFParkingLotADN.Model;
using Ceiba.WPFParkingLotADN.Services;
using Ceiba.WPFParkingLotADN.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Ceiba.WPFParkingLotADN.ViewModel;
public class VehicleListingViewModel : ViewModelBase
{
    private readonly ObservableCollection<VehicleParkedViewModel> _vehicles;
    private readonly ParkingLotStore _parkingLotStore;

    public VehicleListingViewModel(ParkingLotStore parkingLotStore,
                                   NavigationService<ParkVehicleViewModel> navigationService)
    {
        _parkingLotStore = parkingLotStore;
        ParkVehicleCommand = new NavigateCommand<ParkVehicleViewModel>(navigationService);
        LoadVehiclesCommand = new LoadParkingRecordCommand(this, parkingLotStore);
        _vehicles = new ObservableCollection<VehicleParkedViewModel>();
    }

    private bool _isLoading;

    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            _isLoading = value;
            OnPropertyChanged(nameof(IsLoading));
        }
    }

    private string _errorMessage;
    public string ErrorMessage
    {
        get => _errorMessage; set
        {
            _errorMessage = value;
            OnPropertyChanged(nameof(IsLoading));
        }
    }
    public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);
    public IEnumerable<VehicleParkedViewModel> Vehicles => _vehicles;
    public ICommand ParkVehicleCommand { get; }
    public ICommand LoadVehiclesCommand { get; }
    public ICommand ReleaseVehicleCommand { get; }

    public override void Dispose()
    {
        _parkingLotStore.VehicleRegistered -= OnVehicleParked;
        base.Dispose();
    }

    private void OnVehicleParked(ParkingRecord parkingRecord)
    {
        VehicleParkedViewModel vehicleParkedViewModel = new VehicleParkedViewModel(parkingRecord);
        _vehicles.Add(vehicleParkedViewModel);
    }
    public static VehicleListingViewModel LoadViewModel(ParkingLotStore parkingLotStore, NavigationService<ParkVehicleViewModel> navigationService)
    {
        VehicleListingViewModel viewModel = new VehicleListingViewModel(parkingLotStore, navigationService);
        viewModel.LoadVehiclesCommand.Execute(null);
        return viewModel;
    }
    public void UpdateParkedVehicles(IEnumerable<ParkingRecord> parkingRecords)
    {
        _vehicles.Clear();
        foreach (ParkingRecord vehicle in parkingRecords)
        {
            VehicleParkedViewModel vehicleParkedViewModel = new VehicleParkedViewModel(vehicle);
            _vehicles.Add(vehicleParkedViewModel);
        }

    }
}
