using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.PlannedSupply
{
    public class ModelBuilder
                        : ModelConfigurationRegister
    {
        public ModelBuilder(string schema)
        {
            register(new OperationalCalendars.ModelBuilder(schema));
            register(new ShiftCalendars.ModelBuilder(schema));
            register(new ShiftCalendarPatterns.ModelBuilder(schema));
            register(new ShiftTemplate.ModelBuilder(schema));
            register(new ShiftBreakTemplates.ModelBuilder(schema));
            register(new Breaks.ModelBuilder(schema));
            register(new TimeAllocations.ModelBuilder(schema));
            register(new TimeAllocationOccurrences.ModelBuilder(schema));
            register(new TimeAllocationBreaks.ModelBuilder(schema));
            register(new Employees.ModelBuilder(schema));
            register(new ResourceAllocation.ModelBuilder(schema));
        }
    }
}