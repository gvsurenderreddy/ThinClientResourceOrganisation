using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Queries
{
    public class GetDetailsOfASpecificRelationship
                    : GetDetailsOfASpecificReferenceData<RelationshipDetails, Relationship>
                    , IGetDetailsOfASpecificRelationship
    {

        public GetDetailsOfASpecificRelationship
                    (IQueryRepository<Relationship> the_repository)
            : base
                   (the_repository) { }
    }
}