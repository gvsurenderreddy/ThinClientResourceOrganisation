using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Models.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Model {

    public class EditorModelMetadata<S> : IModelMetadata<S> {

        public Func<S,string> id { get; set; }

        public Func<S, string> title { get; set; }

        public string description { get; set; }

        public Func<S, string> field_id_extension { get; set; }

        public Func<S, bool> should_display_description { get; set; }
    }
}