using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WTS.WorkSuite.Library.DomainTypes.Date;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.Date
{
    // if same year same month -  is within month
    // if same year different months - crosses month boundary
    // if different years - crosses year bounday
    // if got here throw an exception

    [TestClass]
    public class date_range_helper_will
    {
        [TestMethod]
        public void execute_registered_callback_when_within_month_boundary()
        {
            //Arrange
            var start_date = DateTime.Now.FirstDayOfMonth();
            var end_date = start_date.AddDays(10);

            Action success = () => { };

            //Act
            DateRangeSpan.Boundary(
                                    a_date:
                                        start_date,
                                    another_date:
                                        end_date,
                                    within_month:
                                        success,
                                    crosses_month:
                                        Assert.Fail,
                                    crosses_year:
                                        Assert.Fail
                                    );
        }

        [TestMethod]
        public void execute_registered_callback_when_crosses_month_boundary()
        {
            //Arrange
            var start_date = DateTime.Now.FirstDayOfMonth();

            //Since year boundary overrides month boundary, we cannot have the start date be the 1st of decemeber
            if (start_date.Month == 12)
            {
                start_date = start_date.AddMonths(-1);
            }

            var number_of_days_in_the_month = DateTime.DaysInMonth(start_date.Year, start_date.Month);
            var end_date = start_date.AddDays(number_of_days_in_the_month);

            Action success = () => { };

            //Act
            DateRangeSpan.Boundary(
                                    a_date:
                                        start_date,
                                    another_date:
                                        end_date,
                                    within_month:
                                        Assert.Fail,
                                    crosses_month:
                                        success,
                                    crosses_year:
                                        Assert.Fail
                                    );
        }

        [TestMethod]
        public void execute_registered_callback_when_crosses_year_boundary()
        {
            //Arrange
            var start_date = DateTime.Now.FirstDayOfMonth();
            var end_date = start_date.AddDays(400);

            Action success = () => { };

            //Act
            DateRangeSpan.Boundary(
                                    a_date:
                                        start_date,
                                    another_date:
                                        end_date,
                                    within_month:
                                        Assert.Fail,
                                    crosses_month:
                                        Assert.Fail,
                                    crosses_year:
                                        success
                                    );
        }
    }
}