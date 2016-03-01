using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Queries
{
    public class GetDetailsOfMaritalStatusesEligibleForEmployee
                        :   GetDetailsOfReferencDataEligibleForEmployee< MaritalStatus, MaritalStatusDetails >,
                            IGetDetailsOfMaritalStatusesEligibleForEmployee
    {
        public GetDetailsOfMaritalStatusesEligibleForEmployee(    IQueryRepository< Employee > the_employee_repository,
                                                                IQueryRepository< MaritalStatus > the_entity_repository
                                                           )
                        :   base( the_employee_repository, the_entity_repository ) {}

        protected override IEnumerable< MaritalStatus > get_entry_assigned_to_employee( IEnumerable< Employee > employees )
        {
            return employees.Select( e => e.maritalStatus );
        }
    }
}