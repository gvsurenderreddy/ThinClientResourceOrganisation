﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.Time.UtcFormat
{
    [TestClass]
    public class TimePeriodEndTimeUtcFormat : TimePeriodInUtcTimeFormatSpecification
    {

        [TestMethod]
        public void when_start_at_is_zero_and_duration_is_24_end_time_should_be_24()
        {
            fixture.time_period =new TimePeriod(new UtcTime(2014, 08, 01, 0, 0, 0, 0),86400); 
            var expected_end_time = fixture.time_period.start_at.end_time_utc_format(fixture.time_period.duration);

            expected_end_time.hours.Should().Be(0);
        }

        [TestMethod]
        public void when_start_at_is_twnty_three_fifty_nin_and_duration_is_one_minutes_end_time_should_be_twenty_four()
        {
            fixture.time_period= new TimePeriod(new UtcTime(2014, 08, 01, 23, 59, 0, 0),60);
            var expected_end_time = fixture.time_period.start_at.end_time_utc_format(fixture.time_period.duration);

            expected_end_time.hours.Should().Be(0);
        }

    }
}
