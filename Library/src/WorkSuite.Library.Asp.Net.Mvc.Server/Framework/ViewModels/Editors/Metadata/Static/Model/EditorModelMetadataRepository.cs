using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Model;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static {

    public class EditorModelMetadataRepository<S> : IEditorModelMetadataRepository<S> {


        public EditorModelMetadata<S> metadata_for () {
            Guard.IsNotNull( metadata, "metadata" );

            return metadata;
        }

        public void set_metadata ( EditorModelMetadata<S> the_metadata ) {

            Guard.IsNotNull( the_metadata, "the_metadata" );

            metadata = the_metadata;
        }

        private EditorModelMetadata<S> metadata;
    }
}