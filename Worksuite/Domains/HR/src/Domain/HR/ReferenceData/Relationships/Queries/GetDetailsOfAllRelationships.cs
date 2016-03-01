using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Queries
{
    /// <summary>
    ///     Implements the <see cref="IGetDetailsOfAllRelationships"/> query.
    /// It will return all relationships that are stored in the system.
    /// </summary>
    public class GetDetailsOfAllRelationships
                    : GetDetailsOfAllReferenceData<Relationship, RelationshipDetails>
                    , IGetDetailsOfAllRelationships
    {

        public GetDetailsOfAllRelationships
                     (IQueryRepository<Relationship> the_repository)
            : base
                   (the_repository) { }

    }
}