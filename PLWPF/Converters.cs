using BE;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PLWPF
{
    class WorkDaysArreyToText : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool[] boolArreyValue = (bool[])value;
            string StrWorkDays = "|";
            if (boolArreyValue[0])
                StrWorkDays += " Sunday |";
            if (boolArreyValue[1])
                StrWorkDays += " Monday |";
            if (boolArreyValue[2])
                StrWorkDays += " Tuesday |";
            if (boolArreyValue[3])
                StrWorkDays += " Wednesday |";
            if (boolArreyValue[4])
                StrWorkDays += " Thursday |";
            if (boolArreyValue[5])
                StrWorkDays += " Friday |";
            return StrWorkDays;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class WorkHoursArreyToText : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            WorkHours[] WorkHoursArreyValue = (WorkHours[])value;
            string strWorksOnDays = "|";
            strWorksOnDays += " Sunday: " + WorkHoursArreyValue[0] + " |";
            strWorksOnDays += " Monday: " + WorkHoursArreyValue[1] + " |";
            strWorksOnDays += " Tuesday: " + WorkHoursArreyValue[2] + " |";
            strWorksOnDays += " Wednesday: " + WorkHoursArreyValue[3] + " |";
            strWorksOnDays += " Thursday: " + WorkHoursArreyValue[4] + " |";
            strWorksOnDays += " Friday: " + WorkHoursArreyValue[5] + " |";

            return strWorksOnDays;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}