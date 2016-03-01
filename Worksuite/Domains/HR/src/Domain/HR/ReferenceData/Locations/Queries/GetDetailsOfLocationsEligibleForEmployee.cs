using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Locations.Queries
{
    public class GetDetailsOfLocationsEligibleForEmployee
                    : GetDetailsOfReferencDataEligibleForEmployee<Location, LocationDetails>,
                        IGetDetailsOfLocationsEligibleForEmployee
    {
        public GetDetailsOfLocationsEligibleForEmployee(IQueryRepository<Employee> the_employee_repository,
                                                        IQueryRepository<Location> the_entity_repository
                                                       )
            : base(the_employee_repository,
                   the_entity_repository
                  ) { }

        protected override IEnumerable<Location> get_entry_assigned_to_employee(IEnumerable<Employee> employee)
        {
            return employee.Select(e => e.location);
        }
    }
}