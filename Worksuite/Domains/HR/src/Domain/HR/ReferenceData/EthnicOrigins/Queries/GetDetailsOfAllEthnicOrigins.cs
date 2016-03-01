using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Queries
{
    public class GetDetailsOfAllEthnicOrigins
                        :   GetDetailsOfAllReferenceData< EthnicOrigin, EthnicOriginDetails >,
                            IGetDetailsOfAllEthnicOrigins
    {
        public GetDetailsOfAllEthnicOrigins( IQueryRepository< EthnicOrigin > the_repository )
                        :   base( the_repository ) {}
    }
}