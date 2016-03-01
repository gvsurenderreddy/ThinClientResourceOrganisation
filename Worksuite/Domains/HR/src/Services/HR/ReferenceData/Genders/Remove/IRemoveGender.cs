using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Genders.Remove {

    /// <summary>
    ///     Removes the gender specified in the supplied request. It is not
    /// considered an error if the gender does not exist.
    /// </summary>
    public interface IRemoveGender
                        : IRemoveReferenceData<RemoveGenderRequest,RemoveGenderResponse> { }
}