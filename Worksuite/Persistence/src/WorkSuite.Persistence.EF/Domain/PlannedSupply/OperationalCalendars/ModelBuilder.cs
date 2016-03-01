using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.PlannedSupply.OperationalCalendars
{
    public class ModelBuilder
                    : ModelConfiguration<WTS.WorkSuite.PlannedSupply.OperationsCalendars.OperationalCalendar>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("OperationalCalendar", schema));

            // Set up cascading delete on Collection Navigation properties
            HasMany(m => m.ShiftCalendars)
                .WithRequired();

            HasMany(m => m.TimeAllocations)
                .WithRequired();
        }
    }
}