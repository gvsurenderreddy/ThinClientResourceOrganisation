using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit
{

    public class UpdateRelationship
                    : UpdateReferenceData<Relationship, UpdateRelationshipRequest, UpdateRelationshipResponse, RelationshipUpdatedEvent>
                    , IUpdateRelationship
    {

        public UpdateRelationship
                    (IUnitOfWork the_unit_of_work
                    , IEntityRepository<Relationship> the_repository
            , IEventPublisher<RelationshipUpdatedEvent> the_event_publisher
                    , Validator the_validator)
            : base
                   (the_unit_of_work
                   , the_repository
                    , the_event_publisher
                   , the_validator) { }
    }
}