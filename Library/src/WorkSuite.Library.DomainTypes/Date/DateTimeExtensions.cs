using System;

namespace WTS.WorkSuite.Library.DomainTypes.Date
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            var diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-1 * diff).Date;
        }

        public static DateTime FirstDayOfMonth(this DateTime date_context)
        {
            return new DateTime(date_context.Year, date_context.Month, 1);
        }


        public static DateTime LastDayOfMonth(this DateTime date_context)
        {
            return new DateTime(date_context.Year, date_context.Month, DateTime.DaysInMonth(date_context.Year, date_context.Month));
        }

        public static bool IsAWeekendDay(this DateTime date_context)
        {
            return (date_context.DayOfWeek == DayOfWeek.Saturday || date_context.DayOfWeek == DayOfWeek.Sunday);
        }

        public static string AbbreviatedDayOfWeek(this DateTime date_context)
        {
            return date_context.ToString("ddd");
        }

        public static string ToClientSideDateString(this DateTime date_context)
        {
            return date_context.ToString("dd/MM/yyyy");
        }

        public static string ToClientSideUrlSafeInvariantCultureString(this DateTime date_context)
        {
            return date_context.ToString("MM-dd-yyyy");
        }

        public static string ToCalendarPaletteHeaderString(this DateTime date_context)
        {
            return date_context.ToString("MMMM yyyy");
        }
        
    }
}
