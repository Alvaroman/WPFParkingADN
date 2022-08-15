using Ceiba.WPFParkingLotADN.Commands;
using Ceiba.WPFParkingLotADN.Model.Enum;
using Ceiba.WPFParkingLotADN.Services;
using Ceiba.WPFParkingLotADN.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace Ceiba.WPFParkingLotADN.ViewModel;
public class ParkVehicleViewModel : ViewModelBase, INotifyDataErrorInfo
{
    public readonly Dictionary<string, List<string>> _propertyNameToErrorsDictionary;
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
    public ParkVehicleViewModel(ParkingLotStore parkingLotStore, NavigationService<VehicleListingViewModel> navigationService)
    {
        _propertyNameToErrorsDictionary = new Dictionary<string, List<string>>();
        ParkCommand = new ParkVehicleCommand(this, parkingLotStore, navigationService);
        CancelCommand = new NavigateCommand<VehicleListingViewModel>(navigationService);
    }
    public ICommand ParkCommand { get; }
    public ICommand CancelCommand { get; }
    private Guid _id;
    public Guid Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged(nameof(Id));
        }
    }

    private string _plate;
    public string Plate
    {
        get => _plate;
        set
        {
            _plate = value;
            OnPropertyChanged(nameof(Plate));
        }
    }
    private int _vehicleType;
    public int VehicleType
    {
        get => _vehicleType;
        set
        {
            _vehicleType = value;
            OnPropertyChanged(nameof(VehicleType));
            ClearErrors(nameof(VehicleType));
            if (Enum.IsDefined(typeof(VehicleType), _vehicleType))
            {
                AddError("This is not an allowed vehicle.", nameof(VehicleType));
            }
        }
    }

    private DateTime _startAt;
    public DateTime StartAt
    {
        get => _startAt; set
        {
            _startAt = value;
            OnPropertyChanged(nameof(StartAt));
        }
    }

    private DateTime _finishAt;
    public DateTime FinishAt
    {
        get => _finishAt; set
        {
            _finishAt = value;
            OnPropertyChanged(nameof(FinishAt));
        }
    }
    private bool? _status;
    public bool Status
    {
        get => _status ?? true;
        set
        {
            _status = value;
            OnPropertyChanged(nameof(Status));
        }
    }
    private int _cylinder;
    public int Cylinder
    {
        get => _cylinder; set
        {
            _cylinder = value;
            OnPropertyChanged(nameof(Cylinder));
        }
    }
    public bool HasErrors => _propertyNameToErrorsDictionary is not null && _propertyNameToErrorsDictionary.Any();

    public IEnumerable GetErrors(string? propertyName)
        => _propertyNameToErrorsDictionary.GetValueOrDefault(propertyName, new List<string>());

    private void ClearErrors(string propertyName)
    {
        _propertyNameToErrorsDictionary.Remove(nameof(propertyName));
        OnErrorChanged(propertyName);
    }
    private void OnErrorChanged(string propertyName)
    {
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
    private void AddError(string message, string propertyName)
    {
        if (!_propertyNameToErrorsDictionary.ContainsKey(propertyName))
        {
            _propertyNameToErrorsDictionary.Add(propertyName, new List<string>());
        }
    }
}
