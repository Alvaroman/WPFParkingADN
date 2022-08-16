using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Ceiba.WPFParkingLotADN.Services;
public class ServiceConnection
{
    protected const string BASE_URL = "https://localhost:5443/api/parking/";
    protected readonly HttpClient _client;
    public ServiceConnection()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri(BASE_URL);
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
}
