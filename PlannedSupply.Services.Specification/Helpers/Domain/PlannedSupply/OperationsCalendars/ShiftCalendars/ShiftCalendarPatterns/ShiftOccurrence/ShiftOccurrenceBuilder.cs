using System;
using System.Collections.Generic;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Duration.Validators;
using WTS.WorkSuite.Library.DomainTypes.Duration.Validators.IsBetweenOneMinuteAndTwentyFourHours;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.Library.DomainTypes.Time.Validators;
using WTS.WorkSuite.Library.DomainTypes.Time.Validators.IsWithInATwentyFourHourDay;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.TimeAllocationOccurrences;
using WTS.WorkSuite.PlannedSupply.TimeAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns.ShiftOccurrence
{
    public class TimeAllocationBuilder
                         : IEntityBuilder<TimeAllocation>
    {


        public TimeAllocation entity
        {
            get { return time_allocation; }
        }

        public TimeAllocationBuilder(TimeAllocation the_time_allocation)
        {
            time_allocation = Guard.IsNotNull(the_time_allocation, "the_time_allocation");

            if (the_time_allocation.colour == null)
            {
                the_time_allocation.colour = Convert.ToString(new RgbColour(255, 255, 255));
            }
            time_allocation = new TimeAllocation()
            {
                id = the_time_allocation.id,
                title = the_time_allocation.title,
                colour = the_time_allocation.colour,
                start_time_in_seconds_from_midnight = the_time_allocation.start_time_in_seconds_from_midnight,
                duration_in_seconds = the_time_allocation.duration_in_seconds,
                TimeAllocationBreaks = the_time_allocation.TimeAllocationBreaks

            };
        }

        public TimeAllocationBuilder shift_title(string value)
        {
            var shift_title = value;
            entity.title = shift_title;
            return this;
        }

        public TimeAllocationBuilder colour(RgbColour value)
        {
            var colour_request = new RgbColour(value.R, value.G, value.B);
            var colour = string.Format("{0},{1},{2}", colour_request.R, colour_request.G, colour_request.B);

            entity.colour = colour;
            return this;
        }

        public TimeAllocationBuilder add_breaks(IEnumerable<TimeAllocationBreaks.TimeAllocationBreak> values)
        {
            values.Do(brk => entity.TimeAllocationBreaks.Add(brk));
            return this;
        }

        public TimeAllocationBuilder add_break(TimeAllocationBreaks.TimeAllocationBreak value)
        {
            entity.TimeAllocationBreaks.Add(value);
            return this;
        }

        public TimeAllocationBuilder start_time(TimeRequest value)
        {

            var time_request = new TimeRequest() { hours = value.hours, minutes = value.minutes };
            var time_in_second = Convert.ToInt32(time_request.hours) * 60 * 60 +
                                 Convert.ToInt32(time_request.minutes) * 60;

            var convertor = new TimeIsWithinATwentyFourHourDay();

            convertor
                .execute(value)
                .Match(

                    is_valid:
                        time_in_seconds_from_midnight => entity.start_time_in_seconds_from_midnight = time_in_second,

                    is_not_valid:
                        errors => { throw new Exception("Test"); }
                );

            return this;
        }
        public TimeAllocationBuilder duration
                                   (DurationRequest value)
        {
            var duration_request = new DurationRequest() { hours = value.hours, minutes = value.minutes };
            var duration_in_second = Convert.ToInt32(duration_request.hours) * 60 * 60 +
                                     Convert.ToInt32(duration_request.minutes) * 60;

            var convertor = new DurationIsBetweenOneMinuteAndTwentyFourHours();

            convertor
                .execute(value)
                .Match(

                    is_valid:
                        duration_in_seconds => entity.duration_in_seconds = duration_in_second,

                    is_not_valid:
                        errors => { throw new Exception("Test"); }
                );

            return this;
        }


        //public TimeAllocationOccurrence seed_a_new_following_occurrence_butting_up_after(ShiftOccurrenceIdentity the_request)
        //{
        //    Guard.IsNotNull(the_request, "the_request");

        //    var pattern = get_pattern.execute(the_request);

        //    var the_occurrence = pattern.TimeAllocationOccurrences.Single(oc => oc.id == the_request.shift_occurrence_id);

        //    the_occurrence.time_allocation.start_time_in_seconds_from_midnight = new TimeRequest()
        //    {
        //        hours = "23",
        //        minutes = "00"
        //    }.to_Seconds();

        //    the_occurrence.time_allocation.duration_in_seconds = new DurationRequest()
        //    {
        //        hours = "1",
        //        minutes = "00"
        //    }.to_seconds();


        //    var time_allocation = new TimeAllocation()
        //    {
        //        colour = "12,13,14",
        //        start_time_in_seconds_from_midnight = 0,
        //        duration_in_seconds = 3600,
        //        title = "c time allocation",
        //        id = -9999
        //    };

        //    var new_occurrence = new TimeAllocationOccurrence()
        //    {
        //        time_allocation = time_allocation,
        //        start_date = the_occurrence.start_date.Date.AddDays(1),
        //        id = -9999
        //    };

        //    pattern.TimeAllocationOccurrences.Add(new_occurrence);

        //    return new_occurrence;
        //}


        private readonly TimeAllocation time_allocation;
    }
}