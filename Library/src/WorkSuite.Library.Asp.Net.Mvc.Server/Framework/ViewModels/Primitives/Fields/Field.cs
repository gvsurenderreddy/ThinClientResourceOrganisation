using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields
{
    public class Field
    {
        public string id { get; set; }

        public string title { get; set; }

        public bool is_required { get; set; }

        public string property_name { get; set; }

        public string help { get; set; }

        public string icon { get; set; }

        public bool is_rich_text { get; set; }

        //Improve: (D.O): We have put this here to allow for readonly fields 
        //to be able to have a different display valu from the underlying value
        public string readonly_display_value { get; set; }

        public ICollection<string> classes { get; set; }

        public IsAViewElement complementary_view_element { get; set; }
    }

    public class Field<T> : Field
    {
        public T value { get; set; }
    }
}