using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.New
{
    public class ShiftTemplatesRequestHelper
                  : IRequestHelper<NewShiftTemplatesRequest>
    {
        public NewShiftTemplatesRequest given_a_valid_request()
        {
            var break_template = break_template_helper
                                    .add()
                                    .template_name("6:00 - 16:00 breakk template")
                                    .entity
                                    ;

            return new NewShiftTemplatesRequest()
            {
                shift_title = "6:00-16:00",
                start_time = new TimeRequest { hours = "10", minutes  = "30" },
                duration = new DurationRequest() { hours = "10" ,minutes = "30"},
                colour = new RGBColourRequest() { R=102 , G =56 , B = 87},
                break_template_id = break_template.id
            };
        }

        public ShiftTemplatesRequestHelper(BreakTemplateHelper the_break_template_helper)
        {
            break_template_helper = Guard.IsNotNull(the_break_template_helper, "the_break_template_helper");
        }

        private readonly BreakTemplateHelper break_template_helper;
    }
}