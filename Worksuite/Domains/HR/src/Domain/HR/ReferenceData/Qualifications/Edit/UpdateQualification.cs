using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit
{
    public class UpdateQualification
                        : UpdateReferenceData<Qualification, UpdateQualificationRequest, UpdateQualificationResponse, QualificationUpdatedEvent>,
                            IUpdateQualification
    {
        public UpdateQualification(IUnitOfWork the_unit_of_work,
                                    IEntityRepository<Qualification> the_repository,
                                    IEventPublisher<QualificationUpdatedEvent> the_event_publisher,
                                    Validator the_validator
                                  )
            : base(the_unit_of_work,
                        the_repository,
                        the_event_publisher,
                        the_validator
                    ) { }
    }
}