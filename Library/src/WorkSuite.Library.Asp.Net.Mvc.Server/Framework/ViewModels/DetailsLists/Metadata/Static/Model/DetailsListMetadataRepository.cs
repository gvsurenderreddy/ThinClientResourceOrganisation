using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Model;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Model {

    public class DetailsListMetadataRepository<S> : IDetailsListMetadataRepository<S> {

        public DetailsListMetadata metadata_for ( ) {
            
            return metadata;
        }

        public void set_metadata ( DetailsListMetadata new_metadata ) {
            metadata = new_metadata;
        }


        DetailsListMetadata metadata = new DetailsListMetadata(  );
    }

}