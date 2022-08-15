﻿using Ceiba.WPFParkingLotADN.Model;
using System;

namespace Ceiba.WPFParkingLotADN.ViewModel;
public class VehicleParkedViewModel : ViewModelBase
{
    private readonly ParkingRecord _parkingRecord;
    public VehicleParkedViewModel(ParkingRecord parkingRecord)
    {
        _parkingRecord = parkingRecord;
    }

    public Guid Id => _parkingRecord.Id;
    public string Plate => _parkingRecord.Plate;
    public int Cylinder => _parkingRecord.Cylinder;
    public string StartAt => _parkingRecord.StartedAt.ToString("d");
    public string FinishAt => _parkingRecord.FinishedAt.ToString("d");
    public bool Status => _parkingRecord.Status;
}
