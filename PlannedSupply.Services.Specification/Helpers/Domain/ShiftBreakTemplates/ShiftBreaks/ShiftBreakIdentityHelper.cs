using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Breaks;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates.Breaks;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.ShiftBreakTemplates.ShiftBreaks
{
    public class BreakIdentityHelper
    {
        public BreakIdentity get_identity()
        {
            return new BreakIdentity
            {
                template_id = _break_template.id,
                break_id = _break.id
            };
        }

        public BreakIdentityHelper()
        {
            var breakTemplateHelper = DependencyResolver.resolve<BreakTemplateHelper>();
            var breakBuilder = DependencyResolver.resolve<BreakBuilder>();

            var break_template_builder = breakTemplateHelper
                                                    .add()
                                                    .template_name("A breakk template")
                                                    ;

            break_template_builder
                .add_break(breakBuilder
                                        .off_set_in_seconds(15300)  // 4 hours and 15 minutes
                                        .duration_in_seconds(2700)  // 0 hours and 45 minutes
                                        .is_paid(true)
                                        .entity)
                ;

            _break_template = break_template_builder.entity;

            _break = _break_template
                                .all_breaks
                                .Single()
                                ;
        }

        private readonly BreakTemplate _break_template;
        private readonly Break _break;
    }
}