using Ceiba.WPFParkingLotADN.Extensions;
using Ceiba.WPFParkingLotADN.Services;
using Ceiba.WPFParkingLotADN.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace Ceiba.WPFParkingLotADN
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    { 
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddServices();
            })
            .Build();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            NavigationService<VehicleListingViewModel> navigationService = _host.Services.GetRequiredService<NavigationService<VehicleListingViewModel>>();
            navigationService.Navigate();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

    }
}
