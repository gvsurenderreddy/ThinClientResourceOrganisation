using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Titles.Remove {

    /// <summary>
    ///     Removes the title specified in the supplied request. It is not
    /// considered an error if the title does not exist.
    /// </summary>
    public interface IRemoveTitle
                        : IRemoveReferenceData<RemoveTitleRequest,RemoveTitleResponse> { }
}