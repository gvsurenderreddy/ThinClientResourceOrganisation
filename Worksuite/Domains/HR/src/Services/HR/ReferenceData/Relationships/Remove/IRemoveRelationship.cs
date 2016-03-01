using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Remove {

    /// <summary>
    ///     Removes the relationship specified in the supplied request. It is not
    /// considered an error if the relationship does not exist.
    /// </summary>
    public interface IRemoveRelationship
                        : IRemoveReferenceData<RemoveRelationshipRequest,RemoveRelationshipResponse> { }
}