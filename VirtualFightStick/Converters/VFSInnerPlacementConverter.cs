using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace VirtualFightStick.Converters
{
    public class VFSInnerPlacementConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse(values[0].ToString(), out double innerRad) && double.TryParse(values[1].ToString(), out double outerRad))
            {
                var difference = outerRad - innerRad;
                if (difference <= 0)
                {
                    return 0;
                }
                return difference / 2;
            }
            return 0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
