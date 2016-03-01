using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit.Update;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Fields.Description
{
    [TestClass]
    public class A_description_for_an_ethnic_origin_is_mandatory_on_update
                        : A_description_is_mandatory_on_update< EthnicOrigin,
                                                                UpdateEthnicOriginRequest,
                                                                UpdateEthnicOriginResponse,
                                                                IUpdateEthnicOrigin,
                                                                UpdateEthnicOriginFixture
                                                              > { }
}