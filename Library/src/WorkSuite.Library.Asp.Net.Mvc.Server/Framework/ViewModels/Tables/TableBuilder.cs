using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.UrlBuilder;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Fields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables {

    public class TableBuilder<S> {

        public IsAViewElement build ( IEnumerable<S> source ) {
           
           // to do: if (!report_should_be_displayed.decide_for(source)) return new NullViewElement();

            var model_metadata = model_metadata_repository.metadata_for();

            Guard.IsNotNull( model_metadata, "model_metadata" );

            return new Table
            {
                id = model_metadata.id,
                columns = create_columns( ),
                rows = create_rows( source ),
            };
        }


        public TableBuilder 
            ( ITableModelMetadataRepository<S> the_model_metadata_repository
            , TableFieldsBuilder<S> the_table_fields_builder
            , INamedRouteUrlBuilder the_route_builder 
            , ITableFieldMetadataRepository<S> the_field_metadata_repository )
        {

            Guard.IsNotNull( the_model_metadata_repository, "the_model_metadata_repository" );
            Guard.IsNotNull( the_table_fields_builder, "the_table_fields_builder" );
            Guard.IsNotNull( the_route_builder , "the_route_builder" );
            Guard.IsNotNull( the_field_metadata_repository, "the_field_metadata_repository" );

            model_metadata_repository = the_model_metadata_repository;
            table_fields_builder = the_table_fields_builder;
            route_builder = the_route_builder;
            field_metadata_repository = the_field_metadata_repository;
        }

        private IEnumerable<string> create_columns ( ) {
            
            // to do: (refactoring) this logic needs to be synchronised with the fields

            return field_metadata_repository
                        .fields
                        .Where( m => m.is_included )
                        .Select( m => m.lable )
                        ;

        }


        private IEnumerable<ATableRow> create_rows( IEnumerable<S> source ) {
            return source.Select( create_row );
        }


        // create a table row from the source
        private ATableRow create_row( S source ) {

            return new ATableRow {
                    id = create_row_id( source ) 
                  , url = create_row_url ( source )
                  , fields = table_fields_builder.build( source ),
            };
        }

        private string create_row_id (  S source ) {
            var metadata = model_metadata_repository.metadata_for();

            return metadata.field_id_extension != null ? metadata.field_id_extension(source) : "";            
        }

        private string create_row_url ( S source ) {
            var metadata = model_metadata_repository.metadata_for();
            
            if ( !string.IsNullOrWhiteSpace( metadata.row_details_route_id ) && metadata.row_details_route_pramameter_factory != null ) {

                return route_builder.build(new NamedRouteUrlObjectBuildDefinition
                {
                    route_name = metadata.row_details_route_id,
                    route_parameters_factory = () => metadata.row_details_route_pramameter_factory ( source ),
                });
            }
            return "";
        }


        // used to get model metadata for the repository.
        private readonly ITableModelMetadataRepository<S> model_metadata_repository;

        // used to build the fields from the model
        private readonly TableFieldsBuilder<S> table_fields_builder;

        // used to get routes for the presenter and actions
        private readonly INamedRouteUrlBuilder route_builder;
        private readonly ITableFieldMetadataRepository<S> field_metadata_repository;

    }
}