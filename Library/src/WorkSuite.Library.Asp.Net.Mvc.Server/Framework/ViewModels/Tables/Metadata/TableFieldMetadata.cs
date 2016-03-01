using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Metadata {
    
    public class TableFieldMetadata<S> : FieldMetadata<S> {

        /// <summary>
        ///     Identifies if the field should be included in the table
        /// </summary>
        public bool is_included { get; set;}
    }
}