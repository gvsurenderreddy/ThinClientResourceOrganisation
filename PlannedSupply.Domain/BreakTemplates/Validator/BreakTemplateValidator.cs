using Content.Services.PlannedSupply.Messages;
using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Validator
{
    public class BreakTemplateValidator
    {
        public IEnumerable<ResponseMessage> validate_shift_break_template_name(string template_name,
                                                                               bool has_a_duplicate_shift_break_template_exist_with_this_name
                                                                              )
        {
            _validator
                .field("template_name")
                    .is_madatory(template_name, ValidationMessages.error_00_0062)
                    .does_not_exceed_the_maximum_number_of_characters_for_a_text_field(template_name, ValidationMessages.error_00_0051)
                    .premise_holds(!has_a_duplicate_shift_break_template_exist_with_this_name, ValidationMessages.error_00_0063)
                    ;

            return _validator.errors;
        }

        public BreakTemplateValidator(Library.DomainTypes.Primitives.Validation.Validator the_validator)
        {
            _validator = Guard.IsNotNull(the_validator, "the_validator");
        }

        private readonly Library.DomainTypes.Primitives.Validation.Validator _validator;
    }
}