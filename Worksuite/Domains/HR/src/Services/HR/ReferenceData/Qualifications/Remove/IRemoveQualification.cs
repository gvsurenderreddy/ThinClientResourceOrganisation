using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Remove
{
    /// <summary>
    ///     Removes the qualification specified in the supplied request.
    ///     It is not considered an error if the qualification does not exist.
    /// </summary>
    public interface IRemoveQualification
                        :   IRemoveReferenceData<   RemoveQualificationRequest,
                                                    RemoveQualificationResponse
                                                > {}
}
