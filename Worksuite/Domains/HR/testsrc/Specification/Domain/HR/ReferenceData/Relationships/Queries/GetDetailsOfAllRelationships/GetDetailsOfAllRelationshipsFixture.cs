using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfAllReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Relationships;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Queries.GetDetailsOfAllRelationships
{
    public class GetDetailsOfAllRelationshipsFixture
                    : GetDetailsOfAllReferenceDataFixture<Relationship, RelationshipDetails, IGetDetailsOfAllRelationships, RelationshipBuilder, FakeRelationshipRepository, RelationshipHelper>
    {

        public GetDetailsOfAllRelationshipsFixture
                     (RelationshipHelper the_helper
                     , IGetDetailsOfAllRelationships the_query)
            : base
                   (the_helper
                   , the_query) { }

    }
}