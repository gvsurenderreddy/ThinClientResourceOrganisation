using System;
using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods.BatchOfViolation;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods.ViolationCheck;

namespace WTS.WorkSuite.Library.DomainTypes.Time.Periods.ClashingTimePeriodScenario
{
    /// <summary>
    /// this clashing Time period validation need clean up .
    /// this class has 5 method and inside of each method I did compare start and end time indorder to find out new time period has a overlapped or enveloped peroblem withold time period.
    /// I checked each scenario by using if else which is not clean code .(for finding scenario should be refer to spread sheet .)
    /// Each if statment has the bool return value it means if the sceario one is correct, it will retrun true and send to domain side. 
    /// whole the checking scenario proccess done in the foreach loop for each time period .
    /// </summary>
    public static class ClashingTimePeriodsScnario
    {

        public static ClashingTimePeriodstypesError clashing_time_period_for_single_overlap(this IEnumerable<TimePeriod> list_of_time_period, TimePeriod new_time_period)
        {
            var violation_result = new CheckBatchOfViolation().validate(list_of_time_period).ToList();
            var clashing_time_periods_types = new ClashingTimePeriodstypesError();

            var violation_index = 0;
            foreach (var old_time_period in list_of_time_period)
            {
                var number_of_time_period = list_of_time_period.Count() - 1;

                for (var i = 0; i < number_of_time_period; i++)
                {
                    var get_result = violation_result[violation_index];

                    if (get_result is ViolationCheckResult.BlockClashError)
                    {
                        var new_time_period_end_time = new_time_period.start_at.ToDateTime().AddSeconds(new_time_period.duration);
                        var old_time_period_end_time = old_time_period.start_at.ToDateTime().AddSeconds(old_time_period.duration);
                        var new_time_period_start_at = new_time_period.start_at.ToDateTime();
                        var old_time_period_start_at = old_time_period.start_at.ToDateTime();

                        if (new_time_period_start_at <= old_time_period_start_at && new_time_period_end_time > old_time_period_end_time)
                        {
                            clashing_time_periods_types.single_envelop_error = true;

                        }

                        if (old_time_period_start_at < new_time_period_start_at && old_time_period_end_time > new_time_period_start_at && new_time_period_end_time > old_time_period_end_time)
                        {
                            clashing_time_periods_types.single_overlapped_start_time_error = true;
                        }


                        if (new_time_period_start_at < old_time_period_start_at && new_time_period_end_time > old_time_period_start_at && new_time_period_end_time < old_time_period_end_time)
                        {
                            clashing_time_periods_types.single_overlapped_duration_error = true;
                        }

                        if (new_time_period_start_at < old_time_period_start_at && new_time_period_end_time == old_time_period_end_time)
                        {

                            clashing_time_periods_types.single_overlapped_start_time_error = false;
                            clashing_time_periods_types.single_overlapped_duration_error = false;
                        }

                    }
                    violation_index++;
                }
                list_of_time_period = list_of_time_period.Skip(1).ToList();
            }
            return clashing_time_periods_types;
        }

        public static ClashingTimePeriodstypesError clashing_time_period_for_single_enveloped(this IEnumerable<TimePeriod> list_of_time_period, TimePeriod new_time_period)
        {
            var violation_result = new CheckBatchOfViolation().validate(list_of_time_period).ToList();
            var clashing_time_periods_types = new ClashingTimePeriodstypesError();
            var violation_index = 0;
            foreach (var old_time_period in list_of_time_period)
            {
                var number_of_time_period = list_of_time_period.Count() - 1;

                for (var i = 0; i < number_of_time_period; i++)
                {
                    var get_result = violation_result[violation_index];

                    if (get_result is ViolationCheckResult.BlockClashError)
                    {
                        var new_time_period_end_time = new_time_period.start_at.ToDateTime().AddSeconds(new_time_period.duration);
                        var old_time_period_end_time = old_time_period.start_at.ToDateTime().AddSeconds(old_time_period.duration);
                        var new_time_period_start_at = new_time_period.start_at.ToDateTime();
                        var old_time_period_start_at = old_time_period.start_at.ToDateTime();
                            if (old_time_period_start_at <= new_time_period_start_at && old_time_period_end_time >= new_time_period_end_time)
                            {
                                clashing_time_periods_types.single_enveloped_start_time_and_end_time_error = true;
                            }
                    }
                    violation_index++;
                }
                list_of_time_period = list_of_time_period.Skip(1).ToList();
            }
            return clashing_time_periods_types;
        }

