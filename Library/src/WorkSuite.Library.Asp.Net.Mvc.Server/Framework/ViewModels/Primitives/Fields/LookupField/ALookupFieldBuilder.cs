using System;
using System.Collections.Generic;
using System.Reflection;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors.FieldBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Models.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.LookupField {

    public class ALookupFieldBuilder<S> : Builder<S, ALookupField, int> {


        public ALookupFieldBuilder 
                   ( IModelMetadata<S> the_model_metadata
                   , FieldMetadata<S> the_field_metadata
                   , ILookupFieldValuesRepository<S> the_lookup_values_repository
                   )
            : base ( the_field_metadata
                   , the_model_metadata
                   ) {
            
            lookup_values_repository = Guard.IsNotNull( the_lookup_values_repository, "the_lookup_values_repository" );
        }


        protected override void initialise_instance 
            ( ALookupField instance
            , PropertyInfo property
            , S source ) {
            
            base.initialise_instance( instance, property, source );

            instance.lookup_values = get_lookup_values( property );
        }


        protected override int property_value 
            ( S source
            , PropertyInfo property
            ) {

            Guard.IsNotNull(source, "source");
            Guard.IsNotNull(property, "property");

            return Convert.ToInt32( property.GetValue( source ));
        }

        private IEnumerable<LookupValue> get_lookup_values
            (  PropertyInfo property ) {

            return lookup_values_repository.values_for( property.Name );
        }

        private readonly ILookupFieldValuesRepository<S> lookup_values_repository;

    }
}