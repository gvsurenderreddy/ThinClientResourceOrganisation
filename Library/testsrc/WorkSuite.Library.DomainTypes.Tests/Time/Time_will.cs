using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.Library.DomainTypes.Time.Validators;
using WTS.WorkSuite.Library.DomainTypes.Time.Validators.IsWithInATwentyFourHourDay;


namespace WTS.WorkSuite.Library.DomainTypes.Tests.Time
{
    public class Time_will
    {
        public class time_must_be_fully_specified
        {
            [TestClass]
            public class hours_must_be_specified
                              : TimeSpecification
            {
                // done: hour can not  be empty .
                // done: hour can not be null.
                // done: hour can not be white space.
                [TestMethod]
                public void hour_can_not_be_empty()
                {
                    confirm_is_not_an_acceptable_hours_value(string.Empty);
                }

                [TestMethod]
                public void hour_can_not_be_null()
                {
                    confirm_is_not_an_acceptable_hours_value(null);
                }

                [TestMethod]
                public void hour_can_not_be_white_space()
                {
                    confirm_is_not_an_acceptable_hours_value("\t");
                }
                private void confirm_is_not_an_acceptable_hours_value
                                                          (string value)
                {
                    var time_request = fixture.create_valid_time_request();
                    time_request.hours = value;

                    fixture.validator.execute(time_request)
                        .Match(
                            is_valid:
                                time_in_second => Assert.Fail("Invalid time was identified as valid "),

                            is_not_valid:
                                errors =>
                                {
                                    errors.Should().Contain(e => e is TimeValidationError.Time_HoursIsNotspecified &&
                                                                 (e as TimeValidationError.Time_HoursIsNotspecified).field_name == "hours");
                                }
                        );
                }
            }

            [TestClass]
            public class minute_must_be_specified
                              : TimeSpecification
            {
                // done: minutes can not  be empty .
                // done: minutes can not be null.
                // done: minutes can not be white space.
                [TestMethod]
                public void minutes_can_not_be_empty()
                {
                    confirm_is_not_an_acceptable_minutes_value(string.Empty);
                }

                [TestMethod]
                public void minutes_can_not_be_null()
                {
                    confirm_is_not_an_acceptable_minutes_value(null);
                }

                [TestMethod]
                public void minutes_can_not_be_white_space()
                {
                    confirm_is_not_an_acceptable_minutes_value("\t");
                }
                private void confirm_is_not_an_acceptable_minutes_value(string minute)
                {
                    var time_request = fixture.create_valid_time_request();
                    time_request.minutes = minute;
                    fixture.validator.execute(time_request)
                        .Match(
                            is_valid:
                                time_in_second => Assert.Fail("Invalid time was identified as valid"),

                            is_not_valid:
                                errors =>
                                {
                                    errors.Should().Contain(e => e is TimeValidationError.Time_MinutesIsNotspecified &&
                                                                 (e as TimeValidationError.Time_MinutesIsNotspecified).field_name ==
                                                                 "minutes");
                                }
                        );
                }
            }
            [TestClass]
            public class hour_and_minute_should_be_valid
                              : TimeSpecification
            {
                [TestMethod]
                public void if_hours_and_minutes_are_not_valid_it_should_report_errors()
                {
                    var time_request = fixture.create_valid_time_request();
                    time_request.hours = "";
                    time_request.minutes = "";

                    fixture.validator.execute(time_request)
                        .Match(
                            is_valid:
                                time_in_second => Assert.Fail("hour and minute is not valid"),

                            is_not_valid:
                                errors =>
                                {
                                    errors.Should().Contain(e => e is TimeValidationError.Time_HoursIsNotspecified &&
                                                                 (e as TimeValidationError.Time_HoursIsNotspecified).field_name ==
                                                                 "hours");
                                    errors.Should().Contain(e => e is TimeValidationError.Time_MinutesIsNotspecified &&
                                                                 (e as TimeValidationError.Time_MinutesIsNotspecified).field_name ==
                                                                 "minutes");
                                }
                        );
                }
            }
        }

        public class time_componant_must_be_valid
        {
            [TestClass]
            public class minute_must_be_valid
                                : TimeSpecification
            {
                //-1 reports error .
                //60 reports error .
                //text report error.
                [TestMethod]
                public void minutes_less_than_zero_should_return_zero()
                {
                    confirm_is_not_acceptable_minutes_value("-1");
                }

                [TestMethod]
                public void minutes_greater_than_sixty_should_return_error()
                {
                    confirm_is_not_acceptable_minutes_value("60");
                }

                [TestMethod]
                public void minute_text_should_return_error()
                {
                    confirm_is_not_acceptable_minutes_value("test");
                }

                private void confirm_is_not_acceptable_minutes_value
                                                          (string minutes)
                {
                    var time_request = fixture.create_valid_time_request();
                    time_request.minutes = minutes;

                    fixture.validator.execute(time_request)
                        .Match(
                            is_valid:
                                time_in_second => Assert.Fail("minutes is not valid"),

                            is_not_valid:
                                errors =>
                                {
                                    errors.Should().Contain(e => e is TimeValidationError.Time_MinutesIsNotANumber &&
                                                                 (e as TimeValidationError.Time_MinutesIsNotANumber).field_name == "minutes");
                                }

                        );
                }
            }

