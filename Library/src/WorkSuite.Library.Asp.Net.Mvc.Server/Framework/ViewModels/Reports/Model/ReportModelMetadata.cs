using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Models.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports {

    public class ReportModelMetadata<S> : IModelMetadata<S> {

        public Func<S, string> title { get; set; }

        public Func<S, string> id { get; set; }

        public string description { get; set; }

        public Func<S, bool> is_marked_as_hidden { get; set; }

        public string report_presenter_id { get; set; }

        public Func<S, string> field_id_extension { get; set; }

        public Func<S, bool> should_display_discription { get; set; }


    }
}