using System.Reflection;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.UrlBuilder;
using WTS.WorkSuite.Library.DomainTypes.Images;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors.FieldBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Models.Metadata;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.SimpleImageField
{
    public class ASimpleImageFieldBuilder<S> : Builder<S, ASimpleImageField, string>
    {
        public ASimpleImageFieldBuilder(IModelMetadata<S> the_model_metadata
                                     , FieldMetadata<S> the_field_metadata)
            //, IRouteBuilder the_route_builder)
            : base(the_field_metadata
                   , the_model_metadata)
        {
            route_builder = new NamedRouteUrlBuilder();//Guard.IsNotNull(the_route_builder, "the_route_builder");
            
        }


        // to do: this is a violation of Dry as it is also in the AStringFieldBuilder
        protected override string property_value
            (S source, PropertyInfo property)
        {

            Guard.IsNotNull(source, "source");
            Guard.IsNotNull(property, "property");

            // to do: set it to the null text value if not set
            var value = property.GetValue(source, null);

            var source_value =  (ImageId)value;

            return source_value;


        }

        protected override void initialise_instance(ASimpleImageField instance, PropertyInfo property, S source)
        {
            base.initialise_instance(instance, property, source);
            var image_id = (ImageId)property.GetValue(source, null);
            var route = route_builder.build(new NamedRouteUrlObjectBuildDefinition()
            {
                route_name = "image-details-report",
                route_parameters_factory = () => new { document_id = image_id  }
            });
            instance.url = route;
        }

        private readonly INamedRouteUrlBuilder route_builder;
    }
}
