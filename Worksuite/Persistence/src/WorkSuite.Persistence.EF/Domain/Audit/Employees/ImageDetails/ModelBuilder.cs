using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.Audit.Employees.ImageDetails
{
    public class ModelBuilder
                    : ModelConfiguration<EmployeeImageDetailsAuditRecord>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("EmployeeImageDetailsAuditRecord", schema));
        }
    }
}