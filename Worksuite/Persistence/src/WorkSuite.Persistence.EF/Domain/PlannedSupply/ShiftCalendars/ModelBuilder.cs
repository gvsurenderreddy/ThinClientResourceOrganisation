using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.PlannedSupply.ShiftCalendars
{
    public class ModelBuilder
                        : ModelConfiguration<WorkSuite.PlannedSupply.ShiftCalendars.ShiftCalendar>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("ShiftCalendar", schema));

            // Set up cascading delete on Collection Navigation properties
            HasMany(m => m.ShiftCalendarPatterns)
                .WithRequired();
        }
    }
}