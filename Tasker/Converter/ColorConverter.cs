using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker.Converter
{
    public class ColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var color = value.ToString();
            //System.Diagnostics.Debug.WriteLine("ColorConverter Input: " + value?.ToString());
            //Console.WriteLine("ColorConverter Input: " + value?.ToString());
            return Color.FromArgb(color);


        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
