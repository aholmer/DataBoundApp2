using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;


namespace DataBoundApp2.Converter
{
    public class TemperatureModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (App.Temperature)
            {
                case "fahrenheit":
                    return System.Convert.ToString((double)value * 1.8 +32) + "° F";
                case "kelvin":
                    return System.Convert.ToString((double)value + 273.15) + "° K";
                case "celcius":
                    return System.Convert.ToString(value) + "° C";
                default:
                    return System.Convert.ToString(value) + "null";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
