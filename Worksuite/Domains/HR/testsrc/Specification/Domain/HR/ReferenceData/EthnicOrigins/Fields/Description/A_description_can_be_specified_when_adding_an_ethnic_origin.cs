using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Fields.Description
{
    [TestClass]
    public class A_description_can_be_specified_when_adding_an_ethnic_origin
                        : A_description_can_be_specified_when_adding_a_new_entry<   EthnicOrigin,
                                                                                    CreateEthnicOriginRequest,
                                                                                    CreateEthnicOriginResponse,
                                                                                    ICreateEthnicOrigin,
                                                                                    NewEthnicOriginFixture
                                                                                > {}
}
