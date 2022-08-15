using Ceiba.WPFParkingLotADN.Model;
using Ceiba.WPFParkingLotADN.Services;
using Ceiba.WPFParkingLotADN.Services.AlreadyRegisterCarValidator;
using Ceiba.WPFParkingLotADN.Services.ParkingLotCreator;
using Ceiba.WPFParkingLotADN.Services.ParkingLotProvider;
using Ceiba.WPFParkingLotADN.Services.ParkingLotRelease;
using Ceiba.WPFParkingLotADN.Stores;
using Ceiba.WPFParkingLotADN.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Ceiba.WPFParkingLotADN.Extensions;
public static class ServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IParkingLotProvider, ParkingLotEntitiesProvider>();
        services.AddSingleton<IAlreadyRegisteredCarValidator, AlreadyRegisteredCarValidator>();
        services.AddSingleton<IReleaseParkingLot, ReleaseVehicle>();
        services.AddSingleton<IParkingLotCreator, ParkingLotEntityCreator>();
        services.AddTransient<ParkingRegistration>();
        services.AddSingleton((s) => new ParkingLot(s.GetRequiredService<ParkingRegistration>()));

        services.AddTransient<VehicleListingViewModel>((s) => CreateVehicleListingViewModel(s));
        services.AddSingleton<NavigationService<VehicleListingViewModel>>();
        services.AddSingleton<Func<VehicleListingViewModel>>(s => () => s.GetRequiredService<VehicleListingViewModel>());

        services.AddTransient<ParkVehicleViewModel>();
        services.AddSingleton<NavigationService<ParkVehicleViewModel>>();
        services.AddSingleton<Func<ParkVehicleViewModel>>(s => () => s.GetRequiredService<ParkVehicleViewModel>());

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

    private static VehicleListingViewModel CreateVehicleListingViewModel(IServiceProvider s)
    {
        return VehicleListingViewModel.LoadViewModel(s.GetRequiredService<ParkingLotStore>(),
                                                     s.GetRequiredService<NavigationService<ParkVehicleViewModel>>());
    }
}
