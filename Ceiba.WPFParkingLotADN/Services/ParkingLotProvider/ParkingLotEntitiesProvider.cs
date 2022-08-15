using AutoMapper;
using Ceiba.WPFParkingLotADN.Dto;
using Ceiba.WPFParkingLotADN.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ceiba.WPFParkingLotADN.Services.ParkingLotProvider;
public class ParkingLotEntitiesProvider : ServiceConnection, IParkingLotProvider
{
    private readonly IMapper _mapper;
    public ParkingLotEntitiesProvider(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<IEnumerable<ParkingRecord>> GetParkingRecordsAsync()
    {
        var response = await _client.GetAsync("");
        var result = await response.Content.ReadAsStringAsync();
        var parkingRecords = JsonConvert.DeserializeObject<IEnumerable<ParkingLotDto>>(result);
        return _mapper.Map<IEnumerable<ParkingRecord>>(parkingRecords);
    }
}