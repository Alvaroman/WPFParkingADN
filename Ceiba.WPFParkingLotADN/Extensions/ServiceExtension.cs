using Ceiba.WPFParkingLotADN.Services.AlreadyRegisterCarValidator;
using Ceiba.WPFParkingLotADN.Services.ParkingLotProvider;
using Microsoft.Extensions.DependencyInjection;

namespace Ceiba.WPFParkingLotADN.Extensions;
public static class ServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IParkingLotProvider, ParkingLotEntitiesProvider>();
        services.AddSingleton<IAlreadyRegisteredCarValidator, AlreadyRegisteredCarValidator>();
        
        return services;
    }
}
