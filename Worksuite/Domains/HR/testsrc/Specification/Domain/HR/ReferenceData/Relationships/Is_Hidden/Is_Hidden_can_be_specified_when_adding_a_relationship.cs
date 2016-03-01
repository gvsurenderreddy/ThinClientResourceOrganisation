using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Is_Hidden;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Is_Hidden
{
    public class Is_Hidden_can_be_specified_when_adding_a_relationship 
        : Is_Hidden_can_be_specified_when_adding_a_new_entry<Relationship, CreateRelationshipRequest, CreateRelationshipResponse, ICreateRelationship, NewRelationshipFixture> { }
}