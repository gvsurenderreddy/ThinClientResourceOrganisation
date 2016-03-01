using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Events;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.Edit
{
    public class UpdateTitleEventFixture
                        : UpdateReferenceDataEventFixture<Title,
                                                        UpdateTitleRequest,
                                                        UpdateTitleResponse,
                                                        IUpdateTitle,
                                                        TitleUpdatedEvent
                                                   >
    {
        public UpdateTitleEventFixture(IUpdateTitle the_command,
                                            IRequestHelper<UpdateTitleRequest> the_request_builder,
                                            IEntityRepository<Title> the_repository,
                                            FakeEventPublisher<TitleUpdatedEvent> the_events_publisher
                                        )
            : base(the_command,
                    the_request_builder,
                    the_repository,
                    the_events_publisher
                  ) { }
    }

}