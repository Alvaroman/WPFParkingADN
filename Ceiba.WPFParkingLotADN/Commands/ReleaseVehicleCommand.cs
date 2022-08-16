﻿using Ceiba.WPFParkingLotADN.Model;
using Ceiba.WPFParkingLotADN.Stores;
using Ceiba.WPFParkingLotADN.ViewModel;
using System.Threading.Tasks;
using System.Windows;

namespace Ceiba.WPFParkingLotADN.Commands;

public class ReleaseVehicleCommand : AsyncCommandBase
{
    private readonly ParkingLotStore _parkingLotStore;
    private readonly VehicleParkedViewModel _vehicleParkedViewModel;
    
    public ReleaseVehicleCommand(ParkingLotStore parkingLotStore, VehicleParkedViewModel vehicleParkedViewModel)
    {
        _parkingLotStore = parkingLotStore;
        _vehicleParkedViewModel = vehicleParkedViewModel;
    }
    public override async Task ExecuteAsync(object? parameter)
    {
        var cost = await _parkingLotStore.ReleaseVehicle(_vehicleParkedViewModel.Id);
        MessageBox.Show($"Vehicle releaes correctly. The cost is: {cost}.", "Sucess", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}
