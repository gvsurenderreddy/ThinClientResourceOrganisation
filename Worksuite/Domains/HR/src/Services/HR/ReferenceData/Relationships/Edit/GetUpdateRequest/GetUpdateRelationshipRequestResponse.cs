using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit.GetUpdateRequest
{
    /// <summary>
    ///     Response object returned by the <see cref="IGetUpdateRelationshipRequest"/>.  This is our
    /// standard response object with the UpdateRequest as it's response property.
    /// </summary>
    public class GetUpdateRelationshipRequestResponse
                    : GetUpdateReferenceDataRequestResponse<UpdateRelationshipRequest> { } 
}