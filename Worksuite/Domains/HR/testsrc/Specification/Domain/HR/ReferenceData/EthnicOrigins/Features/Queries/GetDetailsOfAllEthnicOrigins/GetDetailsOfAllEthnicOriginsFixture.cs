using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfAllReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.EthnicOrigins;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.Queries.GetDetailsOfAllEthnicOrigins
{
    public class GetDetailsOfAllEthnicOriginsFixture
                        :   GetDetailsOfAllReferenceDataFixture<    EthnicOrigin,
                                                                    EthnicOriginDetails,
                                                                    IGetDetailsOfAllEthnicOrigins,
                                                                    EthnicOriginBuilder,
                                                                    FakeEthnicOriginRepository,
                                                                    EthnicOriginHelper
                                                               >
    {
        public GetDetailsOfAllEthnicOriginsFixture(   EthnicOriginHelper the_helper,
                                                        IGetDetailsOfAllEthnicOrigins the_query
                                                    )
                        : base( the_helper, the_query ) {}
    }
}