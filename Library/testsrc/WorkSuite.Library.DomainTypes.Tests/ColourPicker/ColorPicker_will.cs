using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Colour.Validators;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.ColourPicker
{
    public class ColorPicker_will
    {
        [TestClass]
        public class validate_RGB_colour
                             :ColorSpecification
        {
            //done: RGB can not be greater than 255 .
           //done: RGB can not be less than 0.
            [TestMethod]
            public void RGB_colour_must_be_less_than_hundred_fifty_five()
            {

                var colour_request = fixture.create_valid_colour_request();
                colour_request.R = 256;
                colour_request.G = 256;
                colour_request.B = 256;


                fixture.validator.execute(colour_request)
                    .Match(
                        is_valid:
                            rgb_colour_in_correct_format => Assert.Fail("this is not the colour "),

                        is_not_valid:
                            errors =>
                            {
                                errors.Should().Contain(e => e is ColourValidationError.colourIsNotInTheCorrectFormat);
                            }
                    );
            }

            [TestMethod]
            public void RGB_colour_must_be_greater_than_0()
            {
                var colour_request = fixture.create_valid_colour_request();
                colour_request.R = -1;
                colour_request.G = -1;
                colour_request.B = -1;

                fixture.validator.execute(colour_request)
                    .Match(
                        is_valid:
                            rgb_colour_in_correct_format => Assert.Fail("this is not the rgb Colour"),

                        is_not_valid:
                            errors =>
                            {
                                errors.Should().Contain(e => e is ColourValidationError.colourIsNotInTheCorrectFormat);
                            }
                    );
            }
            [TestMethod]
            public void RGB_colour_must_be_valid()
            {
                var colour_request = fixture.create_valid_colour_request();
                colour_request.R = 123;
                colour_request.G = 120;
                colour_request.B = 300;

                fixture.validator.execute(colour_request)
                    .Match(
                        is_valid:
                            rgb_colour_in_correct_format => Assert.Fail("this is not the rgb Colour"),

                        is_not_valid:
                            errors =>
                            {
                                errors.Should().Contain(e => e is ColourValidationError.colourIsNotInTheCorrectFormat);
                            }
                    );
            }
        }
        public class ColorSpecification
        {
            public TimeFixture fixture { get; private set; }

            [TestInitialize]
            public void before_each_test()
            {
                fixture = new TimeFixture();
            }
        }

        public class TimeFixture
        {

            public RGBColourRequestValidation validator { get; private set; }

            public RGBColourRequest create_valid_colour_request()
            {
                return new RGBColourRequest() { R = 204 ,G = 203 ,B = 203 };
            }

            public TimeFixture()
            {
                validator = new RGBColourRequestValidation();
            }
        }

    }
}