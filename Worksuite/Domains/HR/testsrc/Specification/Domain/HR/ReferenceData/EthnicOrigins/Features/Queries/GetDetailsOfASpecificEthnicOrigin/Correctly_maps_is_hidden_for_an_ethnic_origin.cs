using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.EthnicOrigins;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.Queries.GetDetailsOfASpecificEthnicOrigin
{
    [TestClass]
    public class Correctly_maps_is_hidden_for_an_ethnic_origin
                        : Correctly_maps_is_hidden< EthnicOrigin,
                                                    EthnicOriginBuilder,
                                                    EthnicOriginDetails,
                                                    GetDetailsOfASpecificEthnicOriginFixture
                                                  > {}
}
