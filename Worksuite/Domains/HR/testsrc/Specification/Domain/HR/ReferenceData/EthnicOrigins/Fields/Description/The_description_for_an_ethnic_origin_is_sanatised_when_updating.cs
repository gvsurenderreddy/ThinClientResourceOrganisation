using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit.Update;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Fields.Description
{
    [TestClass]
    public class The_description_for_an_ethnic_origin_is_sanatised_when_updating
                        : The_description_is_sanatised_when_updating<   EthnicOrigin,
                                                                        UpdateEthnicOriginRequest,
                                                                        UpdateEthnicOriginResponse,
                                                                        IUpdateEthnicOrigin,
                                                                        UpdateEthnicOriginFixture
                                                                    > {}
}
