using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.Audit.Employees.EmploymentDetails {

    public class ModelBuilder 
                    : ModelConfiguration<EmployeeEmploymentDetailsAuditRecord>{
         

        public ModelBuilder( string schema ) {

            Map(m => m.ToTable("EmployeeEmploymentDetailsAuditRecord", schema ));
        }

    }
}