using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Description
{
    public class A_description_for_a_Relationship_can_not_be_duplicated_is_validated_on_create 
        : A_description_can_not_be_duplicated_is_validated_on_create<Relationship, CreateRelationshipRequest, CreateRelationshipResponse, ICreateRelationship, NewRelationshipFixture> { }

}