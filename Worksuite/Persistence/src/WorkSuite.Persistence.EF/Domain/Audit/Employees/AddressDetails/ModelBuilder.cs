using WTS.WorkSuite.Audit.HR.Employees;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.Audit.Employees.AddressDetails
{
    public class ModelBuilder
                    : ModelConfiguration<EmployeeAddressDetailsAuditRecord>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("EmployeeAddressDetailsAuditRecord", schema));
        }
    }
}