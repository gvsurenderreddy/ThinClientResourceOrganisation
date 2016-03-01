using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New.GetCreateRequest
{
    /// <summary>
    ///     Response object returned by the <see cref="IGetCreateRelationshipRequest"/>.  This is our
    /// standard response object with the CreateRequest as it's response property
    /// </summary>
    public class GetCreateRelationshipRequestResponse 
                    : GetCreateReferenceDataRequestResponse<CreateRelationshipRequest> {}
}