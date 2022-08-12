using Ceiba.WPFParkingLotADN.Extensions;
using Ceiba.WPFParkingLotADN.Services.AlreadyRegisterCarValidator;
using Ceiba.WPFParkingLotADN.Services.ParkingLotProvider;
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
        protected override async void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            
            base.OnStartup(e);
            ParkingLotEntitiesProvider test = new ParkingLotEntitiesProvider();
            try
            {
                var rs = await test.GetParkingLotAsync();

            }
            catch (System.Exception ex)
            {

            }
        }

    }
}
