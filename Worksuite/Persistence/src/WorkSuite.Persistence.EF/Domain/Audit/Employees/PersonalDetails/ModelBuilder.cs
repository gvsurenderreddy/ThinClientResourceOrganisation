using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.Audit.Employees.PersonalDetails {

    public class ModelBuilder 
                    : ModelConfiguration<EmployeePersonalDetailsAuditRecord>{
         

        public ModelBuilder( string schema ) {

            Map(m => m.ToTable("EmployeePersonalDetailsAuditRecord", schema ));
        }

    }
}