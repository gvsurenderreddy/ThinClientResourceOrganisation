namespace WTS.WorkSuite.Library.DomainTypes.Formating
{
    public static class ReportFormatStringExtension
    {
        public static string to_domain_format_string(string hours, string minutes)
        {
            string return_string;
            if (minutes == "0" && hours!="0")
            {
                return_string = string.Format("{0}{1}", hours, "h");
            }
            else if (hours == "0" && minutes !="0")
            {
                return_string = string.Format("{0}{1}", minutes, "m");
            }
            else if (hours == "0" && minutes == "0")
            {
                return_string = string.Format("{0}{1}", minutes, "m");
            }
            else
            {
                return_string = string.Format("{0}{1}{2}{3}{4}", hours, "h", " ", minutes, "m");
            }
            return return_string;
        }

        //This method takes in the actual and requested resource allocation and returns us a string as a/r.
        public static string actual_against_requested_string_for_resource_allocation(int actual, int requested)
        {
            return actual + "/" + requested
            ;
        }
    }
}