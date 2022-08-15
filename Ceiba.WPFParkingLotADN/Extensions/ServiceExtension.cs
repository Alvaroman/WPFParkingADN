using Ceiba.WPFParkingLotADN.Model;
using Ceiba.WPFParkingLotADN.Services.AlreadyRegisterCarValidator;
using Ceiba.WPFParkingLotADN.Services.ParkingLotProvider;
using Ceiba.WPFParkingLotADN.Stores;
using Ceiba.WPFParkingLotADN.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ceiba.WPFParkingLotADN.Extensions;
public static class ServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IParkingLotProvider, ParkingLotEntitiesProvider>();
        services.AddSingleton<IAlreadyRegisteredCarValidator, AlreadyRegisteredCarValidator>();
        services.AddTransient<ParkingRegistration>();
        services.AddSingleton((s) => new ParkingLot(s.GetRequiredService<ParkingRegistration>()));
        //services.AddSingleton<>
        services.AddSingleton<NavigationStore>();
        services.AddSingleton<ParkingLotStore>();
        services.AddSingleton<MainViewModel>();
        services.AddSingleton(s => new MainWindow()
        {
            DataContext = s.GetRequiredService<MainViewModel>()
        });
        services.AddAutoMapper(Assembly.Load("Ceiba.WPFParkingLotADN"));

        return services;
    }
}
