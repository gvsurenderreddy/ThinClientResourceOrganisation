using System.Reflection;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors.FieldBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Models.Metadata;
using WTS.WorkSuite.Library.DomainTypes.Colour;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.RGBColourField
{
    public class ARgbColourFieldBuilder <S>
                              : Builder< S , ARgbColourField, RgbColour >
    {
        public ARgbColourFieldBuilder
                           (IModelMetadata<S> the_model_metadata
                           , FieldMetadata<S> the_field_metadata)

            : base
                  (the_field_metadata, the_model_metadata)
        {
        }

        protected override RgbColour property_value(S source, PropertyInfo property)
        {
            var value = property.GetValue(source);

            var source_value = value as RgbColour;

            return value is RgbColour ? (RgbColour)value : new RgbColour(source_value.R,source_value.G,source_value.G);
        }
    }
}