using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.Time
{
    public static class ConvertSecondsTotwntyForHourintegerTime
    {
            public static int seconds_to_hours(this int value)
            {
                Guard.IsNotNull(value, "value");
                var hours = value / (60 * 60);
                return hours;
            }
            public static int seconds_to_minutes(this int value)
            {
                Guard.IsNotNull(value, "value");
                var hours = value / (60 * 60);
                var minutes = (value - (hours * 60 * 60)) / 60;
                return minutes;
            }

            public static int hours_to_seconds(this int value)
            {
                Guard.IsNotNull(value, "value");
                var hours = value * (60 * 60);
                return hours;
            }

            public static int minutes_to_seconds(this int value)
            {
                Guard.IsNotNull(value, "value");
                var hours = value * 60;
                return hours;
            }
    }
}