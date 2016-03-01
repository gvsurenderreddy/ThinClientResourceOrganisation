using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates.Breaks;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.ShiftBreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit.GetUpdateRequest;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New.GetCreateRequest;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Fields.is_paid
{
    [TestClass]
    public class The_value_of_is_paid_is_mapped_to_the_is_paid_field
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void Default_to_false_on_create()
        {
            var _break_template_identity = _break_template_identity_helper.get_identity();

            var get_new_break_request_command = DependencyResolver.resolve<IGetNewBreakRequest>();
            NewBreakRequest new_break_request = get_new_break_request_command
                                                                .execute(new BreakIdentity { template_id = _break_template_identity.template_id })
                                                                ;

            new_break_request.is_paid.Should().BeFalse();
        }

        [TestMethod]
        public void Default_to_false_on_update()
        {
            var breakk = _break_helper
                                    .add()
                                    .entity
                                    ;

            BreakTemplate break_template = _break_template_helper
                                                            .add()
                                                            .template_name("A shift breakk template")
                                                            .entity
                                                            ;

            break_template.all_breaks.Add(breakk);

            var get_update_break_request_command = DependencyResolver.resolve<IGetUpdateBreakRequest>();
            UpdateBreakRequest update_break_request = get_update_break_request_command
                                                                .execute(new BreakIdentity { template_id = break_template.id, break_id = breakk.id })
                                                                .result
                                                                ;

            update_break_request.is_paid.Should().BeFalse();
        }

        protected override void test_setup()
        {
            base.test_setup();

            _break_template_helper = DependencyResolver.resolve<BreakTemplateHelper>();
            _break_helper = DependencyResolver.resolve<BreakHelper>();
            _break_template_identity_helper = DependencyResolver.resolve<BreakTemplateIdentityHelper>();
        }

        private BreakTemplateHelper _break_template_helper;
        private BreakHelper _break_helper;

        private BreakTemplateIdentityHelper _break_template_identity_helper;
    }
}