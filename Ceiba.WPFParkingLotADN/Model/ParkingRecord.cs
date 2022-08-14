using System;

namespace Ceiba.WPFParkingLotADN.Model;
public class ParkingRecord
{
    public Guid Id { get; set; }
    public int VehicleType { get; set; } = default!;
    public string Plate { get; set; } = default!;
    public int Cylinder { get; set; }
    public DateTime StartedAt { get; set; } = default!;
    public DateTime FinishedAt { get; set; } = default!;
    public bool Status { get; set; } = default!;
}
