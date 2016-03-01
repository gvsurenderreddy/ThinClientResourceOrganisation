using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Relationships;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Queries.GetDetailsOfASpecificRelationship
{
    public class GetDetailsOfASpecificRelationshipHelper
                    : GetDetailsOfASpecificReferenceDataRequestHelper<Relationship, RelationshipBuilder>
    {

        public GetDetailsOfASpecificRelationshipHelper
                       (IEntityRepository<Relationship> the_repository
                       , RelationshipBuilder the_builder)
            : base
                   (the_repository
                   , the_builder) { }
    }
}