using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.Primitives.Validation
{
    /// <summary>
    ///     Provides field verification methods
    /// 
    /// IMPROVE: WE NEED A WAY TO RETURN A MATCH WITH ALL THE ERRORS
    /// IT SHOULD IDEALLY BE USED AT THE END OF THE PIPELINE
    /// </summary>
    public class FieldVerifier
    {
        /// <inheritdoc/>
        public FieldVerifier
            (string the_field_name
            , ICollection<ResponseMessage> the_errors)
        {
            Guard.IsNotNull(the_errors, "the_errors");

            errors = the_errors;
            field_name = the_field_name;
        }

        /// <summary>
        ///     Checks that a mandatory field has been specified.
        /// </summary>
        /// <param name="field_value">
        ///     The field value that will be verified
        /// </param>
        /// <param name="error_message">error message</param>
        /// <returns>
        ///     The verifier as this is a fluent interface
        /// </returns>
        public FieldVerifier is_madatory
                                (string field_value
                                , string error_message)
        {
            var premise = StaticPremises.is_madatory(field_value);

            premise_holds
                (premise, error_message);
            return this;
        }

        /// <summary>
        ///     Checks that a field only contains alphabetic characters.
        /// </summary>
        /// <param name="field_value">
        ///     The field value that will be verified
        /// </param>
        /// <param name="error_message">error message</param>
        /// <returns>
        ///     The verifier as this is a fluent interface
        /// </returns>
        public FieldVerifier does_not_contain_non_alphabetic_characters
                                (string field_value
                                , string error_message)
        {
            var premise = StaticPremises.does_not_contain_non_alphabetic_characters(field_value);

            premise_holds
                (premise
                , error_message);

            return this;
        }

        /// <summary>
        ///     Checks that a field only contains numbers.
        /// </summary>
        /// <param name="field_value">
        ///     The field value that will be verified
        /// </param>
        /// <param name="error_message">error message</param>
        /// <returns>
        ///     The verifier as this is a fluent interface
        /// </returns>
        public FieldVerifier does_not_contain_non_numeric_characters
                                (string field_value
                                , string error_message)
        {
            var premise = StaticPremises.does_not_contain_non_numeric_characters(field_value);

            premise_holds
                (premise
                , error_message);

            return this;
        }

        /// <summary>
        ///     Checks that a field only contains that are valid in a persons name .
        /// </summary>
        /// <param name="field_value">
        ///     The field value that will be verified
        /// </param>
        /// <param name="error_message">error message</param>
        /// <returns>
        ///     The verifier as this is a fluent interface
        /// </returns>
        public FieldVerifier does_not_contains_characters_that_are_invalid_in_a_persons_name
                                (string field_value
                                , string error_message)
        {
            var premise = StaticPremises.does_not_contains_characters_that_are_invalid_in_a_persons_name(field_value);

            premise_holds
                (premise
                , error_message);

            return this;
        }

        /// <summary>
        ///     Checks that a field only contains that are valid in a field for phone.
        /// </summary>
        /// <param name="field_value">
        ///     The value to be verified.
        /// </param>
        /// <param name="error_message">
        ///     Error message.
        /// </param>
        /// <returns>
        ///     The verifier as this is a fluent interface
        /// </returns>
        public FieldVerifier does_not_contains_characters_that_are_invalid_in_a_phone_field
                                (string field_value
                                , string error_message)
        {
            var premise = StaticPremises.does_not_contains_characters_that_are_invalid_in_a_phone_field(field_value);

            premise_holds
                (premise
                , error_message);

            return this;
        }

        /// <summary>
        ///     Checks that a field only contains that are valid in a field for mobile.
        /// </summary>
        /// <param name="field_value">
        ///     The value to be verified.
        /// </param>
        /// <param name="error_message">
        ///     Error message.
        /// </param>
        /// <returns>
        ///     The verifier as this is a fluent interface
        /// </returns>
        public FieldVerifier does_not_contains_characters_that_are_invalid_in_a_mobile_field
                                (string field_value
                                , string error_message)
        {
            var premise = StaticPremises.does_not_contains_characters_that_are_invalid_in_a_mobile_field(field_value);

            premise_holds(premise, error_message);

            return this;
        }

        /// <summary>
        ///     Checks that a field only a number that is greater than 0
        /// </summary>
        /// <param name="field_value">
        ///     The field value that will be verified
        /// </param>
        /// <param name="error_message">error message</param>
        /// <returns>
        ///     The verifier as this is a fluent interface
        /// </returns>
        public FieldVerifier does_not_contain_less_than_one_for_a_number_field
                            (string field_value
                            , string error_message)
        {
            var premise = StaticPremises.does_not_contain_less_than_one_for_a_number_field(field_value);

            premise_holds(premise, error_message);

            return this;
        }

        /// <summary>
        ///  Checks that a field does not contain more than the maximum number of characters
        /// that are allowed in a text field.
        /// </summary>
        /// <param name="field_value">
        ///     The field value that will be verified
        /// </param>
        /// <param name="error_message">
        ///     error message
        /// </param>
        /// <returns>
        ///     The verifier as this is a fluent interface
        /// </returns>
        public FieldVerifier does_not_exceed_the_maximum_number_of_characters_for_a_text_field
                                (string field_value
                                , string error_message)
        {

            var premise = StaticPremises.does_not_exceed_the_maximum_number_of_characters_for_a_text_field(field_value);

            premise_holds(premise, error_message);

            return this;
        }

        /// <summary>
        ///  Checks that a field does not contain more than the maximum number of characters
        /// that are allowed in a email text field.
        /// </summary>
        /// <param name="field_value">The field value.</param>
        /// <param name="error_message">The error message.</param>
        /// <returns></returns>
        public FieldVerifier does_not_exceed_the_maximum_number_of_characters_for_email
                                (string field_value
                                , string error_message)
        {
            var premise = StaticPremises.does_not_exceed_the_maximum_number_of_characters_for_email(field_value);
                
            premise_holds(premise, error_message);

            return this;
        }

        /// <summary>
        /// Check if email field starts with @ sign.
        /// </summary>
        /// <param name="field_value">The field value.</param>
        /// <param name="error_message">The error message.</param>
        /// <returns></returns>
        public FieldVerifier does_not_start_or_end_with_at_sign_in_email
                                (string field_value
                                , string error_message)
        {
            var premise = StaticPremises.does_not_start_or_end_with_at_sign_in_email(field_value);

            premise_holds(premise, error_message);

            return this;
        }

        /// <summary>
        /// Check if email field starts with dot (.) character.
        /// </summary>
        /// <param name="field_value">The field value.</param>
        /// <param name="error_message">The error message.</param>
        /// <returns></returns>
        public FieldVerifier does_not_start_or_end_with_dot_in_email
                                (string field_value
                                , string error_message)
        {
            var premise = StaticPremises.does_not_start_or_end_with_dot_in_email(field_value);

            premise_holds(premise, error_message);

            return this;
        }

        /// <summary>
        /// Email requires at least one character, followed by @, followed by at least one character, followed by dot, then followed by at least one character, e.g., m@s.g
        /// </summary>
        /// <param name="field_value">The field value.</param>
        /// <param name="error_message">The error message.</param>///
        /// <returns></returns>
        public FieldVerifier email_requires_at_least_one_character_followed_by_at_sign_then_followed_by_at_least_one_character_then_followed_by_dot_then_followed_by_at_least_one_character
                                (string field_value
                                , string error_message)
        {
            var premise = StaticPremises.email_requires_at_least_one_character_followed_by_at_sign_then_followed_by_at_least_one_character_then_followed_by_dot_then_followed_by_at_least_one_character
                            (field_value);

            premise_holds(premise, error_message);

            return this;
        }

        /// <summary>
        ///     Checks that specified premise holds and records a validation error if
        /// it does not.
        /// </summary>
        /// <param name="premise">
        ///     The premise that is expected to be true
        /// </param>
        /// <param name="error_message">
        ///     The error message that is recorded if the premise is false
        /// </param>
        /// <returns>
        ///     The verifier as this is a fluent interface
        /// </returns>
        public FieldVerifier premise_holds(bool premise, string error_message)
        {
            if (!premise)
            {
                errors.Add(error_message.ToResponseMessage(field_name));
            }
            return this;
        }

        // used as the field name when recording validation error
        private readonly string field_name;

        // validation errors are added to this collection which is
        // passed in the constructor.S
        private readonly ICollection<ResponseMessage> errors;
    }

}