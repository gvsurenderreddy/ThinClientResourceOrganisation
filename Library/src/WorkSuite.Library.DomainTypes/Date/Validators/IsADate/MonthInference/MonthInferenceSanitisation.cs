using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.Date.Validators.IsADate.MonthInference
{
    public class MonthInferenceSanitisation : IMonthSanitisation
    {
        public Maybe<int> sanitise(string value)
        {
           return this
                 .set_request(value)
                 .check_if_request_is_numeric()
                 .check_if_request_is_month_name_or_abbreviation()
                 .decide()
                    ;
        }

        private MonthInferenceSanitisation set_request(string value)
        {
            if (result.has_been_decided())
            {
                result = null;
            }
            month_as_string = (value ?? string.Empty).Trim().ToLower();
            return this;
        }

        private MonthInferenceSanitisation check_if_request_is_numeric()
        {

            if (result.has_been_decided()) return this;

            int month;
            if (int.TryParse(month_as_string, out month))
            {
                result = new Just<int>(month);
            }
            return this;
        }

        private MonthInferenceSanitisation check_if_request_is_month_name_or_abbreviation()
        {

            if (result.has_been_decided()) return this;
            if (month_as_string.Length < 3) return this;   // we only match if the three or more character have been entered.

            // see if we can map the string to a month name or an abbreviation of a month name
            var month_number = month_map
                                    .ToList()
                                    .Where(mm => mm.Key.StartsWith(month_as_string))
                                    .Select(mm => (int?)mm.Value)
                                    .FirstOrDefault()
                                    ;

            // if we matched the string to a month then set that as the month
            if (month_number.HasValue)
            {

                result = new Just<int>(month_number.Value);
            }
            return this;
        }

        private Maybe<int> decide()
        {

            // by this point all the evaluation should have been
            // completed so just return the result or nothing
            // if a decision has not been made by this point in time

            if (result.has_been_decided())
            {
                return result;
            }
            return new Nothing<int>();
        }


        private static readonly Dictionary<string, int> month_map = new Dictionary<string, int> {
            {"january", 1},{"february", 2},{"march", 3},{"april", 4},{"may", 5},{"june", 6},
            {"july", 7},{"august", 8},{"september", 9},{"october", 10},{"november", 11},{"december", 12},
        };

        private string month_as_string;
        private Maybe<int> result;
    }
}