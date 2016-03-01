using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit.GetUpdateRequest
{
    /// <summary>
    ///     Creates an 'UpdateNationalityRequest' object with the values of the nationality that is to be edited.
    ///     This returns our standard response object.
    /// 
    ///     If the nationality does not exits then a null object is returned and the response is set to have errors.
    /// </summary>
    public interface IGetUpdateNationalityRequest
                            : IGetUpdateReferenceDataRequest< UpdateNationalityRequest, GetUpdateNationalityRequestResponse > {}
}