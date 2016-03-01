using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Queries
{
    public class GetDetailsOfNationalitiesEligibleForEmployee
                        :   GetDetailsOfReferencDataEligibleForEmployee< Nationality, NationalityDetails >,
                            IGetDetailsOfNationalitiesEligibleForEmployee
    {
        public GetDetailsOfNationalitiesEligibleForEmployee(   IQueryRepository< Employee > the_employee_repository,
                                                                IQueryRepository< Nationality > the_entity_repository
                                                            )
                        : base( the_employee_repository, the_entity_repository ) {}

        protected override IEnumerable< Nationality > get_entry_assigned_to_employee( IEnumerable< Employee > employees )
        {
            return employees.Select( e => e.nationality );
        }
    }
}