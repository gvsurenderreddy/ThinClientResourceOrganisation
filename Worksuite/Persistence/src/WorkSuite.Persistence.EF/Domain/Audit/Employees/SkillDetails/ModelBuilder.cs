using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.Audit.Employees.SkillDetails
{
    public class ModelBuilder
                    : ModelConfiguration<EmployeeSkillDetailsAuditRecord>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("EmployeeSkillDetailsAuditRecord", schema));
        }
    }
}