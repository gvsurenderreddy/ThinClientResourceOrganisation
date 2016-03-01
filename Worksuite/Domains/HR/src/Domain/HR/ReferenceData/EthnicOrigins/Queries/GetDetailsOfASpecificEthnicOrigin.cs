using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Queries
{
    public class GetDetailsOfASpecificEthnicOrigin
                        :   GetDetailsOfASpecificReferenceData< EthnicOriginDetails, EthnicOrigin >,
                            IGetDetailsOfASpecificEthnicOrigin
    {
        public GetDetailsOfASpecificEthnicOrigin( IQueryRepository< EthnicOrigin > the_repository )
                        :   base( the_repository ) {}
    }
}