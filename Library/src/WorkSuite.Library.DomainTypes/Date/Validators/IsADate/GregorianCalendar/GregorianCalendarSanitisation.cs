using System;
using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Date.Validators.IsADate.MonthInference;

namespace WTS.WorkSuite.Library.DomainTypes.Date.Validators.IsADate.GregorianCalendar
{
    public class GregorianCalendarSanitisation
    {
        public GregorianCalendarSanitisationResult execute(DateRequest request)
        {
            return 
                 set_request(request)
                .each_value_in_component_should_fully_specify()
                .each_value_of_component_convert_to_integer()
                .check_month_inference_sanitisation()
                .date_is_valid();
        }

        public GregorianCalendarSanitisation set_request(DateRequest the_request)
        {
            Guard.IsNotNull(the_request, "the_request");
            date_request = the_request;
            if (result.has_been_decided())
            {
                result = null;
            }
            return this;
        }

        public GregorianCalendarSanitisation each_value_in_component_should_fully_specify()
        {
            Guard.IsNotNull(date_request, "date_request");
            var fields_not_specified = new List<GregorianCalendarSanitisationResult.Error>();
            if (string.IsNullOrWhiteSpace(date_request.year)) { fields_not_specified.Add(new GregorianCalendarSanitisationResult.Error()); }
            if (string.IsNullOrWhiteSpace(date_request.month)) { fields_not_specified.Add(new GregorianCalendarSanitisationResult.Error()); }
            if (string.IsNullOrWhiteSpace(date_request.day)) { fields_not_specified.Add(new GregorianCalendarSanitisationResult.Error()); }
        
            switch (fields_not_specified.Count())
            {
                case 0:
                    break;
                case 3: result = new GregorianCalendarSanitisationResult.ValidDate(new Date(null, null, null));
                    break;
                default:
                    result=new GregorianCalendarSanitisationResult.Error();
                    break;
            }
            return this;
        }

        public GregorianCalendarSanitisation each_value_of_component_convert_to_integer()
        {
            if (result.has_been_decided()) return this;
            Guard.IsNotNull(date_request, "date_request");

            var year_is_a_number = (int.TryParse(date_request.year, out year_as_number));
            if (!year_is_a_number || year_as_number <= 0) { result=new GregorianCalendarSanitisationResult.Error(); }


            var month_is_a_number = (int.TryParse(date_request.month, out month_as_number));
            if (month_is_a_number && month_as_number <= 0) { result=new GregorianCalendarSanitisationResult.Error(); }


            var day_is_a_number = (int.TryParse(date_request.day, out day_as_number));
            if (!day_is_a_number || day_as_number <= 0) { result=new GregorianCalendarSanitisationResult.Error(); }

            return this;
        }

        public GregorianCalendarSanitisation check_month_inference_sanitisation()
        {
            if (result.has_been_decided()) return this;

            Guard.IsNotNull(date_request, "date_request");
            var month = month_inference_sanitisation.sanitise(date_request.month);


            if (month is Just<int>)
            {
                month_as_number = (Just<int>)month;
            }
            else
            {
                result=new GregorianCalendarSanitisationResult.Error();

            }

            return this;
        }

        public GregorianCalendarSanitisationResult date_is_valid()
        {
            if (result.has_been_decided()) return result;
            Guard.IsNotNull(date_request, "date_request");
            try
            {
                date_time = new DateTime(year_as_number, month_as_number, day_as_number);
                result = new GregorianCalendarSanitisationResult.ValidDate(new Date(date_time.Year, date_time.Month, date_time.Day));

            }
            catch
            {
                result=new GregorianCalendarSanitisationResult.Error();
            }

            return result;
        }

        public GregorianCalendarSanitisation(IMonthSanitisation the_month_inference_sanitisation)
        {
            month_inference_sanitisation = Guard.IsNotNull(the_month_inference_sanitisation, "the_month_inference_sanitisation");
        }

        public DateRequest date_request;
        private int year_as_number;
        private int month_as_number;
        private int day_as_number;
        private GregorianCalendarSanitisationResult result;
        private readonly IMonthSanitisation month_inference_sanitisation;
        private DateTime date_time;
    }
}

