using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic
{
    public class MandatoryDateFieldSpecification<P, Q, F>
                                   : PlannedSupplyResponseCommandSpecification<P, Q, F>
                           where Q : Response
                           where F : IsAResponseCommandFixture<P, Q>
    {
        [TestMethod]
        public void can_not_be_null()
        {

            verify_for(new DateRequest
            {
              year = null,
              month = null,
              day = null
            });
        }

        [TestMethod]
        public void can_not_be_an_empty_string()
        {

            verify_for(new DateRequest
            {
               year = string.Empty,
               month = string.Empty,
               day = string.Empty
            });

        }

        [TestMethod]
        public void can_not_be_just_white_space()
        {

            verify_for(new DateRequest
            {
                year = "\t",
                month = "\t",
                day = "\t"
            });

        }

        [TestMethod]
        public void can_not_be_just_white_space_and_null()
        {

            verify_for(new DateRequest
            {
                year = "\t",
                month = null,
                day = "\t"
            });

        }

        [TestMethod]
        public void can_not_be_just_white_space_and_empty()
        {

            verify_for(new DateRequest
            {
                year = "\t",
                month = string.Empty,
                day = "\t"
            });

        }

        [TestMethod]
        public void can_not_be_just_white_space_empty_and_null()
        {

            verify_for(new DateRequest
            {
                year = null,
                month = string.Empty,
                day = "\t"
            });

        }

        protected MandatoryDateFieldSpecification
            (Action<P, DateRequest> set_field_by)
            : this(set_field_by, null) { }


        protected MandatoryDateFieldSpecification
            (Action<P, DateRequest> set_field_by
                , string the_expected_message)
        {

            set_field = set_field_by;
          
        }

        private void verify_for
            (DateRequest value)
        {

            set_field(fixture.request, value);

            fixture.execute_command();

            assert_response_has_errors(fixture.response);
        }

        private void assert_response_has_errors
            (Q response)
        {

            response.has_errors.Should().BeTrue();
        }


        private Action<P, DateRequest> set_field { get; set; }
    }
}