using Ceiba.WPFParkingLotADN.Services.AlreadyRegisterCarValidator;
using Ceiba.WPFParkingLotADN.Services.ParkingLotProvider;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ceiba.WPFParkingLotADN.Extensions;
public static class ServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IParkingLotProvider, ParkingLotEntitiesProvider>();
        services.AddSingleton<IAlreadyRegisteredCarValidator, AlreadyRegisteredCarValidator>();
        services.AddAutoMapper(Assembly.Load("Ceiba.WPFParkingLotADN"));

        return services;
    }
}
