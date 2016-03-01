using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates.Breaks;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.ShiftBreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit.GetUpdateRequest;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New.GetCreateRequest;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Fields.duration
{
    [TestClass]
    public class The_value_of_duration_is_mapped_to_the_duration_field
                                                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void Default_to_empty_on_create()
        {
            var break_template_identity = break_template_identity_helper.get_identity();

            var get_new_break_request_command = DependencyResolver.resolve<IGetNewBreakRequest>();
            var new_break_request = get_new_break_request_command
                                                                .execute(new BreakIdentity { template_id = break_template_identity.template_id })
                                                                ;

            new_break_request.duration.hours.Should().BeEmpty();
            new_break_request.duration.minutes.Should().BeEmpty();
        }

        [TestMethod]
        public void Default_to_empty_on_update()
        {
            var breakk = break_helper
                                    .add()
                                    .entity
                                    ;

            var break_template = break_template_helper
                                                     .add()
                                                     .template_name("A shift breakk template")
                                                     .entity
                                                     ;

            break_template.all_breaks.Add(breakk);

            var get_update_break_request_command = DependencyResolver.resolve<IGetUpdateBreakRequest>();
            var update_break_request = get_update_break_request_command
                                                                .execute(new BreakIdentity { template_id = break_template.id, break_id = breakk.id })
                                                                .result
                                                                ;

            update_break_request.duration.hours.Should().Be("0");
            update_break_request.duration.minutes.Should().Be("0");
        }

        protected override void test_setup()
        {
            base.test_setup();

            break_template_helper = DependencyResolver.resolve<BreakTemplateHelper>();
            break_helper = DependencyResolver.resolve<BreakHelper>();
            break_template_identity_helper = DependencyResolver.resolve<BreakTemplateIdentityHelper>();
        }

        private BreakTemplateHelper break_template_helper;
        private BreakHelper break_helper;
        private BreakTemplateIdentityHelper break_template_identity_helper;
    }
}