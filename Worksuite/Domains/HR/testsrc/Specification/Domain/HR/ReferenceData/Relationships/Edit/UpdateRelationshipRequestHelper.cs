using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Edit {

    public class UpdateRelationshipRequestHelper 
                    : UpdateReferenceDataRequestBuilder<Relationship,UpdateRelationshipRequest> {

        public UpdateRelationshipRequestHelper 
                        ( IEntityRepository<Relationship> the_repository ) 
                : base 
                        ( the_repository ) {}
    }
}