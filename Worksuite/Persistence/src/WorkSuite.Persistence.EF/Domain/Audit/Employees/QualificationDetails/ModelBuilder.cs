using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.Audit.Employees.QualificationDetails
{
    public class ModelBuilder
                    : ModelConfiguration<EmployeeQualificationDetailsAuditRecord>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("EmployeeQualificationDetailsAuditRecord", schema));
        }
    }
}