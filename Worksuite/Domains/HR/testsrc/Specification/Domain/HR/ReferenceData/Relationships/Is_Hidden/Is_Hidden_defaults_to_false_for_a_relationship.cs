using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New.GetCreateRequest;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Is_Hidden;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Is_Hidden
{
    public class Is_Hidden_defaults_to_false_for_a_relationship : Is_Hidden_defaults_to_false<CreateRelationshipRequest, GetCreateRelationshipRequestResponse, IGetCreateRelationshipRequest> { }
}
