using Content.Services.PlannedSupply.Messages;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates.Breaks;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit.Update;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New.Create;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.BreakTemplates.Break.Fields.off_set_in_seconds
{
    public class Off_set_should_be_mandatory
    {
        [TestClass]
        public class OnCreate
                        : MandatoryDurationFieldSpecification < NewBreakRequest,
                                                                NewBreakResponse,
                                                                NewBreakFixture
                                                              >
        {
            public OnCreate()
                : base((request, off_set) => request.off_set = new DurationRequest { hours = off_set.hours, minutes = off_set.minutes }) { }
        }

        [TestClass]
        public class OnUpdate
                        : MandatoryDurationFieldSpecification < UpdateBreakRequest,
                                                                UpdateBreakResponse,
                                                                UpdateBreakFixture
                                                              >
        {
            public OnUpdate()
                : base((request, off_set) => request.off_set = new DurationRequest { hours = off_set.hours, minutes = off_set.minutes }) { }
        }

        [TestClass]
        public class Given_both_minutes_and_hour_are_not_specifed_on_create
                                                         : PlannedSupplySpecification
        {
            [TestMethod]
            public void should_report_error()
            {
                BreakTemplate break_template = break_template_helper
                                                .add()
                                                .entity
                                                ;

                var request = new NewBreakRequest
                {
                    template_id = break_template.id,
                    duration = new DurationRequest
                    {
                        hours = "1",
                        minutes = "15"
                    },
                    off_set = new DurationRequest(),
                    is_paid = true
                };

                var response = new_break
                                    .execute(request)
                                    ;

                response.has_errors.Should().BeTrue();
                response.messages.Should().Contain(m => m.field_name == "off_set" && m.message == ValidationMessages.error_00_0064);
                response.messages.Should().Contain(m => m.message == WarningMessages.warning_03_0025);
            }

            protected override void test_setup()
            {
                base.test_setup();
                break_template_helper = DependencyResolver.resolve<BreakTemplateHelper>();
                new_break = DependencyResolver.resolve<INewBreak>();
            }

            private INewBreak new_break;
            private BreakTemplateHelper break_template_helper;
        }

        [TestClass]
        public class Given_both_minutes_and_hour_are_not_specifed_on_update
                                                       : PlannedSupplySpecification
        {
            [TestMethod]
            public void should_report_error()
            {
                var breakk = break_helper
                    .add()
                    .entity
                    ;

                BreakTemplate break_template = break_template_helper
                    .add()
                    .entity
                    ;

                break_template.all_breaks.Add(breakk);

                var request = new UpdateBreakRequest
                {
                    template_id = break_template.id,
                    break_id = breakk.id,
                    duration = new DurationRequest
                    {
                        hours = "1",
                        minutes = "15"
                    },
                    off_set = new DurationRequest(),
                    is_paid = true,
                    current_priority = "1"
                };

                var response = update_break
                    .execute(request)
                    ;

                response.has_errors.Should().BeTrue();
                response.messages.Should().Contain(m => m.field_name == "off_set" && m.message == ValidationMessages.error_00_0064);
                response.messages.Should().Contain(m => m.message == WarningMessages.warning_03_0026);
            }

            protected override void test_setup()
            {
                base.test_setup();
                break_template_helper = DependencyResolver.resolve<BreakTemplateHelper>();
                break_helper = DependencyResolver.resolve<BreakHelper>();
                update_break = DependencyResolver.resolve<IUpdateBreak>();
            }

            private IUpdateBreak update_break;
            private BreakTemplateHelper break_template_helper;
            private BreakHelper break_helper;
        }
    }
}