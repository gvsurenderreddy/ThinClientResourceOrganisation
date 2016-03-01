using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit
{
    public class GetUpdateEthnicOriginRequest
                        :   GetUpdateReferenceDataRequest< EthnicOrigin, UpdateEthnicOriginRequest, GetUpdateEthnicOriginRequestResponse >,
                            IGetUpdateEthnicOriginRequest
    {
        public GetUpdateEthnicOriginRequest( IEntityRepository< EthnicOrigin > the_repository )
                        :   base( the_repository ) {}
    }
}