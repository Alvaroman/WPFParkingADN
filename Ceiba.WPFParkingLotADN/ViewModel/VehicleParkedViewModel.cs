using Ceiba.WPFParkingLotADN.Commands;
using Ceiba.WPFParkingLotADN.Model;
using Ceiba.WPFParkingLotADN.Stores;
using System;
using System.Windows.Input;

namespace Ceiba.WPFParkingLotADN.ViewModel;
public class VehicleParkedViewModel : ViewModelBase
{
    private readonly ParkingRecord _parkingRecord;
    public VehicleParkedViewModel(ParkingRecord parkingRecord, ParkingLotStore parkingStore,VehicleListingViewModel vehicleListingViewModel)
    {
        _parkingRecord = parkingRecord;
        ReleaseCommand = new ReleaseVehicleCommand(parkingStore, this, vehicleListingViewModel);
        GetChargeCommand = new ChargeCommand(parkingStore, this);
    }
    public ICommand ReleaseCommand { get; }
    public ICommand GetChargeCommand { get; }
    public Guid Id => _parkingRecord.Id;
    public string Plate => _parkingRecord.Plate;
    public string Cylinder => _parkingRecord.Cylinder.ToString("N0");
    public string StartAt => _parkingRecord.StartedAt.ToString("G");
    public string FinishAt => _parkingRecord.FinishedAt.ToString("d");
    public bool Status => _parkingRecord.Status;
    public int VehicleType => _parkingRecord.VehicleType;
    public string VehicleTypeName => ((Model.Enum.VehicleType)_parkingRecord.VehicleType).ToString();
}
