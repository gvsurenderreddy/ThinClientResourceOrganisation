using System;
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports {

    public class Report : IsAViewElement {

        public string id { get; set; }
       
        public string title { get; set; }

        public string description { get; set; }
        
        public string report_presenter_url { get; set; }

        public string report_reorder_url { get; set; }

        public IEnumerable<RoutedAction> actions { get; set; }

        public IEnumerable<Field> fields { get; set; }

        public bool is_marked_as_hidden { get; set; }

        public bool is_enabled { get; set; }
    }
}