using Ceiba.WPFParkingLotADN.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ceiba.WPFParkingLotADN.Stores;

public class ParkingLotStore
{
    private readonly ParkingLot _parkingLot;
    private readonly List<ParkingRecord> _parkingRecords;
    private Lazy<Task> _initializeLazy;
    public event Action<ParkingRecord> VehicleRegistered;


    public ParkingLotStore(ParkingLot parkingLot)
    {
        this._parkingLot = parkingLot;
        _initializeLazy = new Lazy<Task>(Initialize);
        _parkingRecords = new List<ParkingRecord>();
    }
    public async Task Load()
    {
        try
        {
            await _initializeLazy.Value;
        }
        catch (Exception)
        {
            _initializeLazy = new Lazy<Task>();
            throw;
        }
    }
    public async Task RegisterVehicle(ParkingRecord parkingRecord)
    {
        await _parkingLot.ParkVehicle(parkingRecord);
        _parkingRecords.Add(parkingRecord);
        OnVehicleRegistered(parkingRecord);
    }
    private void OnVehicleRegistered(ParkingRecord parkingRecord)
    {
        VehicleRegistered?.Invoke(parkingRecord);
    }
    private async Task Initialize()
    {
        IEnumerable<ParkingRecord> parkingRecords = await _parkingLot.GetParkingRecords();
        _parkingRecords.Clear();
        _parkingRecords.AddRange(parkingRecords);
    }
}
