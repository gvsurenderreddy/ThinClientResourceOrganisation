using System;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods.ViolationCheck;

namespace WTS.WorkSuite.Library.DomainTypes.Time.Periods.OneViolation
{

    public class CheckOneViolation
    {
        public ViolationCheckResult execute(violationRequest the_violation_request)
        {
            return set_request(the_violation_request)
                   .get_first_period_start_date()
                   .get_first_period_end_date()
                   .get_second_period_start_date()
                   .get_second_period_end_date()
                   .validation()
                   ;
        }

        private CheckOneViolation set_request(violationRequest the_violation_request)
        {
            request = Guard.IsNotNull(the_violation_request, "the_time_request");
            if (request.first == null || request.second == null) { result = new ViolationCheckResult.Valid(); }
            return this;
        }

        private CheckOneViolation get_first_period_start_date()
        {
            Guard.IsNotNull(request, "request");
            first_period_start_date = request.first.start_at.ToDateTime();
            return this;
        }

        private CheckOneViolation get_first_period_end_date()
        {
            Guard.IsNotNull(request, "request");
            DateTime start_date = request.first.start_at.ToDateTime();
            first_period_end_date = start_date.AddSeconds(request.first.duration);
            return this;
        }

        private CheckOneViolation get_second_period_start_date()
        {
            Guard.IsNotNull(request, "request");
            second_period_start_date = request.second.start_at.ToDateTime();
            return this;
        }

        private CheckOneViolation get_second_period_end_date()
        {
            Guard.IsNotNull(request, "request");
            DateTime end_date = request.second.start_at.ToDateTime();
            second_period_end_date = end_date.AddSeconds(request.second.duration);
            return this;
        }

        private ViolationCheckResult validation()
        {
            result = new ViolationCheckResult.Valid();
            if (first_period_end_date > second_period_start_date && second_period_end_date > first_period_start_date)
            {
                result = new ViolationCheckResult.BlockClashError();
            }
            if (second_period_start_date == first_period_start_date && second_period_end_date == first_period_end_date)
            {
                result = new ViolationCheckResult.BlockClashError();
            }


            return result;
        }

        private violationRequest request;
        private DateTime first_period_end_date;
        private DateTime first_period_start_date;
        private DateTime second_period_start_date;
        private DateTime second_period_end_date;
        private ViolationCheckResult result;


        
    }

}


