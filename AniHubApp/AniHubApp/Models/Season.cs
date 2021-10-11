using System;
using System.Collections.Generic;
using System.Text;

namespace AniHubApp.Models
{
    public class Season
    {
        private enum Seasons
        {
            Winter,
            Spring,
            Summer,
            Fall
        }

        public static int GetCurrentSeasonValue()
        {
            var currentDate = DateTime.Now;
            var leapDayCount = Convert.ToInt32(DateTime.IsLeapYear(currentDate.Year) && currentDate.DayOfYear > 59);

            int day = currentDate.DayOfYear - leapDayCount;

            if (day < 80 || day >= 355)
            {
                return (int)Seasons.Winter;
            }

            if (day >= 80 && day < 172)
            {
                return (int)Seasons.Spring;
            }

            if (day >= 172 && day < 266)
            {
                return (int)Seasons.Summer;
            }

            return (int)Seasons.Fall;
        }
    }
}
