using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Events;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.Edit
{
    public class UpdateEthnicOriginEventFixture
                        : UpdateReferenceDataEventFixture<EthnicOrigin,
                                                        UpdateEthnicOriginRequest,
                                                        UpdateEthnicOriginResponse,
                                                        IUpdateEthnicOrigin,
                                                        EthnicOriginUpdatedEvent
                                                   >
    {
        public UpdateEthnicOriginEventFixture(IUpdateEthnicOrigin the_command,
                                            IRequestHelper<UpdateEthnicOriginRequest> the_request_builder,
                                            IEntityRepository<EthnicOrigin> the_repository,
                                            FakeEventPublisher<EthnicOriginUpdatedEvent> the_events_publisher
                                        )
            : base(the_command,
                    the_request_builder,
                    the_repository,
                    the_events_publisher
                  ) { }
    }

}