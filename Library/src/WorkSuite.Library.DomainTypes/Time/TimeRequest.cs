using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;

namespace WTS.WorkSuite.Library.DomainTypes.Time
{
    /// <summary>
    ///     Reuest type that can ve used to specify a time broken into hours and minutes.
    /// This can then be validated and converted into point that is saved as the number of 
    /// seconds from midnight via a validator.
    /// </summary>
    public class TimeRequest
    {
        public string hours { get; set; }
        public string minutes { get; set; }
    }

    /// <summary>
    /// should write test 
    /// </summary>
    public static class TimeRequestExtension
    {

        public static TimeRequest ToTimeRequestFromSeconds (this int request)
        {

            Guard.IsNotNull(request, "request");
            var hours = request/(60*60);
            var minutes = (request - (hours*60*60))/60;

            return new TimeRequest
            {
                hours = hours.ToString("00"),
                minutes = minutes.ToString("00"),
            };
        }

        public static string to_domain_string(this TimeRequest request)
        {
            return string.Format("{0}:{1}", request.hours, request.minutes);
        }

        public static int to_Seconds(this TimeRequest request)
        {
            return request.hours.hour() + request.minutes.minute();
        }
        public static TimeRequest normalise_for_persistence(this TimeRequest request)
        {
            return new TimeRequest()
            {
                hours = request.hours.normalise_for_persistence(),
                minutes = request.minutes.normalise_for_persistence()
            };
        }
    }

    
}
