using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace Content.Services.PlannedSupply.Messages
{
    public class HelperMessage
    {
        /// <summary>
        /// Helper message for Shift template.
        /// </summary>
        ///
        /// Please enter the time the shift starts in a 24 hour clock format placing hours in the first box and minutes in the second box. The start time must be between 0:00 and 24:00.

        public static readonly string help_02_0019 =
            string.Format(
                "Please enter the time the shift starts in a {0} hour clock format placing hours in the first box and minutes in the second box. The start time must be between {1} and {2}.", ValidationConstraints.maximum_24_hours,
                ValidationConstraints.start_time, ValidationConstraints.end_time);

        public static readonly string help_02_0020 = string.Format("Please enter the length of the shift in hours and minutes. Shifts cannot exceed {0} hours.", ValidationConstraints.maximum_24_hours);

        public static readonly string help_02_0025 =
            "Break templates can be added, edited or removed from the 'Add new break template' option on the home page.";

        /// <summary>
        ///     Help messages for Break.
        /// </summary>
        public static readonly string help_02_0021 =
            "Please enter the time the break starts in a 24 hour clock format placing hours in the first box and minutes in the second box. The start time must be between 00:00 and 24:00.";

        public static readonly string help_02_0022 =
            "Please enter the length of the break in hours and minutes. Shifts breaks must be greater then 1 minute and cannot exceed 24 hours.";

        /// <summary>
        ///     Help messages for Break into the PlannedSupply
        /// </summary>
        public static readonly string help_22_0027 =
           "Please enter a starts after time for the shift break. Minutes must be 0 or greater and less than 60. Hours must be 0 or greater. Only the numeric characters 0 - 9 are accepted.";
        public static readonly string help_22_0028 =
          "Please enter a duration for the shift break. The duration must be greater than 0. Minutes must be 0 or greater and less than 60 minutes. Hours must be 0 or greater. Only the numeric characters 0 - 9 are accepted.";

        /// <summary>
        ///   Help message for Publish.
        /// </summary>
        public static readonly string help_030220151159 =
            string.Format("Please enter a valid calendar date using the numeric characters {0}. A single day may be published by entering the start and end dates.",ValidationConstraints.range_of_character);
    }
}