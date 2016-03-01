using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New.GetCreateRequest;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Is_Hidden;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Fields.Is_Hidden
{
    [TestClass]
    public class Is_Hidden_for_a_Title_defaults_to_false_for_an_ethnic_origin
                        : Is_Hidden_defaults_to_false<  CreateEthnicOriginRequest,
                                                        GetCreateEthnicOriginRequestResponse,
                                                        IGetCreateEthnicOriginRequest
                                                     > {}
}
