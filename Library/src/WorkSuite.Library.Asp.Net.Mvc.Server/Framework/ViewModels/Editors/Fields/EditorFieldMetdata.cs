using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Fields {

    public class EditorFieldMetadata<S> : FieldMetadata<S> {
        

        public EditorFieldStatus status { get; set; }

        public FieldTypes field_type { get; set; }

        /// <summary>
        ///     Identifies if the field should be included in the report
        /// </summary>
        public Func<S, bool> is_included { get; set; }

    }

}

