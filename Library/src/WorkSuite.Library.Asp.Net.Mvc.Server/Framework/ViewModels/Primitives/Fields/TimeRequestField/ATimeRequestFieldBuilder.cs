using System.Reflection;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors.FieldBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Models.Metadata;
using WTS.WorkSuite.Library.DomainTypes.Time;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.TimeRequestField
{
    public class ATimeRequestFieldBuilder<S>
                       : Builder<S, ATimeRequestField, TimeRequest>
    {

        public ATimeRequestFieldBuilder
                    (IModelMetadata<S> the_model_metadata
                    , FieldMetadata<S> the_field_metadata)
            : base
                 (the_field_metadata
                 , the_model_metadata) { }


        protected override TimeRequest property_value
                                        (S source
                                        , PropertyInfo property)
        {
            var value = property.GetValue(source);
            return value is TimeRequest ? (TimeRequest) value : new TimeRequest()
            {
                hours = string.Empty,
                minutes = string.Empty
            };
        }
    }
}