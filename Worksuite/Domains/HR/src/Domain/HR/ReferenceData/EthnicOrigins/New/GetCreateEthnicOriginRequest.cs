using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New.GetCreateRequest;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New
{
    public class GetCreateEthnicOriginRequest
                        :   GetCreateReferenceDataRequest<  CreateEthnicOriginRequest,
                                                            GetCreateEthnicOriginRequestResponse
                                                         >,
                            IGetCreateEthnicOriginRequest {}
}