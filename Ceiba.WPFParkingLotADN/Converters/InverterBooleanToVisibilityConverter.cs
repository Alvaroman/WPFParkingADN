using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Ceiba.WPFParkingLotADN.Converters;

public class InverterBooleanToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value is bool boolValue && boolValue ? Visibility.Collapsed : Visibility.Visible;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
