using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit.GetUpdateRequest
{
    /// <summary>
    ///     Creates an 'UpdateQualificationRequest' object with the values of the qualification that is to be edited.
    ///     This returns our standard response object.
    /// 
    ///     If the qualification does not exits then an null object is returned and the response is set to have errors.
    /// </summary>
    public interface IGetUpdateQualificationRequest
                            :   IGetUpdateReferenceDataRequest< UpdateQualificationRequest,
                                                                GetUpdateQualificationRequestResponse
                                                              > {}
}
