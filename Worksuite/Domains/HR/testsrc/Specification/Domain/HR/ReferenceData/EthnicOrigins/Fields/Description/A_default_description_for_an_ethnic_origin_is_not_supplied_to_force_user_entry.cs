using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New.GetCreateRequest;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Fields.Description
{
    [TestClass]
    public class A_default_description_for_an_ethnic_origin_is_not_supplied_to_force_user_entry
                        : A_default_description_is_not_supplied_to_force_user_entry<    CreateEthnicOriginRequest,
                                                                                        GetCreateEthnicOriginRequestResponse,
                                                                                        IGetCreateEthnicOriginRequest
                                                                                   > {}
}
