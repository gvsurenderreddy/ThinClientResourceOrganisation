using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic {


    public abstract class UniqueTextFieldSpecification<P, Q, F>
                            : HRResponseCommandSpecification<P, Q, F>
                    where Q : Response
                    where F : IsAResponseCommandFixture<P,Q> {

        protected abstract void create_entity_with_value ( string value );
        protected abstract void set_request_value ( string value );

        [TestMethod]
        public void in_the_same_case () {

            create_entity_with_value( value );
            set_request_value( value );

            fixture.execute_command();

            fixture.response.has_errors.Should().BeTrue();
        }

        [TestMethod]
        public void in_a_different_case () {

            create_entity_with_value( value.ToUpper() );
            set_request_value( value.ToLower() );

            fixture.execute_command();

            fixture.response.has_errors.Should().BeTrue();
        }

        protected abstract string value { get; }
    }
}