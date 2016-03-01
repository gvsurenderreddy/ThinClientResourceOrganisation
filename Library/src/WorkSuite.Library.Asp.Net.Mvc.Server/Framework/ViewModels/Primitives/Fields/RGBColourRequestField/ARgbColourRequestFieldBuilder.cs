using System;
using System.Reflection;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors.FieldBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Models.Metadata;
using WTS.WorkSuite.Library.DomainTypes.Colour;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.RGBColourRequestField
{
    public class ARgbColourRequestFieldBuilder<S>
                          : Builder<S, ARgbColourRequestField, RGBColourRequest>
    {
        public ARgbColourRequestFieldBuilder
                         (IModelMetadata<S> the_model_metadata
                         , FieldMetadata<S> the_field_metadata)
            
            : base
                  (the_field_metadata, the_model_metadata)
        {
        }

       

        protected override RGBColourRequest property_value
                                            (S source
                                           , PropertyInfo property)
        {
            var value = property.GetValue(source);
            return value is RGBColourRequest ? (RGBColourRequest) value : new RGBColourRequest();
        }
    }
}