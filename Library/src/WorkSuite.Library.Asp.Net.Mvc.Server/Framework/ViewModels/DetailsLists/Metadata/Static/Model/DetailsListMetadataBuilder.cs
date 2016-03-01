using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Model;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Model {

    public class DetailsListMetadataBuilder<S> : IDetailsListMetadataBuilder<S> {

        public IDetailsListMetadataBuilder<S> title ( string value ) {
            metadata.title = value;

            return this;
        }

        public IDetailsListMetadataBuilder<S> description(string value)
        {
            metadata.description = value;

            return this;
        }

        public IDetailsListMetadataBuilder<S> id ( string value ) {
            metadata.id = value;

            return this;
        }

        public IDetailsListMetadataBuilder<S> presenter_id ( string value ) {
            metadata.presenter_id = value;

            return this;
        }

        public DetailsListMetadataBuilder 
            ( DetailsListMetadataRepository<S> repository ) {
            
            Guard.IsNotNull( repository,"repository" );
            
            repository.set_metadata( metadata );
        }


        readonly DetailsListMetadata metadata = new DetailsListMetadata(  );



        public IDetailsListMetadataBuilder<S> is_sortable()
        {
            metadata.is_sortable = true;
            return this;
        }
    }

}