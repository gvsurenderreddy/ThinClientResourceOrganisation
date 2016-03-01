using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.ShiftTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Queries.GetAllEligibleForShiftTemplate;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.ShiftTemplates.Features.ShiftDetails.GetAllEligibleForShiftTemplate
{
    public class GetAllEligibleBreakTemplatesForAShiftTemplateFixture
    {
        public ShiftTemplateIdentity request
        {
            get
            {
                return new ShiftTemplateIdentity
                {
                    shift_template_id = _shift_template_identity.shift_template_id
                };
            }
        }

        public Maybe<IEnumerable<BreakTemplateDetails>> response
        {
            get;
            private set;
        }

        public virtual void execute_command()
        {
            response = _get_break_templates_eligible_for_a_shift_template_command.execute(request).result.to_maybe();
        }

        public GetAllEligibleBreakTemplatesForAShiftTemplateFixture()
        {
            _shift_template_identity_helper = DependencyResolver.resolve<ShiftTemplateIdentityHelper>();
            _shift_template_identity = _shift_template_identity_helper.get_identity();

            _shift_template_repository = DependencyResolver.resolve<FakeShiftTemplateRepository>();
            _shift_template = _shift_template_repository
                                        .Entities
                                        .Single(sbt => sbt.id == _shift_template_identity.shift_template_id)
                                        ;

            this.response = new Nothing<IEnumerable<BreakTemplateDetails>>();

            _get_break_templates_eligible_for_a_shift_template_command = DependencyResolver.resolve<IGetDetailsOfBreakTemplatesEligibleForShiftTemplate>();
        }

        private ShiftTemplateIdentityHelper _shift_template_identity_helper;
        private FakeShiftTemplateRepository _shift_template_repository;
        private IGetDetailsOfBreakTemplatesEligibleForShiftTemplate _get_break_templates_eligible_for_a_shift_template_command;

        private ShiftTemplateIdentity _shift_template_identity;
        public PlannedSupply.ShiftTemplates.ShiftTemplate _shift_template;
    }
}