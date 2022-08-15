using System;

namespace Ceiba.WPFParkingLotADN.Model;
public class ParkingRecord
{
    public ParkingRecord(int vehicleType,
                         string plate,
                         int cylinder,
                         DateTime startedAt,
                         DateTime finishedAt,
                         bool status)
    {
        VehicleType = vehicleType;
        Plate = plate;
        Cylinder = cylinder;
        StartedAt = startedAt;
        FinishedAt = finishedAt;
        Status = status;
    }

    public Guid Id { get; set; }
    public int VehicleType { get; set; }
    public string Plate { get; set; }
    public int Cylinder { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime FinishedAt { get; set; }
    public bool Status { get; set; }
}
