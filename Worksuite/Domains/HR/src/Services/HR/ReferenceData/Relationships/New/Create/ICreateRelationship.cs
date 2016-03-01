using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New.Create
{
    /// <summary>
    ///     Creates a new relationship from the supplied request and returns the identity 
    /// of the new relationship in the response object. If the request was not valid the errors
    /// are reported in the response object and a null identity is returned.
    /// </summary>
    public interface ICreateRelationship
                        : ICreateReferenceData<CreateRelationshipRequest, CreateRelationshipResponse> { }
}