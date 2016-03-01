using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit.GetUpdateRequest
{
    /// <summary>
    ///     Creates an 'UpdateMaritalStatusRequest' object with the values of the MaritalStatus that is to be edited.
    ///     This returns our standard response object.
    /// 
    ///     If the MaritalStatus does not exits then an null object is returned and the response is set to have errors.
    /// </summary>
    public interface IGetUpdateMaritalStatusRequest
        :   IGetUpdateReferenceDataRequest<UpdateMaritalStatusRequest, GetUpdateMaritalStatusRequestResponse> {}
}
