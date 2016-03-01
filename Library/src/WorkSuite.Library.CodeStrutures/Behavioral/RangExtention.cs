namespace WTS.WorkSuite.Library.CodeStrutures.Behavioral
{
    public static class RangExtention
    {
        public static bool IsInRange
                                  (this int current_range, int begin_range, int end_range)
        {
            return (current_range >= begin_range && current_range <= end_range);
        } 
    }
}