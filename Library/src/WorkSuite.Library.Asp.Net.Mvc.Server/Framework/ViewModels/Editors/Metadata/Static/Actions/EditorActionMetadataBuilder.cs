using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.ActionMetadataBuilder;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static {
    
    public class EditorActionMetadataBuilder<S> 
        : RoutedActionMetadataBuilder<S,IEditorActionMetadataBuilder<S>,EditorActionMetadata<S>>
        , IEditorActionMetadataBuilder<S> {

        public EditorActionMetadataBuilder
            ( Action<EditorActionMetadata<S>> add_to_repository ) : base( add_to_repository) {}
        
        protected override IEditorActionMetadataBuilder<S> builder {
            get { return this; }
        }
    }
}