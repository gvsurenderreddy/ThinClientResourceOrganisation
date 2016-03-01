using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic
{
    public class RgbColourWhiteDefualtValueSpecification<P, Q, F> : PlannedSupplyResponseCommandSpecification<P, Q, F>
        where Q : Response
        where F : IsAResponseCommandFixture<P, Q>
    {

        protected RgbColourWhiteDefualtValueSpecification(Action<P, RGBColourRequest> set_field_by)
            : this(set_field_by, null)
        {
        }

        protected RgbColourWhiteDefualtValueSpecification(Action<P, RGBColourRequest> set_field_by,
            string the_expected_message)
        {

            set_field = set_field_by;
            expected_message = the_expected_message;
        }

        private Action<P, RGBColourRequest> set_field { get; set; }
        private string expected_message { get; set; }


        // done : if colour component is not exist it should return white colour as default .
        // done : if all component of colour request is null ,it should return white colour as a default .
        // done : if colour request has value,should return the colour request value .
        [TestMethod]
        public void if_colour_componant_does_not_exist_should_return_white_colour_as_a_defualt()
        {
            confirm_default_colour_if_the_request_in_null(null);
        }

        [TestMethod]
        public void if_colour_request_is_null_it_should_return_white_colour_as_a_defualt()
        {
            confirm_default_colour_if_the_request_in_null(new RGBColourRequest() { R = null, G = null, B = null });
        }

        [TestMethod]
        public void if_colourr_request_has_white_colour_value_it_should_return_colour_request()
        {
            confirm_default_colour_if_the_request_in_null(new RGBColourRequest() { R = 205, G = 245, B = 230 });
        }

        private void confirm_default_colour_if_the_request_in_null(RGBColourRequest value)
        {
            var the_value = value;
            set_field(fixture.request, the_value);
            fixture.execute_command();
            var response = fixture.response;

            response.has_errors.Should().BeFalse();
        }
    }

}