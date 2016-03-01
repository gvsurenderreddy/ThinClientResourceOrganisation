using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods.OneViolation;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods.ViolationCheck;

namespace WTS.WorkSuite.Library.DomainTypes.Time.Periods.BatchOfViolation
{
    public class CheckBatchOfViolation
    {
        public IEnumerable<ViolationCheckResult> validate(IEnumerable<TimePeriod> list_of_time_period_request)
        {
            return set_request(list_of_time_period_request)
                .validation()
                ;
        }

        private CheckBatchOfViolation set_request(IEnumerable<TimePeriod> the_list_of_block)
        {
            list_of_time_periods = Guard.IsNotNull(the_list_of_block, "the_list_of_block");

            if (!list_of_time_periods.Any()) result = new List<ViolationCheckResult>();
            return this;
        }

        private IEnumerable<ViolationCheckResult> validation()
        {
            Guard.IsNotNull(list_of_time_periods, "list_of_time_periods");

            result = new List<ViolationCheckResult>();

            foreach (var time_period in list_of_time_periods)
            {
                list_of_time_periods = list_of_time_periods.Skip(1);
                result = check_all_violation(time_period, list_of_time_periods).result;
            }
            return result;
        }

        private CheckBatchOfViolation check_all_violation ( TimePeriod base_time_period 
                                                          , IEnumerable<TimePeriod> next_time_periods)
        {
            foreach (var violation_check_result in next_time_periods
                    .Select(next_time_period => 
                     new CheckOneViolation().execute(new violationRequest { first = base_time_period, second = next_time_period }))) 
                     { result.Add(violation_check_result); }

            return this;
        }
        private IEnumerable<TimePeriod> list_of_time_periods;
        private List<ViolationCheckResult> result;
    }
}