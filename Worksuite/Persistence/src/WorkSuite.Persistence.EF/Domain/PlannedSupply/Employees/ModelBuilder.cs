using WTS.WorkSuite.Library.EntityFramework.Configuration;


namespace WTS.WorkSuite.Persistence.EF.Domain.PlannedSupply.Employees
{
    public class ModelBuilder : ModelConfiguration<WTS.WorkSuite.PlannedSupply.HR.Employee.EmployeePlannedSupply>
    {

        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("EmployeePlannedSupply", schema));
        }

    }
}
