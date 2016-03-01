using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit.GetUpdateRequest;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit {

    public class GetUpdateRelationshipRequest 
                    : GetUpdateReferenceDataRequest<Relationship,UpdateRelationshipRequest,GetUpdateRelationshipRequestResponse>
                    , IGetUpdateRelationshipRequest {

        public GetUpdateRelationshipRequest 
                     ( IEntityRepository<Relationship> the_repository ) 
              : base 
                     ( the_repository ) {}
    }
}