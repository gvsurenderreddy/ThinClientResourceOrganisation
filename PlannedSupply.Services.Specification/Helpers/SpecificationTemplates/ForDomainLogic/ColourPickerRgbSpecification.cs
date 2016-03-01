using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.ForDomainLogic
{

    public class ColourPickerRgbSpecification<P, Q, F> : PlannedSupplyResponseCommandSpecification<P, Q, F>
        where Q : Response
        where F : IsAResponseCommandFixture<P, Q>
    {

        protected ColourPickerRgbSpecification(Action<P, RGBColourRequest> set_field_by)
            : this(set_field_by, null)
        {
        }

        protected ColourPickerRgbSpecification(Action<P, RGBColourRequest> set_field_by,
            string the_expected_message)
        {

            set_field = set_field_by;
            expected_message = the_expected_message;
        }

        private Action<P, RGBColourRequest> set_field { get; set; }
        private string expected_message { get; set; }

        //rgb can not be less than zero 
        //rgb can not be greater than 255 

        [TestMethod]
        public void rgb_less_than_zero_should_report_error()
        {
            confirm_if_rgb_format_is_not_correct(new RGBColourRequest() { R = -1, G = -1, B = -1 });
        }

        [TestMethod]
        public void rgb_greater_than_tow_hundred_fifty_five_should_report_error()
        {
            confirm_if_rgb_format_is_not_correct(new RGBColourRequest() { R = 256, G = 256, B = 256 });
        }

        private void confirm_if_rgb_format_is_not_correct(RGBColourRequest value)
        {
            var the_value = value;
            set_field(fixture.request, the_value);
            fixture.execute_command();
            var response = fixture.response;
            response.has_errors.Should().BeTrue();
        }


    }
}