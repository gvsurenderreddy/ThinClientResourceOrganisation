using WTS.WorkSuite.Library.EntityFramework.Configuration;
using WTS.WorkSuite.ThinClient.Query.HR.employee.Holidays;

namespace WTS.WorkSuite.Persistence.EF.Domain.ThinClient.Query.HolidayListViews
{
    public class ModelBuilder
                    : ModelConfiguration<HolidayListView>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("HolidayListView", schema));

            Property(u => u.holiday_date).HasColumnType("datetime2");
        }
    }
}
