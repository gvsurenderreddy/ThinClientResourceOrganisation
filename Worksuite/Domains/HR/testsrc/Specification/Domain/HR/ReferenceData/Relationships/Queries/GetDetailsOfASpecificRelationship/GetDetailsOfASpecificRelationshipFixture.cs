using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Relationships;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Queries.GetDetailsOfASpecificRelationship
{
    public class GetDetailsOfASpecificRelationshipFixture
                    : GetDetailsOfASpecificReferenceDataFixture<Relationship, RelationshipDetails, IGetDetailsOfASpecificRelationship, RelationshipBuilder, GetDetailsOfASpecificRelationshipHelper>
    {

        public GetDetailsOfASpecificRelationshipFixture
                       (GetDetailsOfASpecificRelationshipHelper the_request_builder
                       , IGetDetailsOfASpecificRelationship the_query)
            : base
                   (the_request_builder
                   , the_query) { }
    }
}