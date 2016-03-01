using WTS.WorkSuite.Library.EntityFramework.Configuration;
using WTS.WorkSuite.ThinClient.Query.HR.employee.Sickness;

namespace WTS.WorkSuite.Persistence.EF.Domain.ThinClient.Query.SicknessListViews
{
    public class ModelBuilder : ModelConfiguration<SicknessListView>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("SicknessListView", schema));

            Property(u => u.sickness_date).HasColumnType("datetime2");
        }
    }
}
