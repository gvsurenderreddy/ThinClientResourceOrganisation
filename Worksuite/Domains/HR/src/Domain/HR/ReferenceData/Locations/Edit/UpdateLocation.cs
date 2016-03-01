using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Locations.Edit
{
    public class UpdateLocation
                    : UpdateReferenceData<Location, UpdateLocationRequest, UpdateLocationResponse, LocationUpdatedEvent>,
                        IUpdateLocation
    {
        public UpdateLocation(IUnitOfWork the_unit_of_work,
                              IEntityRepository<Location> the_repository,
                              IEventPublisher<LocationUpdatedEvent> the_event_publisher,
                              Validator the_validator
                             )
            : base(the_unit_of_work,
                   the_repository,
                   the_event_publisher,
                   the_validator
                  ) { }
    }
}