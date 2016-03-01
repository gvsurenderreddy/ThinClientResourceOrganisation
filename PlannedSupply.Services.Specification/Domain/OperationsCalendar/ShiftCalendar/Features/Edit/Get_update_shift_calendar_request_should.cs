using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit.GetUpdateRequest;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.Edit
{
    public class Get_update_shift_calendar_request_should
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void return_a_valid_update_shift_calendar_request()
        {
            var shift_calendar_identity = _shift_calendar_identity_helper.get_identity();

            var shift_calendar = _fake_operations_calendar_repository
                                    .Entities
                                    .Single(oc => oc.id == shift_calendar_identity.operations_calendar_id)
                                    .ShiftCalendars
                                    .Single(sc => sc.id == shift_calendar_identity.shift_calendar_id)
                                    ;

            UpdateShiftCalendarRequest update_shift_calendar_request = _get_update_shift_calendar_request
                                                                    .execute(shift_calendar_identity)
                                                                    .result
                                                                    ;

            Assert.IsTrue(update_shift_calendar_request.calendar_name == shift_calendar.calendar_name);
            Assert.IsTrue(update_shift_calendar_request.shift_calendar_id == shift_calendar_identity.shift_calendar_id);
            Assert.IsTrue(update_shift_calendar_request.operations_calendar_id == shift_calendar_identity.operations_calendar_id);
        }

        protected override void test_setup()
        {
            base.test_setup();

            _shift_calendar_identity_helper = new ShiftCalendarIdentityHelper();
            _get_update_shift_calendar_request = DependencyResolver.resolve<IGetUpdateShiftCalendarRequest>();
            _fake_operations_calendar_repository = DependencyResolver.resolve<FakeOperationsCalendarRepository>();
        }

        private ShiftCalendarIdentityHelper _shift_calendar_identity_helper;
        private IGetUpdateShiftCalendarRequest _get_update_shift_calendar_request;
        private FakeOperationsCalendarRepository _fake_operations_calendar_repository;
    }
}