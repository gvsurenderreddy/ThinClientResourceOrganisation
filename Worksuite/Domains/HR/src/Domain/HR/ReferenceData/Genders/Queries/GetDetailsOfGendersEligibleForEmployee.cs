using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Genders.Queries {

    public class GetDetailsOfGendersEligibleForEmployee 
                    : GetDetailsOfReferencDataEligibleForEmployee<Gender,GenderDetails> 
                    , IGetDetailsOfGendersEligibleForEmployee {

        public GetDetailsOfGendersEligibleForEmployee 
                     ( IQueryRepository<Employee> the_employee_repository
                     , IQueryRepository<Gender> the_title_repository ) 
              : base
                     ( the_employee_repository
                     , the_title_repository ) {}


        protected override IEnumerable<Gender> get_entry_assigned_to_employee 
                                                ( IEnumerable<Employee> employees ) {

            return employees.Select( e => e.gender) ;
        }
    }
}