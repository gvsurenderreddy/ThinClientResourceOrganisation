using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Description
{
    public class The_description_for_a_Relationship_is_sanitised_when_creating : A_description_is_mandatory_on_create<Relationship, CreateRelationshipRequest, CreateRelationshipResponse, ICreateRelationship, NewRelationshipFixture> { }
}