            [TestClass]
            public class hour_must_be_valid
                                : TimeSpecification
            {
                // less than 0 should show error.
               // greater than 24 should show error.
               // text should show error .

                [TestMethod]
                public void hour_less_than_zero_should_return_error()
                {
                    confirm_is_not_acceptable_hour("-1");
                }

                [TestMethod]
                public void hour_greater_than_twentyFour_should_return_error()
                {
                    confirm_is_not_acceptable_hour("25");
                }

                [TestMethod]
                public void if_hour_is_text_should_return_error()
                {
                    confirm_is_not_acceptable_hour("test");
                }

                private void confirm_is_not_acceptable_hour
                                                 ( string hours)
                {
                    var time_request = fixture.create_valid_time_request();
                    time_request.hours = hours;

                    fixture.validator.execute(time_request)
                        .Match(
                            is_valid:
                                time_in_second => Assert.Fail("Time is not valid"), 

                            is_not_valid:
                                errors =>
                                {
                                    errors.Should().Contain(e => e is TimeValidationError.Time_HoursIsNotANumber &&
                                                                 (e as TimeValidationError.Time_HoursIsNotANumber).field_name == "hours");
                                }
                        );
                }
            }

            [TestClass]
            public class hour_and_minute_should_be_valid
                                : TimeSpecification
            {
                [TestMethod]
                public void if_hour_and_minute_should_not_valid_it_should_report_error()
                {
                    var time_request = fixture.create_valid_time_request();
                    time_request.hours = "-1";
                    time_request.minutes = "-1";

                    fixture.validator.execute(time_request)
                        .Match(
                            is_valid:
                                time_in_second => Assert.Fail("hour and minute is not valid"),
                            is_not_valid:
                                errors => {
                                    errors.Should().Contain(e => e is TimeValidationError.Time_HoursIsNotANumber &&
                                                                      (e as TimeValidationError.Time_HoursIsNotANumber).field_name == "hours");
                                    errors.Should().Contain(e => e is TimeValidationError.Time_MinutesIsNotANumber &&
                                                                      (e as TimeValidationError.Time_MinutesIsNotANumber).field_name == "minutes");
                                }
                        );
                }
            }
        }

        public class time_must_be_between_zero_and_twentyfour_hours
        {
            [TestClass]
            public class time_in_twenty_four_hour
                               : TimeSpecification
            {
                [TestMethod]
                public void one_minute_more_than_24_hour_should_show_error()
                {
                    var time_request = fixture.create_valid_time_request();
                    time_request.hours = "24";
                    time_request.minutes = "1";

                    fixture.validator.execute(time_request)
                        .Match(
                            is_valid:
                                tim_in_second => Assert.Fail("Time is not valid"),

                            is_not_valid:
                                errors =>
                                {
                                    errors.Should()
                                        .Contain(e => e is TimeValidationError.TimeIsMoreThanTwentyFourHoursError);
                                }
                        );
                }
            }
        }

        [TestClass]
        public class valid_time_request_return_the_time_in_seconds
                                       : TimeSpecification
        {
              // done: one hour zero minutes return as a number of second (3600) .
              // done: zero hour 1 minute should return (60),
              // done: one hour and one minute should return (3660)

            [TestMethod]
            public void one_hour_zero_minute_should_return_three_thousand_six_hundred()
            {
                 var time_request = fixture.create_valid_time_request();
                time_request.hours = "1";
                time_request.minutes = "0";

                fixture.validator.execute(time_request)
                    .Match(
                       is_valid:
                           time_in_second => { time_in_second.Should().Be(3600); },

                       is_not_valid:
                            errors => Assert.Fail("Invalid case selected")
                          
                    );
            }

            [TestMethod]
            public void zero_hour_and_one_minute_should_return_sixty_second()
            {
                 var time_request = fixture.create_valid_time_request();
                time_request.hours = "0";
                time_request.minutes = "1";

                fixture.validator.execute(time_request)
                    .Match(
                       is_valid:
                           time_in_second => { time_in_second.Should().Be(60); },

                       is_not_valid:
                            errors => Assert.Fail("Invalid case selected")
                          
                    );
            }
            [TestMethod]
            public void one_hour_and_one_minute_should_return_sixty_second()
            {
                 var time_request = fixture.create_valid_time_request();
                time_request.hours = "1";
                time_request.minutes = "1";

                fixture.validator.execute(time_request)
                    .Match(
                       is_valid:
                           time_in_second => { time_in_second.Should().Be(3660); },

                       is_not_valid:
                            errors => Assert.Fail("Invalid case selected")
                          
                    );
            }
        }

           public class TimeSpecification
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

            public TimeIsWithinATwentyFourHourDay validator { get; private set; }

            public TimeRequest create_valid_time_request()
            {
                return new TimeRequest(){hours = "12" , minutes = "25"};
            } 

            public TimeFixture()
            {
                validator = new TimeIsWithinATwentyFourHourDay();
            }
        }
    }
}
