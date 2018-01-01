using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BattleFieldTracker.Converter
{
    /// <summary>
    /// Shows the ProgressBar in the layout while downloading
    /// </summary>
    internal class ProgressBarVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b)
                return b ? Visibility.Visible : Visibility.Hidden;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
                return visibility == Visibility.Visible;
            return value;
        }
    }
}
