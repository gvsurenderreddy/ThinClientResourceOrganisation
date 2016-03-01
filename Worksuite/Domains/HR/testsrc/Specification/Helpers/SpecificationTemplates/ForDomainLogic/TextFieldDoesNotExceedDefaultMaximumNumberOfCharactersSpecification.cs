using System;
using Content.Services.HR.Messages;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic {

    public abstract class TextFieldDoesNotExceedDefaultMaximumNumberOfCharactersSpecification<P, Q, F> 
                            : TextFieldDoesNotExceedMaximumNumberOfCharactersSpecification<P, Q, F>                
                    where Q : Response
                    where F : IsAResponseCommandFixture<P, Q> {

        protected TextFieldDoesNotExceedDefaultMaximumNumberOfCharactersSpecification
            (Action<P, string> set_field_by)
            : base(set_field_by, ValidationConstraints.max_text_field_length, ValidationMessages.error_01_0001) { }

    }
}