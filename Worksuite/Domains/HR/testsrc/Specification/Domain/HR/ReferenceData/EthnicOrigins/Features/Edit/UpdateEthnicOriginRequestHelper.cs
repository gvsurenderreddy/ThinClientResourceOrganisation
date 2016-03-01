using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.Edit
{
    public class UpdateEthnicOriginRequestHelper
                        : UpdateReferenceDataRequestBuilder< EthnicOrigin, UpdateEthnicOriginRequest >
    {
        public UpdateEthnicOriginRequestHelper( IEntityRepository< EthnicOrigin > the_repository )
                        : base ( the_repository ) {}
    }
}