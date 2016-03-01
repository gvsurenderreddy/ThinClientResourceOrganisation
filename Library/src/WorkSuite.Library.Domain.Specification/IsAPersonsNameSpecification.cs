using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WorkSuite.Library.Service.Specification.Infrastructure;

namespace WorkSuite.Library.Domain.Specification
{

    public abstract class IsAPersonsNameSpecification<TBS, F> : AFieldSpecification<TBS, F>
                                                    where TBS : ITestBootstrap, new()
    {

        [TestMethod]
        public void lowercase_is_valid()
        {
            verify_against(a_valid_persons_name.ToLower());
        }

        [TestMethod]
        public void uppercase_is_valid()
        {
            verify_against(a_valid_persons_name.ToUpper());
        }

        [TestMethod]
        public void a_numeric_character_are_valid()
        {
            verify_against(a_valid_persons_name + "1");
        }

        [TestMethod]
        public void a_space_is_valid()
        {
            verify_against(a_valid_persons_name + " ");
        }

        [TestMethod]
        public void an_ampersand_is_valid()
        {
            verify_against(a_valid_persons_name + "&");
        }

        [TestMethod]
        public void a_hyphen_is_valid()
        {
            verify_against(a_valid_persons_name + "-");
        }

        [TestMethod]
        public void a_single_quote_is_valid()
        {
            verify_against(a_valid_persons_name + "'");
        }

        [TestMethod]
        public void an_equals_sign_is_not_valid()
        {
            verify_for(a_valid_persons_name + "=");
        }

        private void verify_against(string value)
        {
            var fixture = DependencyResolver.resolve<F>();

            set_request_field(fixture, value);

            act(fixture);

            no_errors_identified(fixture);
        }

        private readonly Action<F> no_errors_identified;


        protected IsAPersonsNameSpecification(Action<F, string> set_request_field
                                            , Action<F> act
                                            , Action<F> error_was_identified
                                            , Action<F> no_errors_identified)
            : base(set_request_field, act, error_was_identified)
        {
            this.no_errors_identified = no_errors_identified;
        }

        private const string a_valid_persons_name = "David";
    }

}