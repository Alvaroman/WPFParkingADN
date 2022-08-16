using System;
using System.Threading.Tasks;

namespace Ceiba.WPFParkingLotADN.Services.GetChar;
public interface IGetChargeService
{
    Task<decimal> GetCharge(Guid Id);
}
