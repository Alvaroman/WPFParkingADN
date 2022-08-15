using Ceiba.WPFParkingLotADN.Stores;
using System;

namespace Ceiba.WPFParkingLotADN.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        private readonly NavigationStore _navigationStore;

        public MainViewModel(NavigationStore navigationStore)
        {
            this._navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OncurrentViewModelChanged;
        }

        private void OncurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
