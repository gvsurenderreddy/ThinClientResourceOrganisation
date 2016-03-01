using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;

namespace WorkSuite.Library.Domain.Specification
{

    public abstract class MandatoryTextFieldSpecification<TBS, F> : AFieldSpecification<TBS, F>
                                                        where TBS : ITestBootstrap, new()
    {

        [TestMethod]
        public void can_not_be_null()
        {

            verify_for(null);
        }

        [TestMethod]
        public void can_not_be_an_empty_string()
        {

            verify_for(string.Empty);
        }

        [TestMethod]
        public void can_not_be_just_white_space()
        {

            verify_for("\r\n\t");
        }


        protected MandatoryTextFieldSpecification(Action<F, string> set_request_field
                                                , Action<F> act
                                                , Action<F> error_was_identified)
            : base(set_request_field, act, error_was_identified)
        {
        }
    }

}