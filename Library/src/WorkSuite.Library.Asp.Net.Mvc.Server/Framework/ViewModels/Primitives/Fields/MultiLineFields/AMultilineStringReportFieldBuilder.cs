using System.Collections.Generic;
using System.Reflection;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors.FieldBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Models.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.MultiLineFields
{
    public class AMultilineStringReportFieldBuilder<S> : Builder<S,AMultilineStringReportField,IEnumerable<string>>
    {
        public AMultilineStringReportFieldBuilder( IModelMetadata<S> the_model_metadata,FieldMetadata<S> the_field_metadata) 
            : base(the_field_metadata, the_model_metadata)
        {
        }

        protected override IEnumerable<string> property_value(S source, PropertyInfo property)
        {
            var value = property.GetValue(source, null);

            return value as IEnumerable<string> ?? new List<string>();
        }
    }
}