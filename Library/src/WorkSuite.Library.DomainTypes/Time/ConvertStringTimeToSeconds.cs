namespace WTS.WorkSuite.Library.DomainTypes.Time
{
    public static class ConvertStringTimeToSeconds
    {
        public static int hour(this string hour)
        {
            int hours;
            int.TryParse(hour, out hours);
            return hours * 60 * 60;
        }

        public static int minute(this string minute)
        {
            int minutes;
            int.TryParse(minute, out minutes);
            return minutes * 60;
        }
    }
}