        public static ClashingTimePeriodstypesError clashing_time_period_for_single_envelop(this IEnumerable<TimePeriod> list_of_time_period, TimePeriod new_time_period)
        {
            var violation_result = new CheckBatchOfViolation().validate(list_of_time_period).ToList();
            var number_of_error = violation_result.Where(x => x is ViolationCheckResult.BlockClashError).Select(x => x).Count();
            var clashing_time_periods_types = new ClashingTimePeriodstypesError();

            var violation_index = 0;

            if (number_of_error != 1) return clashing_time_periods_types;
            foreach (var old_time_period in list_of_time_period)
            {
                var number_of_time_period = list_of_time_period.Count() - 1;
                var count = 0;
                for (var i = 0; i < number_of_time_period; i++)
                {
                    var get_result = violation_result[violation_index];

                    if (get_result is ViolationCheckResult.BlockClashError)
                    {

                        var new_time_period_end_time = new_time_period.start_at.ToDateTime().AddSeconds(new_time_period.duration);
                        var old_time_period_end_time = old_time_period.start_at.ToDateTime().AddSeconds(old_time_period.duration);
                        var new_time_period_start_at = new_time_period.start_at.ToDateTime();
                        var old_time_period_start_at = old_time_period.start_at.ToDateTime();

                        if (new_time_period_start_at < old_time_period_start_at && new_time_period_end_time > old_time_period_end_time)
                        {
                            clashing_time_periods_types.single_envelop_start_time_and_end_time_error = true;
                        }

                        if (new_time_period_start_at < old_time_period_start_at && new_time_period_end_time == old_time_period_end_time)
                        {
                            count++;
                            if (count == 1)
                            {
                                clashing_time_periods_types.single_envelop_duration_error = true;
                            }
                        }

                        if (new_time_period_start_at == old_time_period_start_at && new_time_period_end_time > old_time_period_end_time)
                        {
                            clashing_time_periods_types.single_envelop_start_time_error = true;
                        }

                    }
                    violation_index++;
                }
                list_of_time_period = list_of_time_period.Skip(1).ToList();
            }
            return clashing_time_periods_types;
        }

        public static ClashingTimePeriodstypesError clashing_break_validation_for_multiple_envelop(this IEnumerable<TimePeriod> list_of_time_period, TimePeriod new_time_period)
        {
        var violation_result = new CheckBatchOfViolation().validate(list_of_time_period).ToList();
        var number_of_error =violation_result.Where(x => x is ViolationCheckResult.BlockClashError).Select(x => x).Count();

        var clashing_time_periods_types = new ClashingTimePeriodstypesError();

        var number_of_time_period_envloped_from_end_time = 0;
        var number_of_time_period_enveloped_form_start_time = 0;
        var equal_start_time = false;
        var equal_end_time = false;
        var check_overlaped_start_time = false;
        var check_overlaped_end_time = false;
        var check_enveloped = false;

        var violation_index = 0;
        if (number_of_error > 1)
        {
            foreach (var old_time_period in list_of_time_period)
            {
                var number_of_time_period = list_of_time_period.Count() - 1;

                for (var i = 0; i < number_of_time_period; i++)
                {
                    var get_result = violation_result[violation_index];

                    if (get_result is ViolationCheckResult.BlockClashError)
                    {

                        var new_time_period_end_time = new_time_period.start_at.ToDateTime().AddSeconds(new_time_period.duration);
                        var old_time_period_end_time = old_time_period.start_at.ToDateTime().AddSeconds(old_time_period.duration);
                        var new_time_period_start_at = new_time_period.start_at.ToDateTime();
                        var old_time_period_start_at = old_time_period.start_at.ToDateTime();

                        if (new_time_period_end_time >= old_time_period_end_time && new_time_period_start_at < old_time_period_start_at)
                        {
                            number_of_time_period_envloped_from_end_time++;
                            if (number_of_time_period_envloped_from_end_time == number_of_error)
                            {
                                clashing_time_periods_types.multiple_envelop_end_time_error = true;
                            }
                        }
                        if (new_time_period_start_at <= old_time_period_start_at && new_time_period_end_time > old_time_period_end_time)
                        {
                            number_of_time_period_enveloped_form_start_time++;
                            if (number_of_time_period_enveloped_form_start_time == number_of_error)
                            {
                                clashing_time_periods_types.multiple_envelop_start_time_error = true;
                            }
                        }

                        if (new_time_period_start_at == old_time_period_start_at)
                        {
                            equal_start_time = true;

                        }
                        if (new_time_period_end_time == old_time_period_end_time)
                        {
                            equal_end_time = true;
                        }


                        if (new_time_period_end_time < old_time_period_end_time && number_of_time_period_envloped_from_end_time > 0 && equal_start_time == false)
                        {
                            check_overlaped_end_time = true;

                        }

                        if (new_time_period_start_at > old_time_period_start_at)
                        {
                            check_overlaped_start_time = true;
                        }


                        if (number_of_time_period_enveloped_form_start_time >= 1)
                        {
                            check_enveloped = true;

                        }
                        if (equal_start_time)
                        {
                            check_overlaped_start_time = false;
                        }

                        if (equal_end_time || check_overlaped_end_time)
                        {
                            check_enveloped = false;
                        }

                    }
                    violation_index++;
                }
                list_of_time_period = list_of_time_period.Skip(1).ToList();
            }
        }
        if (equal_start_time && equal_end_time)
        {
            clashing_time_periods_types.multiple_envelop_when_start_and_end_time_is_the_same = true;
        }
        if (check_overlaped_start_time && check_enveloped)
        {
            clashing_time_periods_types.multiple_envelop_start_is_overlapped_end_time_is_greater = true;
        }
        if (check_overlaped_end_time && check_overlaped_start_time)
        {
            clashing_time_periods_types.multiple_envelop_start_and_end_time_overlapped = true;
        }
        else if (check_overlaped_end_time)
        {
            clashing_time_periods_types.multiple_envelop_start_is_less_than_old_start_and_end_time_is_overlapped = true;
        }

        return clashing_time_periods_types;
        }

