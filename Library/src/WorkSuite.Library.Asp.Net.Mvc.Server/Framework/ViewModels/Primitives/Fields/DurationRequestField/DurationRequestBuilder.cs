using System.Reflection;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors.FieldBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Models.Metadata;
using WTS.WorkSuite.Library.DomainTypes.Duration;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.DurationRequestField
{
    public class DurationRequestBuilder<S>
        : Builder<S, DurationRequestField, DurationRequest>
    {
        public DurationRequestBuilder
            (FieldMetadata<S> the_field_metadata
                , IModelMetadata<S> the_model_metadata)
           
            : base(the_field_metadata, the_model_metadata)
        {
        }

        protected override DurationRequest property_value
                                  (S source
                                  , PropertyInfo property)
        {
            var value = property.GetValue(source);
            return value is DurationRequest ? (DurationRequest) value : new DurationRequest()
                {
                    hours = string.Empty,
                    minutes = string.Empty
                };
        }
    }
}