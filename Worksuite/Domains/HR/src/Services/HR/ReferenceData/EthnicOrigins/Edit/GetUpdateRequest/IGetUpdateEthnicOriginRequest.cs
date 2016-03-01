using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit.GetUpdateRequest
{
    /// <summary>
    ///     Creates an 'UpdateEthnicOriginRequest' object with the values of the ethnic origin that is to be edited.
    ///     This returns our standard response object.
    /// 
    ///     If the ethnic origin does not exits then a null object is returned and the response is set to have errors.
    /// </summary>
    public interface IGetUpdateEthnicOriginRequest
                            : IGetUpdateReferenceDataRequest<   UpdateEthnicOriginRequest,
                                                                GetUpdateEthnicOriginRequestResponse
                                                            > {}
}