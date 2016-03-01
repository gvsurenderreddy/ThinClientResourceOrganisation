using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.Audit.Employees.EmergencyContactDetails
{
    public class ModelBuilder
                    : ModelConfiguration<EmergencyContactDetailsAuditRecord>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("EmergencyContactDetailsAuditRecord", schema));
        }
    }
}