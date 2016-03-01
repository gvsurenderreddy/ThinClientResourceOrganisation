using System.Reflection;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors.FieldBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.StringField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Models.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.HiddenField {

    public class AHiddenFieldBuilder<S> : Builder<S,AHiddenField,string> {

        public AHiddenFieldBuilder 
                   ( IModelMetadata<S> the_model_metadata
                   , FieldMetadata<S> the_field_metadata ) 
            : base ( the_field_metadata
                   , the_model_metadata ) {}


        // to do: this is a violation of Dry as it is also in the AStringFieldBuilder
        protected override string property_value 
            ( S source, PropertyInfo property ) {

            Guard.IsNotNull( source, "source" );
            Guard.IsNotNull( property, "property" );

            // to do: set it to the null text value if not set
            var value = property.GetValue( source, null );

            if (value != null) {
                return value.ToString();
            }
            return "";
        }
    }

}