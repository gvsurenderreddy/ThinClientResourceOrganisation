using System;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Duration.Validators;
using WTS.WorkSuite.Library.DomainTypes.Duration.Validators.IsBetweenOneMinuteAndTwentyFourHours;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.Library.DomainTypes.Time.Validators;
using WTS.WorkSuite.Library.DomainTypes.Time.Validators.IsWithInATwentyFourHourDay;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.ShiftTemplates
{
    public class ShiftTemplateBuilder
        : IEntityBuilder<WorkSuite.PlannedSupply.ShiftTemplates.ShiftTemplate>
    {
        public WorkSuite.PlannedSupply.ShiftTemplates.ShiftTemplate entity
        {
            get { return shift_template; }
        }

        public ShiftTemplateBuilder
                            (WorkSuite.PlannedSupply.ShiftTemplates.ShiftTemplate the_shift_template)
        {
            Guard.IsNotNull(the_shift_template, "the_shift_template");
            if (the_shift_template.colour == null)
            {
                the_shift_template.colour = System.Convert.ToString(new RgbColour(255, 255, 255));
            }
            shift_template = new WorkSuite.PlannedSupply.ShiftTemplates.ShiftTemplate()
            {
                id = the_shift_template.id,
                shift_title = the_shift_template.shift_title,
                colour = the_shift_template.colour ,
                start_time_in_seconds_from_midnight = the_shift_template.start_time_in_seconds_from_midnight,
                duration_in_seconds = the_shift_template.duration_in_seconds,
                break_template = the_shift_template.break_template
            };
        }

        public ShiftTemplateBuilder shift_title 
                                       ( string value )
        {
            entity.shift_title = value;
            return this;
        }

        public ShiftTemplateBuilder colour
                                (RgbColour value)
        {
           
            var colour_request = new RgbColour(value.R, value.G, value.B);
            var colour = string.Format("{0},{1},{2}", colour_request.R, colour_request.G, colour_request.B);

            entity.colour = colour;
            return this;
        }

        public ShiftTemplateBuilder end_time
                                    (TimeRequest value)
        {
            var end_time = new TimeRequest() {hours = value.hours, minutes = value.minutes};
            return this;
        }

        public ShiftTemplateBuilder start_time
                                     (TimeRequest value)
        {
            var time_request = new TimeRequest() { hours = value.hours, minutes = value.minutes };
            var time_in_second = System.Convert.ToInt32(time_request.hours) * 60 * 60 +
                                     System.Convert.ToInt32(time_request.minutes) * 60;
            var convertor = new TimeIsWithinATwentyFourHourDay();

            convertor
                .execute(  value )
                .Match(
                
                    is_valid:
                        time_in_seconds_from_midnight => entity.start_time_in_seconds_from_midnight = time_in_second,

                    is_not_valid:
                        errors => { throw new Exception("Test"); }
                );

            return this;
        }

        public ShiftTemplateBuilder duration
                                    (DurationRequest value)
        {
            var duration_request = new DurationRequest() { hours = value.hours, minutes = value.minutes };
            var duration_in_second = System.Convert.ToInt32(duration_request.hours) * 60 * 60 +
                                     System.Convert.ToInt32(duration_request.minutes) * 60;

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

        public ShiftTemplateBuilder break_template(BreakTemplate value)
        {
            entity.break_template = value;

            return this;
        }

    
        private readonly WorkSuite.PlannedSupply.ShiftTemplates.ShiftTemplate shift_template;
    }
}