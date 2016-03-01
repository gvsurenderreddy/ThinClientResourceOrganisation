using System.Reflection;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors.FieldBuilder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Models.Metadata;
using WTS.WorkSuite.Library.DomainTypes.Date;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.DateRequestField {

    public class ADateRequestFieldBuilder<S> 
                    : Builder<S, ADateRequestField, DateRequest> {

        public ADateRequestFieldBuilder 
                    ( IModelMetadata<S> the_model_metadata
                    , FieldMetadata<S> the_field_metadata ) 
               : base 
                    ( the_field_metadata
                    , the_model_metadata ) {}


        protected override DateRequest property_value 
                                        ( S source
                                        , PropertyInfo property ) {

            // either return the proper
            return (property.GetValue( source ) as DateRequest) 
                ?? new DateRequest {
                        year = string.Empty, 
                        month = string.Empty, 
                        day= string.Empty
                   };
        }
    }

}