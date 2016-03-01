
namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Configuration.StaticContent
{
    public static class IconStringExtensions
    {
        public static string ToIconString(this string content_type)
        {
            switch (content_type)
            {
                case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                    return "icon-word";
                
                case "application/pdf":
                    return "icon-pdf";
                
                case "image/jpeg":
                    return "icon-image";

                case "image/bmp":
                    return "icon-image";

                case "image/gif":
                    return "icon-image";
                
                default:
                    return "icon-file";
            }
        }
    }


}
