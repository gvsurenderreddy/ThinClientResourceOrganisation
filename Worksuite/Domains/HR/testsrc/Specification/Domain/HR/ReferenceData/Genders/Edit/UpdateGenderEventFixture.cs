﻿using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Events;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.Edit
{
    public class UpdateGenderEventFixture
                        : UpdateReferenceDataEventFixture<Gender,
                                                        UpdateGenderRequest,
                                                        UpdateGenderResponse,
                                                        IUpdateGender,
                                                        GenderUpdatedEvent
                                                   >
    {
        public UpdateGenderEventFixture(IUpdateGender the_command,
                                            IRequestHelper<UpdateGenderRequest> the_request_builder,
                                            IEntityRepository<Gender> the_repository,
                                            FakeEventPublisher<GenderUpdatedEvent> the_events_publisher
                                        )
            : base(the_command,
                    the_request_builder,
                    the_repository,
                    the_events_publisher
                  ) { }
    }

}