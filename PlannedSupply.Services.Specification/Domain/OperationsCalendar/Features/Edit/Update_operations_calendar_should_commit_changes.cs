using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit.GetUpdateRequest;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit.Update;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.Features.Edit
{
    [TestClass]
    public class Update_operations_calendar_should_commit_changes
                        : CommandCommitedChangesSpecification<UpdateOperationsCalendarRequest,
                                                                UpdateOperationsCalendarResponse,
                                                                UpdateOperationsCalendarFixture
                                                             > { }

    [TestClass]
    public class Get_update_operatioal_calendar_request_should
        : PlannedSupplySpecification
    {
        [TestMethod]
        public void return_a_valid_update_operatioal_calendar_request()
        {
            OperationalCalendar operational_calendar = _operational_calendar_helper
                                                            .add()
                                                            .entity
                                                            ;

            Response<UpdateOperationsCalendarRequest> response = _get_update_operational_calendar_request
                                                                    .execute(new OperationsCalendarIdentity
                                                                                    {
                                                                                        operations_calendar_id = operational_calendar.id,
                                                                                    }
                                                                            )
                                                                    ;

            UpdateOperationsCalendarRequest update_operational_calendar_request = response.result;

            Assert.IsTrue(update_operational_calendar_request.calendar_name == operational_calendar.calendar_name);
            Assert.IsTrue(update_operational_calendar_request.operations_calendar_id == operational_calendar.id);
        }

        protected override void test_setup()
        {
            base.test_setup();

            _operational_calendar_helper = DependencyResolver.resolve<OperationsCalendarHelper>();
            _get_update_operational_calendar_request = DependencyResolver.resolve<IGetUpdateOperationsCalendarRequest>();
        }

        private IGetUpdateOperationsCalendarRequest _get_update_operational_calendar_request;
        private OperationsCalendarHelper _operational_calendar_helper;
    }
}