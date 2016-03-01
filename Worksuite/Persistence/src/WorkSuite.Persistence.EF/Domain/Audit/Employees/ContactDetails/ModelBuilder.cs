using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.Audit.Employees.ContactDetails
{
    public class ModelBuilder
                    : ModelConfiguration<EmployeeContactDetailsAuditRecord>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("EmployeeContactDetailsAuditRecord", schema));
        }
    }
}