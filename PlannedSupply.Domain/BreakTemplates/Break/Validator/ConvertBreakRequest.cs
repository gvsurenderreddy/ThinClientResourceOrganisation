using System;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Validator
{
    public static  class ConvertBreakRequest
    {
        public static TimePeriod from_new_request_to_time_period(this NewBreakRequest request)
        {
            var date_time = new DateTime();
            var offset_to_date_time = date_time.AddSeconds(request.off_set.to_seconds());
            return new TimePeriod(new UtcTime(offset_to_date_time.Year
                , offset_to_date_time.Month
                , offset_to_date_time.Day
                , offset_to_date_time.Hour
                , offset_to_date_time.Minute
                , offset_to_date_time.Second
                , offset_to_date_time.Millisecond),
                request.duration.to_seconds());
        }

        public static TimePeriod from_update_request_to_time_period(this UpdateBreakRequest request)
        {
            var date_time = new DateTime();
            var offset_to_date_time = date_time.AddSeconds(request.off_set.to_seconds());
            return new TimePeriod(new UtcTime(offset_to_date_time.Year
                , offset_to_date_time.Month
                , offset_to_date_time.Day
                , offset_to_date_time.Hour
                , offset_to_date_time.Minute
                , offset_to_date_time.Second
                , offset_to_date_time.Millisecond),
                request.duration.to_seconds());

        }
    }
}

