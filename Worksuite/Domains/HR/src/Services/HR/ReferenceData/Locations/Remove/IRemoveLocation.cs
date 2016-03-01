using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Locations.Remove
{
    /// <summary>
    ///     Removes the location specified in the supplied request. It is not
    /// considered an error if the location does not exist.
    /// </summary>
    public interface IRemoveLocation
                        : IRemoveReferenceData<RemoveLocationRequest,
                                               RemoveLocationResponse
                                              > { }
}