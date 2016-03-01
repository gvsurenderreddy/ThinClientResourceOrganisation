using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Is_Hidden;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Fields.Is_Hidden
{
    [TestClass]
    public class Is_Hidden_can_be_specified_when_adding_an_ethnic_origin
                        : Is_Hidden_can_be_specified_when_adding_a_new_entry<   EthnicOrigin,
                                                                                CreateEthnicOriginRequest,
                                                                                CreateEthnicOriginResponse,
                                                                                ICreateEthnicOrigin,
                                                                                NewEthnicOriginFixture
                                                                            > {}
}
