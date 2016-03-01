using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.ActionsMetadataBuilder;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static {

    public class EditorActionsMetadataBuilder<S>
            : RoutedActionsMetadataBuilder<S,IEditorActionMetadataBuilder<S>>
            , IEditorActionsMetadataBuilder<S> {

        public EditorActionsMetadataBuilder 
            ( EditorActionMetadataRepository<S> the_repository ) {

            Guard.IsNotNull( the_repository, "the_repository" );
            
            repository = the_repository;
        }

        protected override IEditorActionMetadataBuilder<S> create_action_builder ( ) {
            return new EditorActionMetadataBuilder<S>( repository.Add  );
        }

        private readonly EditorActionMetadataRepository<S> repository;

    }
}