using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit.GetUpdateRequest;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New.GetCreateRequest;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.Fields.CalendarName
{
    [TestClass]
    public class A_default_name_for_an_operations_calendar_is_not_supplied_to_force_user_entry
                            : PlannedSupplySpecification
    {
        [TestMethod]
        public void calendar_name_defaults_to_empty_on_create()
        {
            var command = DependencyResolver.resolve<IGetNewOperationsCalendarRequest>();

            NewOperationsCalendarRequest request = command.execute();

            request.calendar_name.Should().BeEmpty();
        }

        [TestMethod]
        public void calendar_name_defaults_to_empty_on_update()
        {
            OperationsCalendars.OperationalCalendar operational_calendar = _operations_calendar_helper
                                                                                .add()
                                                                                .entity;

            var response = _get_update_operations_calendar_request.execute(new OperationsCalendarIdentity
                                                                                    {
                                                                                        operations_calendar_id = operational_calendar.id
                                                                                    });
            UpdateOperationsCalendarRequest request = response.result;

            request.calendar_name.Should().Be(null);
        }

        protected override void test_setup()
        {
            base.test_setup();

            _get_update_operations_calendar_request = DependencyResolver.resolve<IGetUpdateOperationsCalendarRequest>();
            _operations_calendar_helper = DependencyResolver.resolve<OperationsCalendarHelper>();
        }

        private IGetUpdateOperationsCalendarRequest _get_update_operations_calendar_request;
        private OperationsCalendarHelper _operations_calendar_helper;
    }
}