using System;
using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Metadata
{
    public abstract class FieldMetadata<S>
    {
        /// <summary>
        ///     Identifies if the field is mandatory or not.
        /// </summary>
        public bool is_required { get; set; }

        /// <summary>
        /// Identifies if the field is a rich text
        /// </summary>
        public bool is_rich_text { get; set; }

        /// <summary>
        ///     Text that is displayed as the field's label
        /// </summary>
        public string lable { get; set; }

        /// <summary>
        ///     Identity to use for this field
        /// </summary>
        // public string id { get; set; }

        public Func<S, string> id { get; set; }

        /// <summary>
        ///     The help for the field
        /// </summary>
        public string help { get; set; }

        /// <summary>
        /// The icon class for this field
        /// </summary>
        public Func<S, string> icon { get; set; }

        /// <summary>
        ///Improve: (D.O) This is a hack for the readonly field display value
        /// </summary>
        public Func<S, string> readonly_display_string { get; set; }

        /// <summary>
        /// A view element that should be built/associated with this field
        /// </summary>
        public Func<S, IsAViewElement> complementary_view_element { get; set; }

        /// <summary>
        ///     Identifies whether the value should be humanised or not. This only works
        /// for string fields.
        /// </summary>
        public bool humanize { get; set; }

        /// <summary>
        ///     Classes that are used to style the field.
        /// </summary>
        public ICollection<string> classes { get; set; }
    }
}