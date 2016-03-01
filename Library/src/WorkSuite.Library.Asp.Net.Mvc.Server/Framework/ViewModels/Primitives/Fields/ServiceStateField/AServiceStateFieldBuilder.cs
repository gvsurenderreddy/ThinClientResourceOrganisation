using System.Reflection;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors.FieldBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Models.Metadata;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.ServiceStates;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.ServiceStateField {

    public class ServiceStateFieldBuilder<S> 
                    : Builder<S, AServiceStateField, ServiceState> {


        public ServiceStateFieldBuilder
                       ( IModelMetadata<S> the_model_metadata
                       , FieldMetadata<S> the_field_metadata )
                : base ( the_field_metadata
                       , the_model_metadata ) { }

        protected override ServiceState property_value
                                            ( S source
                                            , PropertyInfo property ) {

            Guard.IsNotNull( source, "source" );
            Guard.IsNotNull( property, "property" );
            Guard.PremiseHolds( property.PropertyType == typeof(ServiceState), "Invalid property type" );

            return (ServiceState)property.GetValue( source, null );
        }
    }
}