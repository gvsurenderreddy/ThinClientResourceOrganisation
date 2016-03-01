using WTS.WorkSuite.Library.EntityFramework.Configuration;
using WTS.WorkSuite.SupplyShortage.Employees;

namespace WTS.WorkSuite.Persistence.EF.Domain.SupplyShortage.Employees
{
    public class ModelBuilder : ModelConfiguration<EmployeeSupplyShortage>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("EmployeeSupplyShortage", schema));
        }
    }
}
