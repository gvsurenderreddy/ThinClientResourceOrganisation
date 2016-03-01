using System;

namespace WTS.WorkSuite.Library.DomainTypes.Date
{

    public static class DateFromatters
    {

        public static string FormatForReport
                                (this DateTime? date)
        {

            if (date.HasValue)
            {
                return date.Value.FormatForReport();
            }
            return string.Empty;
        }

        public static string FormatForReport
                                (this DateTime date)
        {

            return date.Day + Space + date.ToString("MMMM").Substring(0, 3) + Space + date.Year;

        }


        public static string FormatForReportIncludeAge
                                (this DateTime? date)
        {

            return date.HasValue ? date.FormatForReport() + " (age " + date.ToAge() + ")" : "";

        }


        public static int? ToAge
                            (this DateTime? from
                            , DateTime? to = null)
        {



            if (from.HasValue)
            {
                to = to ?? DateTime.Today;

                var age = to.Value.Year - from.Value.Year;

                if (to.Value.Month < from.Value.Month
                   || to.Value.Month == from.Value.Month && to.Value.Day < from.Value.Day) age--;

                return age;
            }
            return null;
        }

        const string Space = " ";

    }
}
