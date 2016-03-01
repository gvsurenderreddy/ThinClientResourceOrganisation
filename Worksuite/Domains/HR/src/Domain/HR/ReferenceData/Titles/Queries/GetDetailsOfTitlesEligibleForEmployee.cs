using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Titles.Queries {

    public class GetDetailsOfTitlesEligibleForEmployee 
                    : GetDetailsOfReferencDataEligibleForEmployee<Title,TitleDetails> 
                    , IGetDetailsOfTitlesEligibleForEmployee {

        public GetDetailsOfTitlesEligibleForEmployee 
                     ( IQueryRepository<Employee> the_employee_repository
                     , IQueryRepository<Title> the_title_repository ) 
              : base
                     ( the_employee_repository
                     , the_title_repository ) {}


        protected override IEnumerable<Title> get_entry_assigned_to_employee 
                                                ( IEnumerable<Employee> employees ) {

            return employees.Select( e => e.title) ;
        }
    }
}