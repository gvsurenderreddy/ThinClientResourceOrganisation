using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.GetAll;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.Features.GetAll
{
    public class GetAllFixture
                    : PlannedSupplySpecification
    {
        protected override void test_setup()
        {
            base.test_setup();

            _get_all_operations_calendar_details = DependencyResolver.resolve<IGetAllOperationsCalendars>();
            _operation_calendar_repository = DependencyResolver.resolve<IEntityRepository<OperationsCalendars.OperationalCalendar>>();
        }

        protected OperationsCalendarBuilder add_operations_calendar()
        {
            OperationsCalendarBuilder operations_calendar_builder = new OperationsCalendarBuilder(new OperationsCalendars.OperationalCalendar());
            _operation_calendar_repository.add(operations_calendar_builder.entity);

            return operations_calendar_builder;
        }

        protected IGetAllOperationsCalendars _get_all_operations_calendar_details;
        protected IEntityRepository<OperationsCalendars.OperationalCalendar> _operation_calendar_repository;
    }
}