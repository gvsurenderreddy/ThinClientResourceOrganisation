using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.TableModelMetadataRepository
{
    public class TableModelMetadataRepository<S> : ITableModelMetadataRepository<S>
    {
        public TableModelMetadata<S> metadata_for()
        {
            Guard.IsNotNull(metadata, "metadata");

            return metadata;
        }


        public void set_metadata(TableModelMetadata<S> the_metadata)
        {

            Guard.IsNotNull(the_metadata, "the_metadata");

            metadata = the_metadata;
        }
        private TableModelMetadata<S> metadata;

    }

   
}