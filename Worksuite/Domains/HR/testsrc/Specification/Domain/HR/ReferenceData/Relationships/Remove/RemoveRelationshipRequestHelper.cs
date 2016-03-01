using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Remove {

    public class RemoveRelationshipRequestHelper 
                    : RemoveReferenceDataRequestBuilder<Relationship,RemoveRelationshipRequest> {

        public RemoveRelationshipRequestHelper 
                        ( IEntityRepository<Relationship> the_repository ) 
                : base 
                        ( the_repository ) {}
    }
}