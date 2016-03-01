using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Model;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static {

    public class EditorModelMetadataBuilder<S> : IEditorModelMetadataBuilder<S> {

        public IEditorModelMetadataBuilder<S> id ( Func<S,string> value ) {
            metadata.id = value;

            return this;
        }

        public IEditorModelMetadataBuilder<S> description(string value)
        {
            metadata.description = value;

            return this;
        }


        public IEditorModelMetadataBuilder<S> id ( string value ) {
            metadata.id = m => value;

            return this;
        }

        public IEditorModelMetadataBuilder<S> title ( string value ) {

            return title( m => value);
        }

        public IEditorModelMetadataBuilder<S> title( Func<S,string> value) {

            metadata.title = value;
            return this;
        }
        

        public IEditorModelMetadataBuilder<S> field_id_extension ( Func<S, string> genrator ) {
            metadata.field_id_extension = genrator;

            return this;
        }
       

        public EditorModelMetadataBuilder ( EditorModelMetadataRepository<S> repository ) {

            Guard.IsNotNull( repository, "repository" );

            metadata = new EditorModelMetadata<S> {
                id = m => string.Empty ,
                title = m => string.Empty,
            };

            repository.set_metadata( metadata );
        }

        private readonly EditorModelMetadata<S> metadata;
    }
}