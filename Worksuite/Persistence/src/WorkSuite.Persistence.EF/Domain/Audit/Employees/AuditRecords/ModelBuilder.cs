using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.Audit.Employees.AuditRecords {

    public class ModelBuilder 
                    : ModelConfiguration<EmployeeAuditRecord>{
         

        public ModelBuilder( string schema ) {

            Map(m => m.ToTable("EmployeeAuditRecord", schema ));
        }

    }
}