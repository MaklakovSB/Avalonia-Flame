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
            //if (value is string sourceText && parameter is string prevNotes
            //    && targetType.IsAssignableTo(typeof(string)))
            //{
                return $@"{parameter}: {value}";

            //}
            //// converter used for the wrong type
            return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
