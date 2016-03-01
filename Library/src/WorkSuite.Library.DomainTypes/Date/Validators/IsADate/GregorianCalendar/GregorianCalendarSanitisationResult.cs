using System;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.Date.Validators.IsADate.GregorianCalendar
{
    public abstract class GregorianCalendarSanitisationResult
    {
        public sealed class ValidDate : GregorianCalendarSanitisationResult
        {
             public Date valid_date { get; set; }
             public ValidDate(Date the_valid_date)
            {
                valid_date = the_valid_date;
            }
        }

        public sealed class Error : GregorianCalendarSanitisationResult { }
        
    }

    public static class GregorianDateComponantValidationExtension
    {

        public static bool has_been_decided
                   (this GregorianCalendarSanitisationResult result)
        {
            return result != null;
        }

        public static T Match<T>(this GregorianCalendarSanitisationResult result 
                                , Func<Date,T> is_valid
                                , Func<GregorianCalendarSanitisationResult.Error, T> is_not_valid)
        {
            if (result is GregorianCalendarSanitisationResult.ValidDate)
            {
                return is_valid((result as GregorianCalendarSanitisationResult.ValidDate).valid_date);
            }

            if (result is GregorianCalendarSanitisationResult.Error)
            {
                return is_not_valid((result as GregorianCalendarSanitisationResult.Error));
            }

            throw new Exception("Unmatched case");
        }

        public static void Match(this GregorianCalendarSanitisationResult result
                                , Action<Date> is_valid
                                , Action<GregorianCalendarSanitisationResult.Error> is_not_valid)
        {
            Guard.IsNotNull(is_valid, "is_valid");
            Guard.IsNotNull(is_not_valid, "is_not_valid");

            result
                .Match(

                    is_valid:
                        valid_result => { is_valid(valid_result); return new Unit(); },

                    is_not_valid:
                        invalid_result => { is_not_valid(invalid_result); return new Unit(); }

                );
        }
    }

    public class Date
    {
        public int? year { get; private set; }
        public int? month { get; private set; }
        public int? day { get; private set; }

        public Date(int? year, int? month, int? day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
        }
    }
}