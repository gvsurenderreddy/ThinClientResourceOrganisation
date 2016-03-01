using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.Remove
{
    public class RemoveEthnicOriginRequestHelper
                        : RemoveReferenceDataRequestBuilder<    EthnicOrigin,
                                                                RemoveEthnicOriginRequest
                                                           >
    {
        public RemoveEthnicOriginRequestHelper( IEntityRepository< EthnicOrigin > the_repository )
                        : base( the_repository ) {}
    }
}