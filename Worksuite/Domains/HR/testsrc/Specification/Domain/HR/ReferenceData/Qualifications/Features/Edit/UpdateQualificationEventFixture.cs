using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Events;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.Edit
{
    public class UpdateQualificationEventFixture
                        : UpdateReferenceDataEventFixture<Qualification,
                                                        UpdateQualificationRequest,
                                                        UpdateQualificationResponse,
                                                        IUpdateQualification,
                                                        QualificationUpdatedEvent
                                                   >
    {
        public UpdateQualificationEventFixture(IUpdateQualification the_command,
                                            IRequestHelper<UpdateQualificationRequest> the_request_builder,
                                            IEntityRepository<Qualification> the_repository,
                                            FakeEventPublisher<QualificationUpdatedEvent> the_events_publisher
                                        )
            : base(the_command,
                    the_request_builder,
                    the_repository,
                    the_events_publisher
                  ) { }
    }

}