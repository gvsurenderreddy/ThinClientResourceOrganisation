using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Features.Edit
{
    public class UpdateBreakTemplateRequestHelper
                        : IRequestHelper<UpdateBreakTemplateRequest>
    {
        public UpdateBreakTemplateRequest given_a_valid_request()
        {
            BreakTemplate break_template = _break_template_helper
                                                            .add()
                                                            .template_name("A shift breakk template A")
                                                            .is_hidden(false)
                                                            .entity
                                                            ;

            return new UpdateBreakTemplateRequest
                            {
                                template_id = break_template.id,
                                template_name = break_template.template_name,
                                is_hidden = break_template.is_hidden
                            };
        }

        public UpdateBreakTemplateRequestHelper(BreakTemplateHelper the_break_template_helper)
        {
            _break_template_helper = Guard.IsNotNull(the_break_template_helper,
                                                           "the_break_template_helper"
                                                          );
        }

        private readonly BreakTemplateHelper _break_template_helper;
    }
}