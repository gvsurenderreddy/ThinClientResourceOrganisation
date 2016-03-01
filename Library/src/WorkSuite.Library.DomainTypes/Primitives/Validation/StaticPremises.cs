using System.Linq;
using System.Text.RegularExpressions;

namespace WTS.WorkSuite.Library.DomainTypes.Primitives.Validation
{

    public class StaticPremises
    {

        public static bool is_madatory
                                (string field_value)
        {
            return
                (!string.IsNullOrWhiteSpace(field_value));
        }

        public static bool does_not_contain_non_alphabetic_characters
                                (string field_value)
        {
            return
                (field_value == null || field_value.All(char.IsLetter));
        }

        public static bool does_not_contain_non_numeric_characters
                                (string field_value)
        {
            return
                (field_value == null || field_value.All(char.IsNumber));
        }

        public static bool does_not_contains_characters_that_are_invalid_in_a_persons_name
                                (string field_value)
        {
            const string lowercase_alphabet = "abcdefghijklmnopqrstuvwxyz";
            const string uppercase_alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numerals = "0123456789";
            const string non_alphanumeric_characters = "'& -";

            const string allowable_characters = lowercase_alphabet
                                     + uppercase_alphabet
                                     + numerals
                                     + non_alphanumeric_characters
                                     ;

            return
                (field_value == null || field_value.All(allowable_characters.Contains));
        }

        public static bool does_not_contains_characters_that_are_invalid_in_a_phone_field(string field_value)
        {
            const string empty_space = " ";
            const string numerals = "0123456789";
            const string non_alphanumeric_characters_for_phone = "+()";

            const string allowable_characters = empty_space
                                       + numerals
                                       + non_alphanumeric_characters_for_phone;

            return
                (field_value == null || field_value.All(allowable_characters.Contains));
        }

        public static bool does_not_contains_characters_that_are_invalid_in_a_mobile_field(string field_value)
        {
            const string empty_space = " ";
            const string numerals = "0123456789";
            const string non_alphanumeric_characters_for_phone = "+()";

            const string allowable_characters = empty_space
                                       + numerals
                                       + non_alphanumeric_characters_for_phone;

            return
                (field_value == null || field_value.All(allowable_characters.Contains));
        }

        public static bool does_not_contain_less_than_one_for_a_number_field(string field_value)
        {
            int number;
            int.TryParse(field_value, out number);

            return (field_value == null || number > 0);
        }

        public static bool does_not_exceed_the_maximum_number_of_characters_for_a_text_field(string field_value)
        {
            return
                (field_value == null || field_value.Length <= ValidationConstraints.max_text_field_length);

        }

        public static bool does_not_exceed_the_maximum_number_of_characters_for_email(string field_value)
        {
            return (field_value == null || field_value.Length <= ValidationConstraints.max_text_field_length_for_email);
        }

        public static bool does_not_start_or_end_with_at_sign_in_email(string field_value)
        {
            // pattern for not allowing @ sign at start or end of string
            const string pattern = "^[^@].+[^@]$";

            var regex = new Regex(pattern);
            var str = field_value != null ? field_value.Trim() : null;

            return (field_value == null || field_value.Trim().Length == 0 || regex.IsMatch(str));
        }

        public static bool does_not_start_or_end_with_dot_in_email(string field_value)
        {
            // pattern for not allowing dot (.) char at start or end of string
            const string pattern = "^[^.].+[^.]$";

            var regex = new Regex(pattern);

            var str = field_value != null ? field_value.Trim() : null;

            return (field_value == null || field_value.Trim().Length == 0 || regex.IsMatch(str));
        }


        public static bool email_requires_at_least_one_character_followed_by_at_sign_then_followed_by_at_least_one_character_then_followed_by_dot_then_followed_by_at_least_one_character
                                (string field_value)
        {
            // rule: Email requires at least one character, followed by @, followed by at least one character,
            //          followed by dot, then followed by at least one character, e.g., m@s.g

            const string string_start = @"^";
            const string string_end = @"$";

            const string dot = "[.]";
            const string at_sign = "[@]";
            const string at_least_one_char = @".+";

            const string pattern_all = string_start + at_least_one_char + at_sign + at_least_one_char + dot + at_least_one_char + string_end;

            var regex = new Regex(pattern_all);

            var str = field_value != null ? field_value.Trim() : null;

            return (field_value == null || field_value.Trim().Length == 0 || regex.IsMatch(str));
        }
    }

}
