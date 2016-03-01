using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.Edit.Update;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.Features.Edit
{
    public class UpdateOperationsCalendarFixture
                        : ResponseCommandVerifiedByAnEntitiesStateFixture<UpdateOperationsCalendarRequest,
                                                                            UpdateOperationsCalendarResponse,
                                                                            IUpdateOperationsCalendar,
                                                                            PlannedSupply.OperationsCalendars.OperationalCalendar
                                                                         >
    {
        public override PlannedSupply.OperationsCalendars.OperationalCalendar entity
        {
            get
            {
                return _operations_calendar_repository
                                .Entities
                                .Single(oc => oc.id == request.operations_calendar_id && oc.calendar_name == request.calendar_name)
                                ;
            }
        }

        public UpdateOperationsCalendarFixture(IUpdateOperationsCalendar the_update_operations_calendar,
                                                IRequestHelper<UpdateOperationsCalendarRequest> the_update_operations_calendar_request_builder,
                                                IEntityRepository<PlannedSupply.OperationsCalendars.OperationalCalendar> the_operations_calendar_repository
                                           )
            : base(the_update_operations_calendar,
                    the_update_operations_calendar_request_builder
                  )
        {
            _operations_calendar_repository = Guard.IsNotNull(the_operations_calendar_repository,
                                                                "the_operations_calendar_repository"
                                                             );
        }

        private readonly IEntityRepository<PlannedSupply.OperationsCalendars.OperationalCalendar> _operations_calendar_repository;
    }
}