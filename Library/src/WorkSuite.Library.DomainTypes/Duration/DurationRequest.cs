using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Formating;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.Library.DomainTypes.Time;

namespace WTS.WorkSuite.Library.DomainTypes.Duration
{
    public class DurationRequest
    {
        public string hours { get; set; }
        public string minutes { get; set; }
        public static void duration_hour_is_valid_in_twenty_four_hour_oclock() { }

       
    }
    public static class DurationExtension
    {

        public static DurationRequest to_duration_request
                                            (this int request)
        {

            Guard.IsNotNull(request, "request");
            var hours = request / (60 * 60);
            var minutes = (request - (hours * 60 * 60)) / 60;
            return new DurationRequest()
              {

                  hours = hours.ToString("0"),
                  minutes = minutes.ToString("0"),
              };
        }

        public static string to_domain_format_string(this DurationRequest duration_request)
        {
            return ReportFormatStringExtension.to_domain_format_string(duration_request.hours, duration_request.minutes);
        }


        public static DurationRequest normalise_for_persistence(this DurationRequest request)
        {
            return new DurationRequest
            {
                hours = request.hours.normalise_for_persistence(),
                minutes = request.minutes.normalise_for_persistence()
            };
        }

        public static int to_seconds(this DurationRequest request)
        {
            return request.hours.hour() + request.minutes.minute();
        }
    }

   
}