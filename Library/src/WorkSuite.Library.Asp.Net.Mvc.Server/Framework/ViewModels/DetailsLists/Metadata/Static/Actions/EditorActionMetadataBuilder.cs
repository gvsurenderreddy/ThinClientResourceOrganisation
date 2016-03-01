using System;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Configuration {
    
    public class EditorActionMetadataBuilder<S> : IEditorActionMetadataBuilder<S> {

        public EditorActionMetadataBuilder 
            ( Action<EditorActionMetadata<S>> action ) {

            Guard.IsNotNull( action, "action" );

            metadata = new EditorActionMetadata<S> {};

            action( metadata );
        }

        public IEditorActionMetadataBuilder<S> id ( string value ) {
            metadata.id = value;

            return this;
        }

        public IEditorActionMetadataBuilder<S> type ( string value ) {
            metadata.type = value;

            return this;
        }

        public IEditorActionMetadataBuilder<S> title ( string value ) {
            metadata.title = value;

            return this;
        }

        public IEditorActionMetadataBuilder<S> route_parameter_factory ( Func<S, object> value ) {

            metadata.route_parameter_factory = value;

            return this;
        }

        private readonly EditorActionMetadata<S> metadata;
    }
}