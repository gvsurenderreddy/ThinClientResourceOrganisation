using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit
{
    public class UpdateNationality
                        : UpdateReferenceData<Nationality, UpdateNationalityRequest, UpdateNationalityResponse, NationalityUpdatedEvent>,
                            IUpdateNationality
    {
        public UpdateNationality(IUnitOfWork the_unit_of_work,
                                    IEntityRepository<Nationality> the_repository,
                                    IEventPublisher<NationalityUpdatedEvent> the_event_publisher,
                                    Validator the_validator
                                )
            : base(the_unit_of_work,
                    the_repository,
                    the_event_publisher,
                    the_validator
                  ) { }
    }
}