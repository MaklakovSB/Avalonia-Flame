using Avalonia.Data;
using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace Flame.Converters
{
    public class TextPrefixConcatenationConverter : IValueConverter
    {
        public static readonly TextPrefixConcatenationConverter Instance = new();

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return $@"{parameter}: {value}";
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
