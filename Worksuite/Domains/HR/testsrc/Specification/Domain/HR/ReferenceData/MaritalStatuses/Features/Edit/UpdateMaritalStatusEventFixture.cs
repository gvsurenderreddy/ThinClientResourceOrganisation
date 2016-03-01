using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Events;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.Edit
{
    public class UpdateMaritalStatusEventFixture
                        : UpdateReferenceDataEventFixture<MaritalStatus,
                                                        UpdateMaritalStatusRequest,
                                                        UpdateMaritalStatusResponse,
                                                        IUpdateMaritalStatus,
                                                        MaritalStatusUpdatedEvent
                                                   >
    {
        public UpdateMaritalStatusEventFixture(IUpdateMaritalStatus the_command,
                                            IRequestHelper<UpdateMaritalStatusRequest> the_request_builder,
                                            IEntityRepository<MaritalStatus> the_repository,
                                            FakeEventPublisher<MaritalStatusUpdatedEvent> the_events_publisher
                                        )
            : base(the_command,
                    the_request_builder,
                    the_repository,
                    the_events_publisher
                  ) { }
    }

}