using System.Collections.Generic;
using Content.Services.HR.Messages;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.New
{
    public class NewEmergencyContactValidator : INewEmergencyContactValidator
    {
        public NewEmergencyContactValidator(Validator the_validator)
        {
            validator = Guard.IsNotNull(the_validator, "the_validator");
        }

        public IEnumerable<ResponseMessage> validateEmergencyContact(NewEmergencyContactRequest request)
        {
            //Need to keep on adding fields here.
            validator.field("name")
                .is_madatory(request.name, ValidationMessages.error_01_0021)
                .does_not_exceed_the_maximum_number_of_characters_for_a_text_field( request.name, ValidationMessages.error_01_0001 )
                ;

            validator.field( "primary_phone_number" )
                .is_madatory( request.primary_phone_number, ValidationMessages.error_01_0022 )
                .does_not_contains_characters_that_are_invalid_in_a_phone_field( request.primary_phone_number, ValidationMessages.error_00_0010 )
                .does_not_exceed_the_maximum_number_of_characters_for_a_text_field( request.primary_phone_number, ValidationMessages.error_01_0001 )
                ;

            validator.field( "other_phone_number" )
                .does_not_contains_characters_that_are_invalid_in_a_phone_field( request.other_phone_number, ValidationMessages.error_00_0010 )
                .does_not_exceed_the_maximum_number_of_characters_for_a_text_field( request.other_phone_number, ValidationMessages.error_01_0001 )
                ;

            return validator.errors;
        }
        private readonly Validator validator;
    }
}