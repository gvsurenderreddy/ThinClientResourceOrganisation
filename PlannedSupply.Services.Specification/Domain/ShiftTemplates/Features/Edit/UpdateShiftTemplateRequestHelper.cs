using System;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.ShiftTemplates;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.Edit
{
    public class UpdateShiftTemplateRequestHelper
                     :IRequestHelper<UpdateShiftTemplateRequest>
    {
        public UpdateShiftTemplateRequest given_a_valid_request()
        {
            var duration_request = new DurationRequest() {hours = "1", minutes = "30"};
            var duration_in_second = System.Convert.ToInt32(duration_request.hours)*60*60 +
                                     System.Convert.ToInt32(duration_request.minutes)*60;

            var break_template = break_template_helper
                                    .add()
                                    .template_name("6:00 - 17:00 breakk template")
                                    .entity
                                    ;

            PlannedSupply.ShiftTemplates.ShiftTemplate shift_template = helper
               .add()
               .shift_title("6:00-17:00")
               .start_time(new TimeRequest(){hours = "1",minutes = "30"})
               .duration(duration_in_second.to_duration_request())
               .colour(new RgbColour(25,24,28))
               .break_template(break_template)
               .entity
               ;

            return new UpdateShiftTemplateRequest()
            {
                
                shift_template_id = shift_template.id,
                shift_title = shift_template.shift_title,
                colour = shift_template.colour.to_rgb_colour_request_from_persistence_format(),
                start_time = shift_template.start_time_in_seconds_from_midnight.ToTimeRequestFromSeconds(), 
                duration = shift_template.duration_in_seconds.to_duration_request(),

            };

        }


        public UpdateShiftTemplateRequestHelper(ShiftTemplatehelper the_helper,
                                                BreakTemplateHelper the_break_template_helper
                                               )
        {
            helper = Guard.IsNotNull(the_helper, "the_helper");
            break_template_helper = Guard.IsNotNull(the_break_template_helper, "the_break_template_helper");
        }

        private readonly ShiftTemplatehelper helper;
        private readonly BreakTemplateHelper break_template_helper;
    }

}