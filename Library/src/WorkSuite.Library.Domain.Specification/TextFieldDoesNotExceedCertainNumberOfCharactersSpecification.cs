using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;

namespace WorkSuite.Library.Domain.Specification
{
    public class TextFieldDoesNotExceedCertainNumberOfCharactersSpecification<TBS, F> : AFieldSpecification<TBS, F>
                                                        where TBS : ITestBootstrap, new()
    {

        [TestMethod]
        public void can_not_exceed_certain_number_of_characters()
        {

            verify_for(field_value_that_is_too_large);
        }


        protected TextFieldDoesNotExceedCertainNumberOfCharactersSpecification(int certain_number_of_characters
                                                                            , Action<F, string> set_request_field
                                                                            , Action<F> act
                                                                            , Action<F> error_was_identified)
            : base(set_request_field, act, error_was_identified)
        {
            field_value_that_is_too_large = new String('x', certain_number_of_characters + 1);
        }

        private readonly string field_value_that_is_too_large;
    }
}
