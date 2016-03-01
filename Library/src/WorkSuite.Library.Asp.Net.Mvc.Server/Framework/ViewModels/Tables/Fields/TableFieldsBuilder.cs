using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Fields.DisplayPolicy;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Fields
{
    public class TableFieldsBuilder<S> : FieldsBuilder<S,TableFieldMetadata<S>> {

        public TableFieldsBuilder 
                   ( IShouldBeDisplayedOnTable<S> should_display_property_policy
                   , TableFieldFactory<S> the_field_factory ) 
            : base ( should_display_property_policy, the_field_factory ) { }
    }
}
