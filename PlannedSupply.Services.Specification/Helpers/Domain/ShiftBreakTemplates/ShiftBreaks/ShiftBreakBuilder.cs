using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.Breaks;
using WTS.WorkSuite.PlannedSupply.ShiftCalendars;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates.Breaks
{
    /// <summary>
    ///     Builder for Breakk.
    /// </summary>
    public class BreakBuilder
                    : IEntityBuilder<Break>
    {
        public Break entity
        {
            get { return _break; }
        }

        /// <summary>
        ///     The specified value of 'starts_after'
        /// </summary>
        /// <param name="the_value"></param>
        /// <returns></returns>
        public BreakBuilder off_set_in_seconds(int the_value)
        {
            _break.offset_from_start_time_in_seconds = the_value;

            return this;
        }

        public BreakBuilder duration_in_seconds(int the_value)
        {
            _break.duration_in_seconds = the_value;

            return this;
        }

        public BreakBuilder is_paid(bool the_value)
        {
            _break.is_paid = the_value;

            return this;
        }

        public BreakBuilder()
        {
            var id = next_id();

            _break = new Break
            {
                id = id,
            };
        }

        /// <summary>
        ///     Initialises the instance of the _break.
        /// </summary>
        /// <param name="the_break"></param>
        public BreakBuilder(Break the_break)
        {
            Guard.IsNotNull(the_break, "the_break");

            _break = new Break
                                    {
                                        id = the_break.id,
                                        offset_from_start_time_in_seconds = the_break.offset_from_start_time_in_seconds,
                                        duration_in_seconds = the_break.duration_in_seconds
                                    };
        }

        private int next_id()
        {
            var identity_provider = new IntIdentityProvider<ShiftCalendar>();

            return identity_provider.next();
        }

        private readonly Break _break;
    }
}