using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Remove;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.Features.Remove
{
    [TestClass]
    public class Remove_operations_calendar_should
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void remove_the_operations_calendar()
        {
            OperationsCalendars.OperationalCalendar operational_calendar = _operation_calendar_helper
                                                                                .add()
                                                                                .calendar_name("A calendar name")
                                                                                .entity
                                                                                ;

            var remove_operations_calendar_request = _get_remove_operations_calendar_request
                                                                    .execute(new OperationsCalendarIdentity
                                                                                        {
                                                                                            operations_calendar_id = operational_calendar.id
                                                                                        }
                                                                            )
                                                                    .result
                                                                    ;

            RemoveOperationsCalendarResponse response = _remove_operations_calendar
                                                                    .execute(new OperationsCalendarIdentity
                                                                                    {
                                                                                        operations_calendar_id = remove_operations_calendar_request.operations_calendar_id
                                                                                    }
                                                                            )
                                                                    ;

            response.has_errors.Should().BeFalse();
        }

        protected override void test_setup()
        {
            base.test_setup();

            _remove_operations_calendar = DependencyResolver.resolve<IRemoveOperationsCalendar>();
            _get_remove_operations_calendar_request = DependencyResolver.resolve<IGetRemoveOperationsCalendarRequest>();
            _operation_calendar_helper = DependencyResolver.resolve<OperationsCalendarHelper>();
        }

        private IGetRemoveOperationsCalendarRequest _get_remove_operations_calendar_request;
        private IRemoveOperationsCalendar _remove_operations_calendar;
        private OperationsCalendarHelper _operation_calendar_helper;
    }
}