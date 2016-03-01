using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New.GetCreateRequest;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New
{
    /// <summary>
    ///     Creates a new CreateRelationshipRequest
    /// </summary>
    public class GetCreateRelationshipRequest
                    : GetCreateReferenceDataRequest<CreateRelationshipRequest, GetCreateRelationshipRequestResponse>
                    , IGetCreateRelationshipRequest { }
}