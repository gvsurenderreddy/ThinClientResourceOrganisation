using System;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WorkSuite.Library.Domain.Specification
{
    public class TextFieldDoesNotExceedDefaultMaximumNumberOfCharactersSpecification<TBS, F>
                : TextFieldDoesNotExceedCertainNumberOfCharactersSpecification<TBS, F>
    where TBS : ITestBootstrap, new()
    {
        protected TextFieldDoesNotExceedDefaultMaximumNumberOfCharactersSpecification(Action<F, string> set_request_field
                                                                                        , Action<F> act
                                                                                        , Action<F> error_was_identified)
            : base(ValidationConstraints.max_text_field_length
                    , set_request_field
                    , act
                    , error_was_identified)
        {
        }
    }
}
