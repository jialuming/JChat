using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace JStyleLib.Converters
{
    public class DoubleToGridLengthConverter : IValueConverter
    {
        private static DoubleToGridLengthConverter _instance;

        public static DoubleToGridLengthConverter Instance
        {
            get { return _instance ?? (_instance = new DoubleToGridLengthConverter()); }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double d = (double)value;
            if ((d.Equals(double.NaN)) || (d < 0))
            {
                return new GridLength(1, GridUnitType.Auto);

            }
            return new GridLength(d, GridUnitType.Pixel);

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GridLength gl = (GridLength)value;
            if (gl.IsAuto || gl.IsStar)
            {
                return double.NaN;
            }
            else
            {
                return gl.Value;
            }
        }
    }
}
