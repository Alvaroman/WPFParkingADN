using AutoMapper;
using Ceiba.WPFParkingLotADN.Dto;
using Ceiba.WPFParkingLotADN.Model;
namespace Ceiba.WPFParkingLotADN.Mappings;

public class ParkingLotProfile : Profile
{
    public ParkingLotProfile()
    {
        CreateMap<ParkingLotDto, ParkingRecord>().ReverseMap();
    }
}
