using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.EthnicOrigins;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.Queries.GetDetailsOfASpecificEthnicOrigin
{
    public class GetDetailsOfASepecificEthnicOriginHelper
                    : GetDetailsOfASpecificReferenceDataRequestHelper< EthnicOrigin, EthnicOriginBuilder >
    {
        public GetDetailsOfASepecificEthnicOriginHelper(   IEntityRepository< EthnicOrigin > the_repository,
                                                            EthnicOriginBuilder the_builder
                                                        )
                    : base ( the_repository, the_builder ) {}
    }
}