using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.Edit
{
    [TestClass]
    public class GetUpdateEthnicOriginRequest_will
                        : GetUpdateReferenceDataRequest_will<   EthnicOrigin,
                                                                UpdateEthnicOriginRequest,
                                                                GetUpdateEthnicOriginRequestResponse,
                                                                IGetUpdateEthnicOriginRequest
                                                            > {}
}
