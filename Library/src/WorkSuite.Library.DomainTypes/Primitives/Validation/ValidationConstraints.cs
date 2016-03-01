namespace WTS.WorkSuite.Library.DomainTypes.Primitives.Validation
{
    public class ValidationConstraints
    {
        public const int max_text_field_length = 100;
        public const string range_of_character = "0-9";
        public const string start_time = "0:00";
        public const string end_time = "24:00";
        public const string minimum_off_set = "0";
        public const string minimum_duration = "1";
        public const string date_format = "(Day/Month/Year)";
        public const int maximum_24_hours = 24;
        public const int max_text_field_length_for_post_code = 8;
        public const int max_text_field_length_for_email = 254;
    }
}