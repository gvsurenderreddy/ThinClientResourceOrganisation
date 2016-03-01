using System.Reflection;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors.FieldBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Models.Metadata;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.ReadOnlyField
{
    public class AReadOnlyFieldBuilder<S> : Builder<S, AReadOnlyField, string>
    {

        public AReadOnlyFieldBuilder
                   (IModelMetadata<S> the_model_metadata
                   , FieldMetadata<S> the_field_metadata)
            : base(the_field_metadata
                   , the_model_metadata) { }


        // to do: this is a violation of Dry as it is also in the AStringFieldBuilder
        protected override string property_value
            (S source, PropertyInfo property)
        {

            Guard.IsNotNull(source, "source");
            Guard.IsNotNull(property, "property");

            // to do: set it to the null text value if not set
            var value = property.GetValue(source, null);

            var source_value = value as string;

            //D.O: Above was returning null for integer values
            //so added ths if condition


            if (source_value == null)
            {
                source_value = value.ToString();
            }


            return source_value;


        }
    }
}
