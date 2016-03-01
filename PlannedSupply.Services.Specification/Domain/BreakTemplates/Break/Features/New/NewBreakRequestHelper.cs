using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.ShiftBreakTemplates;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.New
{
    public class NewBreakRequestHelper
                    : IRequestHelper<NewBreakRequest>
    {
        public NewBreakRequest given_a_valid_request()
        {
            var break_template_identity = break_template_identity_helper.get_identity();

            break_template_helper = DependencyResolver.resolve<BreakTemplateHelper>();

            break_template = break_template_helper
                              .add()
                              .template_name("A breakk template")
                               .add_break(new Breaks.Break { id = 1, offset_from_start_time_in_seconds = 3600, duration_in_seconds = 7200, is_paid = false, })
                               .add_break(new Breaks.Break { id = 3, offset_from_start_time_in_seconds = 21600, duration_in_seconds = 3600, is_paid = false })
                               .add_break(new Breaks.Break { id = 4, offset_from_start_time_in_seconds = 28800, duration_in_seconds = 3600, is_paid = false })
                               .add_break(new Breaks.Break { id = 5, offset_from_start_time_in_seconds = 36000, duration_in_seconds = 3600, is_paid = false })
                              .entity;

            break_template_identity.template_id = break_template.id;
            return new NewBreakRequest
                            {
                                template_id = break_template_identity.template_id,
                                off_set = new DurationRequest { hours = "11", minutes = "0" },
                                duration = new DurationRequest { hours = "1", minutes = "0" },
                                is_paid = false
                            };
        }

        public NewBreakRequestHelper()
        {
            break_template_identity_helper = DependencyResolver.resolve<BreakTemplateIdentityHelper>();
        }

        private readonly BreakTemplateIdentityHelper break_template_identity_helper;
        private BreakTemplateHelper break_template_helper;
        private BreakTemplate break_template;
    }
  
}