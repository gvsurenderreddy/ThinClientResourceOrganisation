using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.SupplyShortage
{
    public class ModelBuilder : ModelConfigurationRegister
    {
        public ModelBuilder(string schema)
        {
            register(new Employees.ModelBuilder(schema));
        }
    }
}
