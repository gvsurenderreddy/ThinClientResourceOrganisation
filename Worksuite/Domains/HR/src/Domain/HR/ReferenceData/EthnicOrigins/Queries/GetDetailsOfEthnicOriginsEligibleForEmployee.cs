using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Queries
{
    public class GetDetailsOfEthnicOriginsEligibleForEmployee
                        :   GetDetailsOfReferencDataEligibleForEmployee< EthnicOrigin, EthnicOriginDetails >,
                            IGetDetailsOfEthnicOriginsEligibleForEmployee
    {
        public GetDetailsOfEthnicOriginsEligibleForEmployee(    IQueryRepository< Employee > the_employee_repository,
                                                                IQueryRepository< EthnicOrigin > the_entity_repository
                                                           )
                        :   base( the_employee_repository, the_entity_repository ) {}

        protected override IEnumerable< EthnicOrigin > get_entry_assigned_to_employee( IEnumerable< Employee > employees )
        {
            return employees.Select( e => e.ethnicOrigin );
        }
    }
}