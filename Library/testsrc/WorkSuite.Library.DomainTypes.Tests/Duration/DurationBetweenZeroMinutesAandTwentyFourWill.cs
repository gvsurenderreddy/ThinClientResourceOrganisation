using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Duration.Validators;
using WTS.WorkSuite.Library.DomainTypes.Duration.Validators.IsBetweenZeroMinuteAndTwentyFourHours;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.Duration
{
    public class DurationBetweenZeroMinutesAandTwentyFourWill 
    {
        public class MustBeFullySpecified
        {
            [TestClass]
            public class HoursMustBeSpecified
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
                public void hour_can_not_be_whitespace()
                {
                    confirm_is_not_an_acceptable_hours_value("\t");
                }

                private void confirm_is_not_an_acceptable_hours_value
                    (string value)
                {
                    var duration_request = fixture.create_valid_duration_request();
                    duration_request.hours = value;

                    fixture.duration_validator
                        .execute(duration_request)
                        .Match(

                            is_valid:
                                duration_in_seconds => Assert.Fail("Invalid duration was identified as valid"),

                            is_not_valid:
                                errors => errors.Should().Contain(e => e is DurationValidationError.Duration_HoursIsNotSpecified
                                                                       &&
                                                                       (e as DurationValidationError.Duration_HoursIsNotSpecified)
                                                                       .field_name == "hours"));
                }

                [TestInitialize]
                public void before_each_test()
                {
                    fixture = new Durationfixture();
                }

                private Durationfixture fixture;
            }

            [TestClass]
            public class MinutesMustBeSpecified
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
                public void minutes_can_not_be_whiteSpace()
                {
                    confirm_is_not_an_acceptable_minutes_value("\t");
                }

                private void confirm_is_not_an_acceptable_minutes_value(string minute)
                {
                    var request = fixture.create_valid_duration_request();
                    request.minutes = minute;

                    fixture.duration_validator
                        .execute(request)
                        .Match(
                            is_valid:
                                duration_in_second => Assert.Fail("Invalid duration was identified as valid"),

                            is_not_valid:
                                errors =>
                                {
                                    errors.Should().Contain(e => e is DurationValidationError.Duration_MinutesIsNotSpecified &&
                                                                 (e as DurationValidationError.Duration_MinutesIsNotSpecified)
                                                                     .field_name == "minutes")

                                        ;
                                }
                        );
                }

                [TestInitialize]
                public void before_each_test()
                {
                    fixture = new Durationfixture();
                }

                private Durationfixture fixture;
            }

            [TestClass]
            public class HourAndMniuteShouldBeValid
            {
                [TestMethod]
                public void If_the_hour_and_minute_are_not_valid_it_should_report_errors()
                {
                    var duration_request = fixture.create_valid_duration_request();
                    duration_request.hours = "";
                    duration_request.minutes = "";

                    fixture.duration_validator.execute(duration_request)
                        .Match(
                            is_valid:
                                duration_in_second => Assert.Fail("hour and minute is not valid "),

                            is_not_valid:
                                errors =>
                                {
                                    errors.Should().Contain(e => e is DurationValidationError.Duration_HoursIsNotSpecified &&
                                                            (e as DurationValidationError.Duration_HoursIsNotSpecified).field_name == "hours");
                                    errors.Should().Contain(e => e is DurationValidationError.Duration_MinutesIsNotSpecified &&
                                                            (e as DurationValidationError.Duration_MinutesIsNotSpecified).field_name == "minutes");
                                }

                        );
                }

                [TestInitialize]
                public void befor_each_test()
                {
                    fixture = new Durationfixture();
                }

                private Durationfixture fixture;
            }
        }

        public class ComponantMustBeValid
        {
            [TestClass]
            public class MinuteMustBeValid
            {
                //-1 reports error .
                //60 reports error .
                //text report error.

                [TestMethod]
                public void minute_text_should_report_error()
                {
                    confirm_minutes_is_not_an_acceptable_as_it_is_not_a_number("test");
                }

                [TestMethod]
                public void minute_less_than_zero_should_report_error()
                {
                    confirm_minutes_is_not_an_acceptable_as_it_is_not_a_number("-1");
                }

                [TestMethod]
                public void minute_greater_than_sixty_should_report_error()
                {
                    confirm_minutes_is_not_an_acceptable_as_it_is_not_a_number("60");
                }

                public void confirm_minutes_is_not_an_acceptable_as_it_is_not_a_number(string value)
                {
                    var duration_request = fixture.create_valid_duration_request();
                    duration_request.minutes = value;

                    fixture.duration_validator.execute(duration_request)
                        .Match(
                            is_valid:
                                duration_in_second => Assert.Fail("minutes is not valid"),
                            is_not_valid:
                                errors => errors.Should().Contain(e => e is DurationValidationError.Duration_MinutesIsNotANumber &&
                                                                       (e as DurationValidationError.Duration_MinutesIsNotANumber).field_name == "minutes"));
                }

                [TestInitialize]
                public void before_each_test()
                {
                    fixture = new Durationfixture();
                }

                private Durationfixture fixture;
            }

            [TestClass]
            public class HourMustBeValid
            {
                // done:less than 0 should show error.
                // greater than 24 should show error.
                // text should show error .
                [TestMethod]
                public void hour_less_than_zero_should_report_error()
                {
                    confirm_hour_is_not_acceptable_as_it_is_not_a_number("-1");
                }

                [TestMethod]
                public void If_hour_is_text_should_report_error()
                {
                    confirm_hour_is_not_acceptable_as_it_is_not_a_number("test");
                }

                [TestMethod]
                public void hour_greater_than_twenty_four_should_report_error()
                {
                    confirm_hour_is_not_acceptable_as_it_is_greater_than_24("25");
                }

                private void confirm_hour_is_not_acceptable_as_it_is_not_a_number(string hour)
                {
                    var duration_reqest = fixture.create_valid_duration_request();
                    duration_reqest.hours = hour;

                    fixture.duration_validator
                        .execute(duration_reqest)
                        .Match(
                         is_valid:
                              duration_in_second => Assert.Fail("hour is not valid "),
                         is_not_valid:
                             errors => errors.Should().Contain(e => e is DurationValidationError.Duration_HoursIsNotANumber &&
                                                                    (e as DurationValidationError.Duration_HoursIsNotANumber)
                                                                        .field_name == "hours"));
                }

                private void confirm_hour_is_not_acceptable_as_it_is_greater_than_24(string hour)
                {
                    var duration_reqest = fixture.create_valid_duration_request();
                    duration_reqest.hours = hour;

                    fixture.duration_validator
                        .execute(duration_reqest)
                        .Match(
                         is_valid:
                              duration_in_second => Assert.Fail("hour is not valid "),
                         is_not_valid:
                             errors =>
                             {
                                 errors.Should().Contain(e => e is DurationValidationError.DurationIsNotIn24hour);
                             }

                        );
                }

                [TestInitialize]
                public void before_each_method()
                {
                    fixture = new Durationfixture();
                }

                private Durationfixture fixture;
            }

            [TestClass]
            public class HourAndMinuteShouldBeValid
            {
                [TestMethod]
                public void if_hour_and_minute_should_not_valid_it_should_report_error()
                {
                    var duration_reqyest = fixture.create_valid_duration_request();
                    duration_reqyest.hours = "-1";
                    duration_reqyest.minutes = "-1";

                    fixture.duration_validator.execute(duration_reqyest)
                        .Match(
                            is_valid:
                                duration_in_second => Assert.Fail("hour and minutes is not valid"),
                            is_not_valid:
                                errors =>
                                {
                                    errors.Should().Contain(e => e is DurationValidationError.Duration_HoursIsNotANumber &&
                                                                 (e as DurationValidationError.Duration_HoursIsNotANumber).field_name == "hours");

                                    errors.Should().Contain(e => e is DurationValidationError.Duration_MinutesIsNotANumber &&
                                                                 (e as DurationValidationError.Duration_MinutesIsNotANumber).field_name == "minutes");
                                }
                        );
                }

                [TestInitialize]
                public void befor_each_test()
                {
                    fixture = new Durationfixture();
                }

                private Durationfixture fixture;
            }
        }

        public class DurationMustBeBetweenZeroMinuteAndTwentyFourHours
        {
            [TestClass]
            public class TimeIntwentyFourHour
            {
                // 1 minutes more than 24 hour should report error.
                // zero hour and zero minute should not report error .

                [TestMethod]
                public void one_minute_more_than_twenty_four_should_report_error()
                {
                    var duration_request = fixture.create_valid_duration_request();
                    duration_request.hours = "24";
                    duration_request.minutes = "1";

                    fixture.duration_validator.execute(duration_request)
                        .Match(
                            is_valid:
                                duration_in_second => Assert.Fail("duration is not between 0:01 and 24 "),
                            is_not_valid:
                                errors => errors.Should().Contain(e => e is DurationValidationError.DurationIsNotIn24hour));
                }

                [TestMethod]
                public void zero_hour_and_zero_minute_should_not_report_error()
                {
                    var duration_request = fixture.create_valid_duration_request();
                    duration_request.hours = "0";
                    duration_request.minutes = "0";

                    fixture.duration_validator.execute(duration_request)
                        .Match(
                            is_valid:
                                duration_in_second => duration_in_second.Should().Be(0),
                            is_not_valid:
                                errors => Assert.Fail("Invalid case selected"));
                }

                [TestInitialize]
                public void run_befor_each_test()
                {
                    fixture = new Durationfixture();
                }

                private Durationfixture fixture;
            }
        }

        [TestClass]
        public class ValidDurationRequestsReturnTheTimeInSeconds
        {
            // done: one hour zero minutes return as a number of second (3600) .
            // done: zero hour 1 minute should return (60),
            // done: one hour and one minute should return (3660)
            [TestMethod]
            public void one_hour_zero_minute_should_return_three_thousand_six_hundred()
            {
                var duration_request = fixture.create_valid_duration_request();
                duration_request.hours = "1";
                duration_request.minutes = "0";

                fixture.duration_validator.execute(duration_request)
                    .Match(
                       is_valid:
                           duration_in_second => duration_in_second.Should().Be(3600),

                        is_not_valid:
                            errors => Assert.Fail("Invalid case selected")

                    );
            }

            [TestMethod]
            public void zero_hour_and_one_minute_should_return_sixty_second()
            {
                var duration_requets = fixture.create_valid_duration_request();
                duration_requets.hours = "0";
                duration_requets.minutes = "1";

                fixture.duration_validator.execute(duration_requets)
                    .Match(
                       is_valid:
                           duration_in_second => duration_in_second.Should().Be(60),

                        is_not_valid:
                            errors => Assert.Fail("invalid case selected"));
            }

            [TestMethod]
            public void one_hour_and_one_minute_should_return_three_thousand_six_hundard_sixty()
            {
                var duration_request = fixture.create_valid_duration_request();
                duration_request.hours = "1";
                duration_request.minutes = "1";

                fixture.duration_validator.execute(duration_request)
                    .Match(
                      is_valid:
                          duration_in_second => duration_in_second.Should().Be(3660),

                       is_not_valid:
                           errors => Assert.Fail("Invalid case selected"));
            }

            [TestInitialize]
            public void run_befo_each_test()
            {
                fixture = new Durationfixture();
            }

            private Durationfixture fixture;
        }

        internal class Durationfixture
        {
            public DurationIsBetweenZeroMinuteAndTwentyFourHours duration_validator { get; private set; }

            public DurationRequest create_valid_duration_request()
            {
                return new DurationRequest
                {
                    hours = "12",
                    minutes = "4"
                };
            }

            public Durationfixture()
            {
                duration_validator = new DurationIsBetweenZeroMinuteAndTwentyFourHours();
            }
        }
    }
}