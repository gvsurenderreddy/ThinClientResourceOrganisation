using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New.GetCreateRequest;

namespace WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New
{
    /// <summary>
    ///     Creates a new 'CreateMaritalStatusRequest' object
    /// </summary>
    public class GetCreateMaritalStatusRequest
                        :   GetCreateReferenceDataRequest<CreateMaritalStatusRequest, GetCreateMaritalStatusRequestResponse>,
                            IGetCreateMaritalStatusRequest {}
}
