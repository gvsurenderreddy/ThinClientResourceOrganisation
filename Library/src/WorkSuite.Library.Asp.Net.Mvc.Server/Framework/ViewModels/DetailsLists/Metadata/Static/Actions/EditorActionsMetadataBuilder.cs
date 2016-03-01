using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Actions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Configuration {

    public class EditorActionsMetadataBuilder<S> : IEditorActionsMetadataBuilder<S> {

        public IEditorActionMetadataBuilder<S> add_action<C> () where C : CommonActionDefinition, new() {

            var common_properties = new C();
            var result = new EditorActionMetadataBuilder<S>( m  => repository.Add( m ) );

            // use the builder to set up the metadata
            result.type( common_properties.classification );
            result.title( common_properties.title );

            return result;
        }


        public IEditorActionMetadataBuilder<S> add_action( string action_type ) {

            var result = new EditorActionMetadataBuilder<S>( m  => repository.Add( m ) );

            // use the builder to set up the metadata
            result.type( action_type );

            return result;
        }


        public EditorActionsMetadataBuilder 
            ( EditorActionMetadataRepository<S> the_repository ) {

            Guard.IsNotNull( the_repository, "the_repository" );

            repository = the_repository;
        }
        
        private readonly EditorActionMetadataRepository<S> repository;
    }
}