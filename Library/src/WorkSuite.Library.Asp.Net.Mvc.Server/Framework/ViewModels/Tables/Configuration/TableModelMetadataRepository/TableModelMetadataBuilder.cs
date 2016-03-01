using System;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.TableModelMetadataRepository
{
    public class TableModelMetadataBuilder<S> : ITableModelMetadataBuilder<S>
    {
        public ITableModelMetadataBuilder<S> id(string value)
        {
            metadata.id = value;

            return this;
        }

        public ITableModelMetadataBuilder<S> row_details_route_id ( string value ) {
            metadata.row_details_route_id = value;

            return this;
        }

        public ITableModelMetadataBuilder<S> row_details_route_pramameter_factory ( Func<S, object> value ) {
            metadata.row_details_route_pramameter_factory = value;

            return this;
        }

        public ITableModelMetadataBuilder<S> field_id_extension ( Func<S, string> genrator )
        {
            metadata.field_id_extension = genrator;
            return this;
        }


        public TableModelMetadataBuilder( TableModelMetadataRepository<S> repository ) {

            Guard.IsNotNull( repository, "repository" );

            repository.set_metadata( metadata );
        }

        private readonly TableModelMetadata<S> metadata = new TableModelMetadata<S>();
    }
}