using System.Linq;
using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.Remove
{
    public class RemoveOperationsCalendar
                        : IRemoveOperationsCalendar
    {
        public RemoveOperationsCalendarResponse execute(OperationsCalendarIdentity the_remove_operations_calenar_request)
        {
            return this
                .set_request(the_remove_operations_calenar_request)
                .find_operations_calendar()
                .remove_operations_calendar()
                .commit()
                .build_response()
                ;
        }

        private RemoveOperationsCalendar set_request(OperationsCalendarIdentity the_remove_operations_calendar_request)
        {
            _remove_operations_calendar_request = Guard.IsNotNull(the_remove_operations_calendar_request, "the_new_operations_calendar_request");

            _remove_operations_calendar_response_builder = new ResponseBuilder<RemoveOperationsCalendarResponse>();

            return this;
        }

        private RemoveOperationsCalendar find_operations_calendar()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_remove_operations_calendar_request, "_remove_operations_calendar_request");
            Guard.IsNotNull(_operations_calendar_entity_repository, "_operations_calendar_entity_repository");

            _operational_calendar_to_be_removed = _operations_calendar_entity_repository
                                            .Entities
                                            .Single(oc => oc.id == _remove_operations_calendar_request.operations_calendar_id)
                                            ;

            return this;
        }

        private RemoveOperationsCalendar remove_operations_calendar()
        {
            if (response_builder_has_errors()) return this;

            Guard.IsNotNull(_operational_calendar_to_be_removed, "_operations_calendar_to_be_removed");

            _operations_calendar_entity_repository
                        .remove(_operational_calendar_to_be_removed);

            return this;
        }

        private RemoveOperationsCalendar commit()
        {
            if (response_builder_has_errors()) return this;

            _unit_of_work.Commit();

            return this;
        }

        private RemoveOperationsCalendarResponse build_response()
        {
            if (response_builder_has_errors() == false)
            {
                _remove_operations_calendar_response_builder.add_message(ConfirmationMessages.confirmation_04_0019);
            }
            return _remove_operations_calendar_response_builder.build();
        }

        private bool response_builder_has_errors()
        {
            return _remove_operations_calendar_response_builder.has_errors;
        }

        public RemoveOperationsCalendar(IEntityRepository<OperationsCalendars.OperationalCalendar> the_operations_calendar_entity_repository,
                                            IUnitOfWork the_unit_of_work
                                       )
        {
            _operations_calendar_entity_repository = Guard.IsNotNull(the_operations_calendar_entity_repository,
                                                                        "the_operations_calendar_entity_repository"
                                                                     );
            _unit_of_work = Guard.IsNotNull(the_unit_of_work,
                                                                        "the_unit_of_work"
                                                                     );
        }

        private OperationsCalendars.OperationalCalendar
            _operational_calendar_to_be_removed;

        private OperationsCalendarIdentity _remove_operations_calendar_request;
        private ResponseBuilder<RemoveOperationsCalendarResponse> _remove_operations_calendar_response_builder;
        private readonly IEntityRepository<OperationsCalendars.OperationalCalendar> _operations_calendar_entity_repository;
        private readonly IUnitOfWork _unit_of_work;
    }
}