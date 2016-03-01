using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit
{
    public class UpdateMaritalStatus
                        : UpdateReferenceData<MaritalStatus, UpdateMaritalStatusRequest, UpdateMaritalStatusResponse, MaritalStatusUpdatedEvent>,
                            IUpdateMaritalStatus
    {
        public UpdateMaritalStatus(IUnitOfWork the_unit_of_work,
                            IEntityRepository<MaritalStatus> the_repository,
                            IEventPublisher<MaritalStatusUpdatedEvent> the_event_publisher,
                            Validator the_validator
                          )
            : base(the_unit_of_work,
                        the_repository,
                        the_event_publisher,
                        the_validator
                    ) { }
    }
}
