using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Fields
{
    public class TableFieldFactory<S> : Factory<S,TableFieldMetadata<S>> {

        public TableFieldFactory
                ( ITableModelMetadataRepository<S> the_model_metadata_repository
                , ITableFieldMetadataRepository<S> the_field_metadata_repository)
            : base(the_model_metadata_repository, the_field_metadata_repository)
        {
        }
    }
}