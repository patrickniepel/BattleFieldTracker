﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BattleFieldTracker.Converter
{
    /// <summary>
    /// Hides the layout if no data available, displays it after download has finished
    /// </summary>
    internal class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b)
                return b ? Visibility.Visible : Visibility.Collapsed;
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
