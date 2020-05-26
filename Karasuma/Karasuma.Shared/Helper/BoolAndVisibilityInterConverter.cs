using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Karasuma.Helper
{
    /// <summary>
    /// BoolとVisibilityの相互変換
    /// </summary>
    public class BoolAndVisibilityInterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is null) return DependencyProperty.UnsetValue;
            if (value is bool)
            {
                var visibilityValue = (bool)value ?
                    Visibility.Visible :
                    Visibility.Collapsed;
                return visibilityValue;
            }
            else if (value is Visibility)
            {
                var boolValue = (Visibility)value == Visibility.Visible ?
                    true :
                    false;
                return boolValue;
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return Convert(value, targetType, parameter, language);
        }
    }


    /// <summary>
    /// BoolとVisibilityの相互変換（逆）
    /// </summary>
    public class BoolAndVisibilityInterReverseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is null) return DependencyProperty.UnsetValue;
            if (value is bool)
            {
                var visibilityValue = (bool)value ?
                    Visibility.Collapsed :
                    Visibility.Visible;
                return visibilityValue;
            }
            else if (value is Visibility)
            {
                var boolValue = (Visibility)value == Visibility.Visible ?
                    false :
                    true;
                return boolValue;
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return Convert(value, targetType, parameter, language);
        }
    }
}
