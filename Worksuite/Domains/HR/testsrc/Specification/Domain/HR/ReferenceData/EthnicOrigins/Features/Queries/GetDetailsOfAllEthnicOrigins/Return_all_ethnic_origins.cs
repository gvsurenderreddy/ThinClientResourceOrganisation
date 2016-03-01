using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfAllReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.EthnicOrigins;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.Queries.GetDetailsOfAllEthnicOrigins
{
    [TestClass]
    public class Return_all_ethnic_origins
                        : Returns_all_entries<  EthnicOrigin,
                                                EthnicOriginBuilder,
                                                EthnicOriginDetails,
                                                GetDetailsOfAllEthnicOriginsFixture
                                             > {}
}