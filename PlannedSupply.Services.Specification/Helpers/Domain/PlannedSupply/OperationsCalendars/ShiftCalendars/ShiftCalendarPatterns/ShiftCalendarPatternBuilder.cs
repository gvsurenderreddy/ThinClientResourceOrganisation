using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.ResourceAllocations;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.TimeAllocationOccurrences;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns
{
    /// <summary>
    ///     Builder for shift calendar pattern.
    /// </summary>
    public class ShiftCalendarPatternBuilder
                        : IEntityBuilder<ShiftCalendarPattern>
    {
        public ShiftCalendarPattern entity
        {
            get { return _shift_calendar_pattern; }
        }

        /// <summary>
        ///     Pattern name, the specified value.
        /// </summary>
        /// <param name="the_value">
        ///     pattern name value
        /// </param>
        /// <returns>
        ///     Builder itself so that we can use the fluent interface to build a shift calendar pattern.
        /// </returns>
        public ShiftCalendarPatternBuilder pattern_name(string the_value)
        {
            _shift_calendar_pattern.name = the_value;

            return this;
        }

        /// <summary>
        ///     Number of resources, the specified value.
        /// </summary>
        /// <param name="the_value">
        ///     number of resources value
        /// </param>
        /// <returns>
        ///     Builder itself so that we can use the fluent interface to build a shift calendar pattern.
        /// </returns>
        public ShiftCalendarPatternBuilder number_of_resources(int the_value)
        {
            _shift_calendar_pattern.number_of_resources = the_value;

            return this;
        }

        /// <summary>
        ///     Priority, the specified value.
        /// </summary>
        /// <param name="the_value">
        ///     priority value
        /// </param>
        /// <returns>
        ///     Builder itself so that we can use the fluent interface to build a shift calendar pattern.
        /// </returns>
        public ShiftCalendarPatternBuilder priority(int value)
        {
            _shift_calendar_pattern.priority = value;
            return this;
        }

        public ShiftCalendarPatternBuilder add_occurrence(TimeAllocationOccurrence the_value)
        {
            _shift_calendar_pattern.TimeAllocationOccurrences.Add(the_value);

            return this;
        }

        public ShiftCalendarPatternBuilder add_resouce_allocation(ResourceAllocation the_value)
        {
            _shift_calendar_pattern.ResourceAllocations.Add(the_value);

            return this;
        }

        public ShiftCalendarPatternBuilder()
        {
            var id = next_id();

            _shift_calendar_pattern = new ShiftCalendarPattern
            {
                id = id,
                priority = 1
            };
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ShiftCalendarPatternBuilder"/> class.
        /// </summary>
        /// <param name="the_shift_calendar_pattern">
        ///     shift calendar pattern
        /// </param>
        public ShiftCalendarPatternBuilder(ShiftCalendarPattern the_shift_calendar_pattern)
        {
            Guard.IsNotNull(the_shift_calendar_pattern, "the_shift_calendar_pattern");

            _shift_calendar_pattern = new ShiftCalendarPattern
                                                {
                                                    id = the_shift_calendar_pattern.id,
                                                    name = the_shift_calendar_pattern.name,
                                                    number_of_resources = the_shift_calendar_pattern.number_of_resources
                                                };
          
        }

        private int next_id()
        {
            var identity_provider = new IntIdentityProvider<ShiftCalendarPattern>();

            return identity_provider.next();
        }

        private readonly ShiftCalendarPattern _shift_calendar_pattern;
    }
}