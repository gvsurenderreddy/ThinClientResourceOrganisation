using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.ShiftBreakTemplates
{
    public class BreakTemplateIdentityHelper
    {
        public BreakTemplateIdentity get_identity()
        {
            return new BreakTemplateIdentity
            {
                template_id = _break_template.id
            };
        }

        public BreakTemplateIdentityHelper()
        {
            _break_template_helper = DependencyResolver.resolve<BreakTemplateHelper>();

            _break_template = _break_template_helper
                                        .add()
                                        .template_name("A breakk template")
                                        .entity
                                        ;
        }

        private BreakTemplateHelper _break_template_helper;
        private readonly BreakTemplate _break_template;
       
    }
}