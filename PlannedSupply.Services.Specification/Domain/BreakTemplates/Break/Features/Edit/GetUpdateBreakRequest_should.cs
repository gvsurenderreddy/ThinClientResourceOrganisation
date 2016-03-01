using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates.Breaks;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit.GetUpdateRequest;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.Edit
{
    [TestClass]
    public class GetUpdateBreakRequest_should
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void return_a_valid_update_break_request()
        {
            const int off_set_in_seconds = 6180;
            const int duration_in_seconds = 5400;
            Breaks.Break breakk = break_builder
                                                        .off_set_in_seconds(off_set_in_seconds)
                                                        .duration_in_seconds(duration_in_seconds)
                                                        .is_paid(true)
                                                        .entity;

            BreakTemplate break_template = break_template_helper
                                                            .add()
                                                            .add_break(breakk)
                                                            .entity;

            UpdateBreakRequest request = get_update_break_request
                                                    .execute(new BreakIdentity
                                                    {
                                                        template_id = break_template.id,
                                                        break_id = breakk.id
                                                    })
                                                    .result
                                                    ;

            var actual_off_set = new DurationRequest
                                        {
                                            hours = request.off_set.hours,
                                            minutes = request.off_set.minutes
                                        };

            var actual_duration = new DurationRequest
                                        {
                                            hours = request.duration.hours,
                                            minutes = request.duration.minutes
                                        };

            request.off_set.hours.Should().Be(actual_off_set.hours);
            request.off_set.minutes.Should().Be(actual_off_set.minutes);

            request.duration.hours.Should().Be(actual_duration.hours);
            request.duration.minutes.Should().Be(actual_duration.minutes);

            request.is_paid.Should().BeTrue();
        }

        protected override void test_setup()
        {
            base.test_setup();

            break_template_helper = DependencyResolver.resolve<BreakTemplateHelper>();
            break_builder = DependencyResolver.resolve<BreakBuilder>();
            get_update_break_request = DependencyResolver.resolve<IGetUpdateBreakRequest>();
        }

        private BreakTemplateHelper break_template_helper;
        private BreakBuilder break_builder;
        private IGetUpdateBreakRequest get_update_break_request;
    }
}