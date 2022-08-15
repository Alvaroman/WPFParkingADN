using Ceiba.WPFParkingLotADN.Exeptions;
using Ceiba.WPFParkingLotADN.Model;
using Ceiba.WPFParkingLotADN.Services;
using Ceiba.WPFParkingLotADN.Stores;
using Ceiba.WPFParkingLotADN.ViewModel;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace Ceiba.WPFParkingLotADN.Commands;
public class ParkVehicleCommand : AsyncCommandBase
{
    private readonly ParkVehicleViewModel _parkVehicleViewModel;
    private readonly ParkingLotStore _parkingLotStore;
    private readonly NavigationService<VehicleListingViewModel> _navigationService;

    public ParkVehicleCommand(ParkVehicleViewModel parkVehicleViewModel,
                              ParkingLotStore parkingLotStore,
                              NavigationService<VehicleListingViewModel> navigationService)
    {
        _parkVehicleViewModel = parkVehicleViewModel;
        _parkingLotStore = parkingLotStore;
        _navigationService = navigationService;
        _parkVehicleViewModel.PropertyChanged += OnViewModelProperyChanged;
    }

    private void OnViewModelProperyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ParkVehicleViewModel.Plate)
            || e.PropertyName == nameof(ParkVehicleViewModel.Cylinder)
            || e.PropertyName == nameof(ParkVehicleViewModel.Status)
            || e.PropertyName == nameof(ParkVehicleViewModel.StartAt)
            || e.PropertyName == nameof(ParkVehicleViewModel.FinishAt)
            || e.PropertyName == nameof(ParkVehicleViewModel.VehicleType))
        {
            OnCanExecuteChanged();
        }
    }
    public override bool CanExecute(object? parameter) =>
                         !string.IsNullOrEmpty(_parkVehicleViewModel.Plate)
                         && _parkVehicleViewModel.Cylinder > 0
                         && base.CanExecute(parameter);
    public override async Task ExecuteAsync(object? parameter)
    {
        ParkingRecord parkingRecord = new ParkingRecord(_parkVehicleViewModel.Id,
                                                        _parkVehicleViewModel.VehicleType,
                                                        _parkVehicleViewModel.Plate,
                                                        _parkVehicleViewModel.Cylinder,
                                                        _parkVehicleViewModel.StartAt,
                                                        _parkVehicleViewModel.FinishAt,
                                                        _parkVehicleViewModel.Status);
        try
        {
            await _parkingLotStore.ParkVehicle(parkingRecord);
            MessageBox.Show("Vehicle parked registered correctly.", "Sucess", MessageBoxButton.OK, MessageBoxImage.Information);
            _navigationService.Navigate();
        }
        catch (AlreadyParkedException)
        {
            MessageBox.Show("The car is already at the parking lot.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failled. {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
    