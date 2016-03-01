using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Events;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Features.Edit
{
    public class UpdateNationalityEventFixture
                        : UpdateReferenceDataEventFixture<Nationality,
                                                        UpdateNationalityRequest,
                                                        UpdateNationalityResponse,
                                                        IUpdateNationality,
                                                        NationalityUpdatedEvent
                                                   >
    {
        public UpdateNationalityEventFixture(IUpdateNationality the_command,
                                            IRequestHelper<UpdateNationalityRequest> the_request_builder,
                                            IEntityRepository<Nationality> the_repository,
                                            FakeEventPublisher<NationalityUpdatedEvent> the_events_publisher
                                        )
            : base(the_command,
                    the_request_builder,
                    the_repository,
                    the_events_publisher
                  ) { }
    }

}