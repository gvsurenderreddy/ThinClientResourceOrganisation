using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.PlannedSupply.ShiftTemplate
{
    public class ModelBuilder
                     : ModelConfiguration < WorkSuite.PlannedSupply.ShiftTemplates.ShiftTemplate >
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("ShiftTemplate", schema));

        }
    }
}