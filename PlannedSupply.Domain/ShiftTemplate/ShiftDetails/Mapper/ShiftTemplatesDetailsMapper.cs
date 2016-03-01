using System;
using System.Linq.Expressions;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplate.ShiftDetails.Mapper
{
    public class ShiftTemplatesDetailsMapper
                       :IShiftTemplatesDetailsMapper
    {
        public Expression<Func<ShiftTemplates.ShiftTemplate, ShiftTemplateDetails>> Map
        {
          
            get
            {
                return shift_template => new ShiftTemplateDetails()
                {
                      shift_template_id = shift_template.id,
                      shift_title = shift_template.shift_title,
                      colour = shift_template.colour.rgb_colour_format(),
                      start_time = shift_template.start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds(),
                      duration = shift_template.duration_in_seconds.to_duration_request(),
                      end_time = new TimeRequest()
                      {
                          hours = shift_template.start_time_in_seconds_from_midnight.calculate_endtime_from_a_start_time_in_seconds_from_midnight(shift_template.duration_in_seconds).hours,
                          minutes = shift_template.start_time_in_seconds_from_midnight.calculate_endtime_from_a_start_time_in_seconds_from_midnight(shift_template.duration_in_seconds).minutes
                      },
                      break_template_name = shift_template.break_template != null ?  shift_template.break_template.template_name : string.Empty
                }; 
            }
        }
    }
}