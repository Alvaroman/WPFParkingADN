﻿using Ceiba.WPFParkingLotADN.ViewModel;
using System;

namespace Ceiba.WPFParkingLotADN.Stores;
public class NavigationStore
{
    private ViewModelBase _currentViewModel;
    public event Action CurrentViewModelChanged;
    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel?.Dispose();
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }
    private void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }
}
