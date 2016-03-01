using System;

namespace WTS.WorkSuite.Library.DomainTypes.Date {

    /// <summary>
    ///     Implementation of the <see cref="IDateRequest"/>. This is a
    /// convenience so that if all you need is an <see cref="IDateRequest"/>
    /// then you do no have to create a specialied type.
    /// </summary>
    public class DateRequest
                    : IDateRequest {

        public string year {  get; set; }
        public string month {  get; set; }
        public string day { get; set; }

    }

    public static class DateRequestExtensions {

        public static DateRequest ToDateRequest
                                    ( this DateTime? date ) {

            
            return date.HasValue 
                    ? date.Value.ToDateRequest()
                    : new DateRequest {
                        year = string.Empty,
                        month = string.Empty,
                        day = string.Empty,
                      };
        }

        public static DateRequest ToDateRequest
                                    ( this DateTime date ) {

            return new DateRequest {
                year = date.Year.ToString(),
                month = date.Month.ToString(),
                day = date.Day.ToString(),
            };
        }

        public static DateTime to_date_time(this DateRequest date_request)
        {
            return new DateTime(Convert.ToInt32(date_request.year)
                              , Convert.ToInt32(date_request.month)
                              , Convert.ToInt32(date_request.day));
        }


    }
}