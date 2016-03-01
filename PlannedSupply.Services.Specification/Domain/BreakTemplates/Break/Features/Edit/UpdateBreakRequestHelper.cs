using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates.Breaks;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.Edit
{
    public class UpdateBreakRequestHelper
                        : IRequestHelper<UpdateBreakRequest>
    {
        public UpdateBreakRequest given_a_valid_request()
        {
            Breaks.Break breakk = break_helper
                                  .add()
                                  .off_set_in_seconds(14400)
                                  .duration_in_seconds(3600)
                                  .is_paid(true)
                                  .entity;


            BreakTemplate break_template = break_template_helper
                                                            .add()
                                                            .template_name("A shift breakk template")
                                                            .add_break(new Breaks.Break { id = 1, offset_from_start_time_in_seconds = 3600, duration_in_seconds = 7200, is_paid = false, })
                                                            .add_break(breakk)
                                                            .add_break(new Breaks.Break { id = 3 , offset_from_start_time_in_seconds = 21600 , duration_in_seconds = 3600  , is_paid = false })
                                                            .add_break(new Breaks.Break { id = 4 , offset_from_start_time_in_seconds = 28800 , duration_in_seconds = 3600 , is_paid = false })
                                                            .add_break(new Breaks.Break { id = 5 , offset_from_start_time_in_seconds = 36000 , duration_in_seconds = 3600  , is_paid = false })
                                                            .entity
                                                            ;

            return new UpdateBreakRequest
                            {
                                template_id = break_template.id,
                                break_id = breakk.id=2,
                                off_set = breakk.offset_from_start_time_in_seconds.to_duration_request(),
                                duration = breakk.duration_in_seconds.to_duration_request(),
                                is_paid = breakk.is_paid,
                                current_priority = "1"
                            };
        }

        public UpdateBreakRequestHelper(BreakTemplateHelper the_break_template_helper,
                                              BreakHelper the_break_builder
                                             )
        {
            break_template_helper = Guard.IsNotNull(the_break_template_helper,
                                                           "the_break_template_helper"
                                                          );
            break_helper = Guard.IsNotNull(the_break_builder, "the_break_builder");
        }

        private readonly BreakTemplateHelper break_template_helper;
        private readonly BreakHelper break_helper;
    }
}