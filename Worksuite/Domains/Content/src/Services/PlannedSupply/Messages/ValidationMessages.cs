using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace Content.Services.PlannedSupply.Messages
{
    public class ValidationMessages
    {
        public static readonly string error_00_0037 = string.Format("Please use no more than {0} characters.", ValidationConstraints.max_text_field_length);

        /// <summary>
        ///     Field level validation Messages for Opreation calender.
        /// </summary>
        public const string error_00_0035 = "Please enter a calendar name.";

        public const string error_00_0036 = "An operation calendar with this name already exists. Please enter a different name.";

        /// <summary>
        ///     Field level validation Messages for shift calender.
        /// </summary>
        public const string error_00_0039 = "Please enter a calendar name.";

        public const string error_00_0040 = "A shift calendar with this name already exists. Please enter a different name.";

        /// <summary>
        ///     Field level validation Messages for shift calender pattern.
        /// </summary>
        public const string error_00_0042 = "Please enter a shift calendar pattern name.";

        public const string error_00_0043 = "A shift calendar pattern with this name already exists. Please enter a different name.";
        public const string error_00_0059 = "Please enter a number of resources.";
        public const string error_00_0060 = "Please choose 1 or more resources.";
        public const string error_00_0061 = "Please only use the numbers 0-9.";

        /// <summary>
        ///     Field level validation Messages for Shift Template.
        /// </summary>
        public const string error_00_0049 = "Please enter a shift template name.";

        public const string error_00_0050 = "A shift template with this name already exists. Please enter a different name.";
        public static readonly string error_00_0051 = string.Format("Please use no more than {0} characters.", ValidationConstraints.max_text_field_length);

        public const string error_00_0053 = "Please enter a start time. The hour and minute boxes are both required.";
        public static readonly string error_00_0054 = string.Format("Please only use the numbers {0}.", ValidationConstraints.range_of_character);
        public static readonly string error_00_0055 = string.Format("Please enter a time no later than {0}.", ValidationConstraints.end_time);

        public const string error_00_0056 = "Please enter a duration. The hours and the minutes boxes are both required.";
        public static readonly string error_00_0057 = string.Format("Please only use the numbers {0}. Both hours and minutes must be 0 or greater and minutes must not be greater than 59.", ValidationConstraints.range_of_character);
        public static readonly string error_00_0058 = string.Format("Please enter a time greater than {0} minute and no longer than {1} hours.", ValidationConstraints.minimum_duration, ValidationConstraints.maximum_24_hours);

        public const string error_00_0082 = "This break template cannot be used because it contains breaks beyond the shifts end time.";

        /// <summary>
        ///     Field level validation messages for Break Template.
        /// </summary>
        public const string error_00_0062 = "Please enter a break template name.";

        public const string error_00_0063 =
            "A break template with this name already exists. Please enter a different name.";

        /// <summary>
        ///     Field level validation message for Break.
        /// </summary>
        public const string error_00_0064 = "Please enter a time the break starts after. The hours and the minutes boxes are both required.";

        public static readonly string error_00_0065 = string.Format("Please only use the numbers {0}. Both hours and minutes must be 0 or greater and minutes must not be greater than 59.", ValidationConstraints.range_of_character);
        public static readonly string error_00_0066 = string.Format("Please enter a time no longer than {0} hours.", ValidationConstraints.maximum_24_hours);
        public const string error_00_0069 = "Please enter a duration for the break. The hours and the minutes boxes are both required.";
        public static readonly string error_00_0070 = string.Format("Please only use the numbers {0}. Both hours and minutes must be 0 or greater and minutes must not be greater than 59.", ValidationConstraints.range_of_character);
        public static readonly string error_00_0071 = string.Format("Please enter a time greater than {0} minute and no longer than {1} hours.", ValidationConstraints.minimum_duration, ValidationConstraints.maximum_24_hours);

        public const string error_00_0068 = "A break already starts at this point in time. Please enter a different time.";

        /// <summary>
        ///  Field level validation messages for Shift.
        /// </summary>
        public const string error_00_0072 = "Please enter a shift name.";


        /// <summary>
        /// clashing break validation
        /// </summary>
        /// 
        public const string error_00_0086 = "The end of this break overlaps another break.Please enter another duration.";
        public const string error_00_0085=  "The start of this break overlaps another break.Please enter another start after.";
        public const string error_00_0089=  "The start of this break envelops another break.Please enter another start after.";
        public const string error_00_0090=  "The end of this break envelops another break.Please enter another duration.";
        public const string error_00_0092 = "The start of this break envelops other breaks.Please enter another start after.";
        public const string error_00_0093 = "The end of this break envelops other breaks.Please enter another duration.";

        /// <summary>
        /// clashing shift validation
        /// </summary>
        /// 
        public const string error_00_0009 = "The shift clashes with another shift.Please enter another time period.";


        /// <summary>
        /// publish shift calendar sanitisation field level error message.
        /// </summary>
        /// 
        public static readonly string error_210220151519 = string.Format("Please enter a valid date using the numeric characters {0} or the first three letters of a month.", ValidationConstraints.range_of_character);

        /// <summary>
        /// publish shift calendar validation field level error message.
        /// </summary>
        /// 
        public const string error_240220151249 = "Please enter a valid date range. Start dates must be on or after the end date.";
    }
}