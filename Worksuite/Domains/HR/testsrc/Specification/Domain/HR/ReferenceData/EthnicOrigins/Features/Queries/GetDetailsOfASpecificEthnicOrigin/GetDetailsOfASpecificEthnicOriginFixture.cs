using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.EthnicOrigins;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.Queries.GetDetailsOfASpecificEthnicOrigin
{
    public class GetDetailsOfASpecificEthnicOriginFixture
                        : GetDetailsOfASpecificReferenceDataFixture<    EthnicOrigin,
                                                                        EthnicOriginDetails,
                                                                        IGetDetailsOfASpecificEthnicOrigin,
                                                                        EthnicOriginBuilder,
                                                                        GetDetailsOfASepecificEthnicOriginHelper
                                                                   >
    {
        public GetDetailsOfASpecificEthnicOriginFixture(    GetDetailsOfASepecificEthnicOriginHelper the_request_builder,
                                                            IGetDetailsOfASpecificEthnicOrigin the_query
                                                       )
                        : base ( the_request_builder, the_query ) { }
    }
}