        public static ClashingTimePeriodstypesError clashing_break_validation_for_multiple_overlap_and_envelop (this IEnumerable<TimePeriod> list_of_time_period, TimePeriod new_time_period)
        {
            var violation_result = new CheckBatchOfViolation().validate(list_of_time_period).ToList();
            var number_of_error = violation_result.Where(x => x is ViolationCheckResult.BlockClashError).Select(x => x).Count();

            var clashing_time_periods_types = new ClashingTimePeriodstypesError();

            var number_of_time_period_envloped_from_end_time = 0;
            var equal_start_time = false;
            var equal_end_time = false;
            var check_overlaped_start_time = false;
            var check_overlaped_end_time = false;
            var new_time_period_end_time_is_less_than_old_end_time = false;

            var violation_index = 0;
            if (number_of_error > 1)
            {
                foreach (var old_time_period in list_of_time_period)
                {
                    var number_of_time_period = list_of_time_period.Count() - 1;

                    for (var i = 0; i < number_of_time_period; i++)
                    {
                        var get_result = violation_result[violation_index];

                        if (get_result is ViolationCheckResult.BlockClashError)
                        {

                            var new_time_period_end_time = new_time_period.start_at.ToDateTime().AddSeconds(new_time_period.duration);
                            var old_time_period_end_time = old_time_period.start_at.ToDateTime().AddSeconds(old_time_period.duration);
                            var new_time_period_start_at = new_time_period.start_at.ToDateTime();
                            var old_time_period_start_at = old_time_period.start_at.ToDateTime();

                            if (new_time_period_end_time >= old_time_period_end_time && new_time_period.start_at.ToDateTime() < old_time_period.start_at.ToDateTime())
                            {
                                number_of_time_period_envloped_from_end_time++;
                            }
                            if (new_time_period_start_at == old_time_period_start_at)
                            {
                                equal_start_time = true;

                            }
                            if (new_time_period_end_time == old_time_period_end_time)
                            {
                                equal_end_time = true;
                            }

                            if (new_time_period_end_time < old_time_period_end_time && number_of_time_period_envloped_from_end_time > 0 && equal_start_time == false)
                            {
                                check_overlaped_end_time = true;

                            }
                            if (new_time_period_end_time < old_time_period_end_time)
                            {
                                new_time_period_end_time_is_less_than_old_end_time = true;
                            }

                            if (new_time_period_start_at > old_time_period_start_at)
                            {
                                check_overlaped_start_time = true;
                            }
                            if (equal_start_time)
                            {
                                check_overlaped_start_time = false;
                            }
                        }
                        violation_index++;
                    }
                    list_of_time_period = list_of_time_period.Skip(1).ToList();
                }
            }
            if (equal_start_time && new_time_period_end_time_is_less_than_old_end_time)
            {
                clashing_time_periods_types.multiple_envelop_same_start_time_and_overlapped_end_time = true;
            }

            if (equal_end_time && check_overlaped_start_time)
            {
                clashing_time_periods_types.multiple_envelop_start_time_is_overlapped_and_end_time_is_the_same = true;
            }

            if (check_overlaped_end_time && check_overlaped_start_time)
            {
                clashing_time_periods_types.multiple_envelop_start_and_end_time_overlapped = true;
            }
            return clashing_time_periods_types;
        }
    }
}

public class ClashingTimePeriodstypesError
{
    public bool single_overlapped_start_time_error { get; set; }
    public bool single_overlapped_duration_error { get; set; }
    public bool single_envelop_error { get; set; }

    public bool single_enveloped_start_time_and_end_time_error { get; set; }

    public bool single_envelop_start_time_and_end_time_error { get; set; }
    public bool single_envelop_start_time_error { get; set; }
    public bool single_envelop_duration_error { get; set; }

    public bool multiple_envelop_start_time_error { get; set; }
    public bool multiple_envelop_end_time_error { get; set; }
    public bool multiple_envelop_when_start_and_end_time_is_the_same { get; set; }

    public bool multiple_envelop_start_is_less_than_old_start_and_end_time_is_overlapped { get; set; }
    public bool multiple_envelop_start_is_overlapped_end_time_is_greater { get; set; }

    public bool multiple_envelop_start_and_end_time_overlapped { get; set; }
    public bool multiple_envelop_same_start_time_and_overlapped_end_time { get; set; }
    public bool multiple_envelop_start_time_is_overlapped_and_end_time_is_the_same { get; set; }
}