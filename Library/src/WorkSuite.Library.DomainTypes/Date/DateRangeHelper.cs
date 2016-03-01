using System;

namespace WTS.WorkSuite.Library.DomainTypes.Date
{
    public static class DateRangeSpan
    {
        public static void Boundary(DateTime a_date
                                        , DateTime another_date
                                        , Action within_month
                                        , Action crosses_month
                                        , Action crosses_year)
        {

            var start_date = a_date;
            var end_date = another_date;

            if (start_date > end_date)
            {
                start_date = another_date;
                end_date = a_date;
            }


            if (start_date.Year == end_date.Year && start_date.Month == end_date.Month)
            {
                within_month();

                return;
            }

            if (start_date.Year == end_date.Year && start_date.Month != end_date.Month)
            {
                crosses_month();

                return;
            }

            if (start_date.Year != end_date.Year)
            {
                crosses_year();

                return;
            }

            throw new InvalidOperationException("Date range span is invalid");

        }
    }
}