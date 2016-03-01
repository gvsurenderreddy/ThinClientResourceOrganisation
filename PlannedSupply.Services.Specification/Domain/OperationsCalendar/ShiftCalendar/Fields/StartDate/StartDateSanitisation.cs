using System.Linq;
using Content.Services.PlannedSupply.Messages;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Publish;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.Publish;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Fields.StartDate
{

    [TestClass]
    public class OnPublish : DatePickerSanitisationSpecification < PublishShiftCalendarRequest
                                                              , PublishShiftCalendarResponse
                                                              , PublishDatesShiftCalendarFixture>
    {
        public OnPublish()
            : base((request, start_date_request) => request.start_date = start_date_request)
        {
        }
    }

    [TestClass]
    public class CheckErrorMessageForStartDate : PlannedSupplySpecification
    {
        [TestMethod]
        public void report_error_message_when_start_date_failed_sanitisation()
        {
            fixture.request.start_date = new DateRequest { year = "2015", month = "04", day = "31" };
            fixture.execute_command();
            var response = fixture.response;
            response.messages.Should().Contain(m => m.field_name == "start_date" && m.message == ValidationMessages.error_210220151519);
            response.messages.Should().Contain(m => m.message == WarningMessages.warning_210220151514);
        }

        [TestMethod]
        public void show_red_border_around_fields_when_start_date_failed_sanitisation()
        {
            fixture.request.start_date = new DateRequest { year = "2015", month = "04", day = "31" };
            fixture.execute_command();
            var response = fixture.response;

            Assert.IsTrue(response.messages.Select(msg => msg.field_name).Contains("start_date.year"));
            Assert.IsTrue(response.messages.Select(msg => msg.field_name).Contains("start_date.month"));
            Assert.IsTrue(response.messages.Select(msg => msg.field_name).Contains("start_date.day"));
            Assert.IsTrue(response.messages.Select(msg => msg.field_name).Contains("end_date.year"));
            Assert.IsTrue(response.messages.Select(msg => msg.field_name).Contains("end_date.month"));
            Assert.IsTrue(response.messages.Select(msg => msg.field_name).Contains("end_date.day"));

        }

        protected override void test_setup()
        {
            base.test_setup();
            fixture = DependencyResolver.resolve<PublishDatesShiftCalendarFixture>();
        }
        private PublishDatesShiftCalendarFixture fixture;
    }
    
}
