using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Remove
{
    /// <summary>
    ///     Removes the nationality specified in the supplied request.
    ///     It is not considered an error if the nationality does not exist.
    /// </summary>
    public interface IRemoveNationality
                            : IRemoveReferenceData< RemoveNationalityRequest, RemoveNationalityResponse > {}
}