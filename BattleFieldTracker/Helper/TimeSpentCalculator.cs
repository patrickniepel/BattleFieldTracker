using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleFieldTracker.Helper
{
    public class TimeSpentCalculator
    {
        public string GetTimeSpentString(double seconds)
        {
            seconds = Math.Round(seconds, 0);
            //Days
            if (seconds / 60 / 60 / 24 > 1)
            {
                double days = Math.Round(seconds / 60 / 60 / 24, 0);
                double hours = Math.Round(seconds / 60 / 60, 0) % 24;
                double minutes = Math.Round(seconds / 60, 0) % 60;
                double secs = seconds % 60;
                return days.ToString(CultureInfo.CurrentCulture) + "d "
                    + hours.ToString(CultureInfo.CurrentCulture) + "h " 
                    + minutes.ToString(CultureInfo.CurrentCulture) + "m " 
                    + secs.ToString(CultureInfo.CurrentCulture) + "s";
            }
            // Hours
            if (seconds / 60 / 60  > 1)
            {
                double hours = Math.Round(seconds / 60 / 60, 0);
                double minutes = Math.Round(seconds / 60, 0) % 60;
                double secs = seconds % 60;
                return hours.ToString(CultureInfo.CurrentCulture) + "h " 
                    + minutes.ToString(CultureInfo.CurrentCulture) + "m " 
                    + secs.ToString(CultureInfo.CurrentCulture) + "s";
            }
            // Minutes
            if (seconds / 60  > 1)
            {
                double minutes = Math.Round(seconds / 60, 0);
                double secs = seconds % 60;
                return minutes.ToString(CultureInfo.CurrentCulture) + "m " + secs.ToString(CultureInfo.CurrentCulture) + "s";
            }

            return seconds.ToString(CultureInfo.CurrentCulture) + "s";
        }
    }
}
