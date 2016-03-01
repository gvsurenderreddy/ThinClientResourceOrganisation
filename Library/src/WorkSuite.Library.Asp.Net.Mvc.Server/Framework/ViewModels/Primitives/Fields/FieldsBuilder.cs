using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.VisibilityPolicies;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields {

    public abstract class FieldsBuilder<S,M> where M : FieldMetadata<S> {

        /// <summary>
        ///     Creates a report field set from the source.
        /// </summary>
        /// <param name="source">
        ///     The source that the field set will be created from.
        /// </param>
        /// <returns>
        ///     A field set that has a field entry for each property that was not excluded.
        /// </returns>
        public IEnumerable<Field> build ( S source ) {

            Func<PropertyInfo,Field> build_field = property  => field_factory.create( source, property );

            return get_properties_for( source )
                    .Where( p =>  should_be_displayed( p, source ) )
                    .Select( build_field )
                    // to do: field ordering.
                    ;
        }


        protected FieldsBuilder 
            ( IPropertyShouldBeDisplayed should_display_property_policy 
            , Factory<S,M> the_field_factory ) {

            Guard.IsNotNull( should_display_property_policy, "should_display_property_policy " );
            Guard.IsNotNull( the_field_factory, "the_field_factory" );

            property_should_be_displayed = should_display_property_policy;
            field_factory = the_field_factory;
        }

        private IEnumerable<PropertyInfo> get_properties_for ( S source ) {
            Guard.IsNotNull( source, "source" );

            return source
                    .GetType()
                    .GetProperties()
                    ;

        } 

        // identifies if a property should be included for display in the fields set
        protected virtual bool should_be_displayed ( PropertyInfo property_to_check, S source ) {

            return property_should_be_displayed.decide_for( property_to_check );
        }
        
        // creates the report fields for each report in the 
        private readonly Factory<S,M> field_factory;

        // policy used to decided if to create a field for a property.
        private readonly IPropertyShouldBeDisplayed property_should_be_displayed;
    }
}