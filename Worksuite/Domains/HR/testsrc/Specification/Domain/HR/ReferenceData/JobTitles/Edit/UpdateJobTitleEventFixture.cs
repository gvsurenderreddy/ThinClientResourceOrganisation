using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Events;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.JobTitles.Edit
{
    public class UpdateJobTitleEventFixture
                        : UpdateReferenceDataEventFixture<JobTitle,
                                                        UpdateJobTitleRequest,
                                                        UpdateJobTitleResponse,
                                                        IUpdateJobTitle,
                                                        JobTitleUpdatedEvent
                                                   >
    {
        public UpdateJobTitleEventFixture(IUpdateJobTitle the_command,
                                            IRequestHelper<UpdateJobTitleRequest> the_request_builder,
                                            IEntityRepository<JobTitle> the_repository,
                                            FakeEventPublisher<JobTitleUpdatedEvent> the_events_publisher
                                        )
            : base(the_command,
                    the_request_builder,
                    the_repository,
                    the_events_publisher
                  ) { }
    }

}