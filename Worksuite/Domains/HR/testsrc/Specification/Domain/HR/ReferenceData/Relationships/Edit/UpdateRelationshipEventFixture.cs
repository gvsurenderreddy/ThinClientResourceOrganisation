using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Events;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Edit
{
    public class UpdateRelationshipEventFixture
                        : UpdateReferenceDataEventFixture<Relationship,
                                                        UpdateRelationshipRequest,
                                                        UpdateRelationshipResponse,
                                                        IUpdateRelationship,
                                                        RelationshipUpdatedEvent
                                                   >
    {
        public UpdateRelationshipEventFixture(IUpdateRelationship the_command,
                                            IRequestHelper<UpdateRelationshipRequest> the_request_builder,
                                            IEntityRepository<Relationship> the_repository,
                                            FakeEventPublisher<RelationshipUpdatedEvent> the_events_publisher
                                        )
            : base(the_command,
                    the_request_builder,
                    the_repository,
                    the_events_publisher
                  ) { }
    }

}