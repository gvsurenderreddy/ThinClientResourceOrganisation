using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.EthnicOrigins;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.Queries.GetDetailsOfASpecificEthnicOrigin
{
    [TestClass]
    public class Returns_the_correct_ethnic_origin
                        : Returns_the_correct_entity<   EthnicOrigin,
                                                        EthnicOriginBuilder,
                                                        EthnicOriginDetails,
                                                        GetDetailsOfASpecificEthnicOriginFixture
                                                    > {}
}
