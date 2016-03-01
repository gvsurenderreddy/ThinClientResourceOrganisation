using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.Library.DomainTypes.Date.Validators.IsADate.GregorianCalendar;
using WTS.WorkSuite.Library.DomainTypes.Date.Validators.IsADate.MonthInference;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.Date
{
    [TestClass]
    public class CheckGregorianCalendarSanitisation 
    {
        

        [TestClass]
        public class YearSanitisation : CheckSanitisationForGregorianCalendarSpecification
        {
            //year should be specify if month and day is specified.
            //year should be integer 
            //year can not less than zero 

            [TestMethod]
            public void year_should_be_specify_if_month_and_day_is_specified()
            {
                var invalid_date_request = new DateRequest { year = " ", month = "03", day = "03" };

                gregorian_calendar_sanitisation.execute(invalid_date_request)
                    .Match(
                     is_valid:
                         date => Assert.Fail("Invalid date was identified as valid"),
                     is_not_valid:
                         error => new GregorianCalendarSanitisationResult.Error()

                         );
            }

            [TestMethod]
            public void year_should_be_integer()
            {
                var invalid_date_request = new DateRequest { year = "R", month = "03", day = "03" };

                gregorian_calendar_sanitisation.execute(invalid_date_request)
                    .Match(
                     is_valid:
                         date => Assert.Fail("Invalid date was identified as valid"),
                     is_not_valid:
                         error => new GregorianCalendarSanitisationResult.Error()

                         );
            }

            [TestMethod]
            public void year_should_not_less_than_zero()
            {
                var invalid_date_request = new DateRequest { year = "-1", month = "03", day = "03" };

                gregorian_calendar_sanitisation.execute(invalid_date_request)
                    .Match(
                     is_valid:
                         date => Assert.Fail("Invalid date was identified as valid"),
                     is_not_valid:
                         error => new GregorianCalendarSanitisationResult.Error()

                         );
            }

            [TestMethod]
            public void year_can_be_one_digit()
            {
                var valid_request = new DateTime ( 1,03, 03 ) ;

                gregorian_calendar_sanitisation.execute(valid_request.ToDateRequest())
                    .Match(
                     is_valid:
                         date => (date).year.Should().Be(valid_request.to_Date().year),
                     is_not_valid:
                         error => new GregorianCalendarSanitisationResult.Error()

                         );
            }

            [TestMethod]
            public void year_can_not_be_0000_digit()
            {
                var invalid_date_request = new DateRequest { year = "0000", month = "02", day = "28" };
                gregorian_calendar_sanitisation.execute(invalid_date_request)
                    .Match(
                     is_valid:
                         date => Assert.Fail("Year is not valid "),
                     is_not_valid:
                         error => new GregorianCalendarSanitisationResult.Error()

                         );
            }
        }

        [TestClass]
        public class MonthSanitisation : CheckSanitisationForGregorianCalendarSpecification
        {
            //month should be integer 
            // month should not be less than zero 
            //month should fully specify

            [TestMethod]
            public void month_should_be_specify_if_year_and_day_is_specified()
            {
                var invalid_date_request = new DateRequest { year = "2003 ", month = " ", day = "03" };

                gregorian_calendar_sanitisation.execute(invalid_date_request)
                    .Match(
                     is_valid:
                         date => Assert.Fail("Invalid date was identified as valid"),
                     is_not_valid:
                         error => new GregorianCalendarSanitisationResult.Error()

                         );
            }

            [TestMethod]
            public void is_valid_when_a_month_component_is_numeric()
            {
                gregorian_calendar_sanitisation
                    .execute(valid_date_request.ToDateRequest())
                    .Match(

                        is_valid:
                            date =>
                            {
                                (date.year).Should().Be(valid_date_request.to_Date().year);
                                (date.month).Should().Be(valid_date_request.to_Date().month);
                                (date.day).Should().Be(valid_date_request.to_Date().day);
                            },

                        is_not_valid:
                            errors => Assert.Fail()

                    );
            }

            [TestMethod]
            public void reports_month_component_is_not_valid_a_random_string()
            {
                var invalid_date_request=new DateRequest{year = "y" ,month = "m" , day = "d"};
                gregorian_calendar_sanitisation
                    .execute(invalid_date_request)
                    .Match(

                        is_valid:
                            date => Assert.Fail("Date request is not valid "),

                        is_not_valid:
                            errors => new GregorianCalendarSanitisationResult.Error()
                    );
            }

            [TestMethod]
            public void month_can_not_be_00_digit()
            {
                var invalid_date_request = new DateRequest { year = "2003", month = "00", day = "28" };
                gregorian_calendar_sanitisation.execute(invalid_date_request)
                    .Match(
                     is_valid:
                         date => Assert.Fail("Year is not valid "),
                     is_not_valid:
                         error => new GregorianCalendarSanitisationResult.Error()

                         );
            }

            [TestMethod]
            public void check_month()
            {
                var invalid_date_request = new DateRequest { year = "2003", month = "2a", day = "28" };
                gregorian_calendar_sanitisation.execute(invalid_date_request)
                    .Match(
                     is_valid:
                         date => Assert.Fail("Year is not valid "),
                     is_not_valid:
                         error => new GregorianCalendarSanitisationResult.Error()

                         );
            }
        }

        [TestClass]
        public class DaySanitisation : CheckSanitisationForGregorianCalendarSpecification
        {
            // day should be integer 
            // day should not be less than zero 
            //day should fully specify

            [TestMethod]
            public void day_should_be_specify_if_year_and_month_is_specified()
            {
                var invalid_date_request = new DateRequest { year = "2003 ", month = "02", day = " " };
                gregorian_calendar_sanitisation.execute(invalid_date_request)
                    .Match(
                     is_valid:
                         date => (date).day.Should().Be(valid_date_request.to_Date().day),
                     is_not_valid:
                         error => new GregorianCalendarSanitisationResult.Error()

                         );
            }

            [TestMethod]
            public void day_should_be_integer()
            {
                var invalid_date_request = new DateRequest { year = "2003", month = "03", day = "R" };

                gregorian_calendar_sanitisation.execute(invalid_date_request)
                    .Match(
                     is_valid:
                         date => Assert.Fail("Invalid date was identified as valid"),
                     is_not_valid:
                         error => new GregorianCalendarSanitisationResult.Error()

                         );
            }

            [TestMethod]
            public void day_should_not_be_less_than_zero()
            {
                var invalid_date_request = new DateRequest { year = "2003", month = "03", day = "-1" };

                gregorian_calendar_sanitisation.execute(invalid_date_request)
                    .Match(
                     is_valid:
                         date => Assert.Fail("Invalid date was identified as valid"),
                     is_not_valid:
                         error => new GregorianCalendarSanitisationResult.Error()

                         );
            }

            [TestMethod]
            public void is_valid_when_a_day_componant_is_numric()
            {
                gregorian_calendar_sanitisation
                   .execute(valid_date_request.ToDateRequest())
                   .Match(

                       is_valid:
                           date =>
                           {
                               (date).year.Should().Be(valid_date_request.to_Date().year);
                               (date).month.Should().Be(valid_date_request.to_Date().month);
                               (date).day.Should().Be(valid_date_request.to_Date().day);
                           },

                       is_not_valid:
                           errors => Assert.Fail()

                   );
            }

            [TestMethod]
            public void day_can_not_be_00_digit()
            {
                var invalid_date_request = new DateRequest { year = "2003", month = "01", day = "00" };
                gregorian_calendar_sanitisation.execute(invalid_date_request)
                    .Match(
                     is_valid:
                         date => Assert.Fail("Year is not valid "),
                     is_not_valid:
                         error => new GregorianCalendarSanitisationResult.Error()

                         );
            }
        }

        [TestClass]
        public class DateSanitisation : CheckSanitisationForGregorianCalendarSpecification
        {
            // check year boundary 
            // check month boundary
            // check day boundary

            [TestMethod]
            public void if_year_is_more_than_4_digit_it_should_show_error()
            {
                var invalid_date_request = new DateRequest { year = "200333", month = "02", day = "02" };

                gregorian_calendar_sanitisation.execute(invalid_date_request)
                    .Match(
                     is_valid:
                         date => Assert.Fail("Invalid date was identified as valid"),
                     is_not_valid:
                         error => new GregorianCalendarSanitisationResult.Error()

                         );
            }

            [TestMethod]
            public void if_month_is_more_than_2_digit_it_should_show_error()
            {
                var invalid_date_request = new DateRequest { year = "2003", month = "15", day = "02" };

                gregorian_calendar_sanitisation.execute(invalid_date_request)
                    .Match(
                     is_valid:
                         date => Assert.Fail("Invalid date was identified as valid"),
                     is_not_valid:
                         error => new GregorianCalendarSanitisationResult.Error()

                         );
            }

            [TestMethod]
            public void check_buandary_of_day()
            {
                var invalid_date_request = new DateRequest { year = "2003", month = "02", day = "31" };

                gregorian_calendar_sanitisation.execute(invalid_date_request)
                    .Match(
                     is_valid:
                         date => Assert.Fail("Invalid date was identified as valid"),
                     is_not_valid:
                         error => new GregorianCalendarSanitisationResult.Error()

                         );
            }

            [TestMethod]
            public void valid_date_should_not_show_error()
            {
                var invalid_date_request = new DateRequest { year = "2003", month = "02", day = "28" };

                gregorian_calendar_sanitisation.execute(invalid_date_request)
                    .Match(
                     is_valid:
                         date => { new GregorianCalendarSanitisationResult.ValidDate(date); },
                     is_not_valid:
                         error => new GregorianCalendarSanitisationResult.Error()

                         );
            }

            [TestMethod]
            public void if_start_sate_time_is_0000_00_00_it_should_show_error()
            {
                var invalid_date_request = new DateRequest { year = "0000", month = "00", day = "00" };


                gregorian_calendar_sanitisation.execute(invalid_date_request)
                    .Match(
                        is_valid:
                            date => Assert.Fail("date is not valid "),
                     is_not_valid:
                         error => new GregorianCalendarSanitisationResult.Error()

                         );
            }

            [TestMethod]
            public void if_start_sate_time_is_0001_01_01_it_is_valid()
            {
                var request = new DateTime(0001, 01, 01);


                gregorian_calendar_sanitisation.execute(request.ToDateRequest())
                    .Match(
                        is_valid:
                            date =>
                            {
                                (date).year.Should().Be(request.to_Date().year);
                                (date).month.Should().Be(request.to_Date().month);
                                (date).day.Should().Be(request.to_Date().day);
                            },
                     is_not_valid:
                         error => new GregorianCalendarSanitisationResult.Error()

                         );
            }

            [TestMethod]
            public void it_is_valid_if_date_is_31_12_9999_()
            {
                var request = new DateTime(9999, 12, 31);


                gregorian_calendar_sanitisation.execute(request.ToDateRequest())
                    .Match(
                        is_valid:
                           date =>
                           {
                               (date).year.Should().Be(request.to_Date().year);
                               (date).month.Should().Be(request.to_Date().month);
                               (date).day.Should().Be(request.to_Date().day);
                           },
                     is_not_valid:
                         error => new GregorianCalendarSanitisationResult.Error()

                         );
            }

            [TestMethod]
            public void it_is_valid_if_date_is_in_the_right_order()
            {
                var request = new DomainTypes.Date.Validators.IsADate.GregorianCalendar.Date(2013,12,23);

                var date_request = new DateRequest(){year = request.year.ToString(), month = request.month.ToString(),day = request.day.ToString()};
                gregorian_calendar_sanitisation.execute(date_request)
                    .Match(
                        is_valid:
                            date =>
                            {
                                (date).year.Should().Be(request.year);
                                (date).month.Should().Be(request.month);
                                (date).day.Should().Be(request.day);
                            },
                     is_not_valid:
                         error => new GregorianCalendarSanitisationResult.Error()

                         );
            }

            [TestMethod]
            public void it_is_not_valid_if_date_is_not_in_the_right_order()
            {

                var date_request = new DateRequest() { year = "2013", month = "12", day = "23"};

                var request = new DomainTypes.Date.Validators.IsADate.GregorianCalendar.Date
                                                      ( Convert.ToInt32(date_request.month)
                                                      , Convert.ToInt32(date_request.day)
                                                      , Convert.ToInt32(date_request.year));

                gregorian_calendar_sanitisation.execute(date_request)
                    .Match(
                        is_valid:
                            date =>
                            {
                                (date).year.Should().NotBe(request.year);
                                (date).month.Should().NotBe(request.month);
                                (date).day.Should().NotBe(request.day);
                            },
                     is_not_valid:
                         error => new GregorianCalendarSanitisationResult.Error()

                         );
            }

        }

    }

    public class CheckSanitisationForGregorianCalendarSpecification
    {
        public GregorianCalendarSanitisation gregorian_calendar_sanitisation { get; private set; }
        public DateTime valid_date_request { get; private set; }

        [TestInitialize]
        public void before_each_test()
        {
            gregorian_calendar_sanitisation=new GregorianCalendarSanitisation(new MonthInferenceSanitisation());
            valid_date_request = new DateTime( 2003, 08, 24 );
              

                set_up();
        }

     

        public virtual void set_up(){ }
    }

    internal static class DateHelpers
    {

        public static DomainTypes.Date.Validators.IsADate.GregorianCalendar.Date to_Date(this DateTime date_request)
        {

            return new DomainTypes.Date.Validators.IsADate.GregorianCalendar.Date( date_request.Year, date_request.Month, date_request.Day);
        }
    }

}