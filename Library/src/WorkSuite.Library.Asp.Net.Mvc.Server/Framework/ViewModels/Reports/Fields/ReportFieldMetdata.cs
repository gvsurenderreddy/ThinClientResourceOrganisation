using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Fields {

    // Improve: Make it explicit what field type you are trying to build via the builders

    //          I think we should have expicit metadata type for each Field type.  
    //          Need to think about the relationship between the controls,fields and the domain 
    //          types.  Currently the decision as to which field type should be created is split
    //          across the domain type and metadata properties.  I think it should be made 
    //          explicit in metadata builder.

    public class ReportFieldMetadata<S> : FieldMetadata<S> {

        public ReportFieldStatus status { get; set; }

        /// <summary>
        ///     Identifies if the field should be included in the report
        /// </summary>
        public Func<S, bool> is_included { get; set; }

        /// <summary>
        /// Identifies the field type of this report field
        /// </summary>
        public FieldTypes field_type { get; set; }

    }

}