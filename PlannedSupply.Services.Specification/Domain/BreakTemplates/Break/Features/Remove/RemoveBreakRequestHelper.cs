using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates.Breaks;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.Remove
{
    public class RemoveBreakRequestHelper
                        : IRequestHelper<BreakIdentity>
    {
        public BreakIdentity given_a_valid_request()
        {
            Breaks.Break breakk = break_helper
                                           .add()
                                           .off_set_in_seconds(5400)
                                           .entity;

            BreakTemplate break_template = break_template_helper
                                                            .add()
                                                            .template_name("A shift breakk template")
                                                            .add_break(breakk)
                                                            .entity
                                                            ;

            return new BreakIdentity
                        {
                            template_id = break_template.id,
                            break_id = breakk.id
                        };
        }

        public RemoveBreakRequestHelper(BreakTemplateHelper the_break_template_helper,
                                              BreakHelper the_break_builder)
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