using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Remove {

    public class RemoveRelationship 
                    : RemoveReferenceData<Relationship,RemoveRelationshipRequest,RemoveRelationshipResponse>
                    , IRemoveRelationship {

        public RemoveRelationship 
                     ( IUnitOfWork the_unit_of_work
                     , IEntityRepository<Relationship> the_title_repository ) 
              : base
                     ( the_unit_of_work
                     , the_title_repository ) {}
    }
}