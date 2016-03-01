using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Remove
{
    /// <summary>
    ///     Removes the marital Status specified in the supplied request.
    ///     It is not considered an error if the marital status does not exist.
    /// </summary>
    public interface IRemoveMaritalStatus
        :   IRemoveReferenceData<RemoveMaritalStatusRequest, RemoveMaritalStatusResponse> {}
}
