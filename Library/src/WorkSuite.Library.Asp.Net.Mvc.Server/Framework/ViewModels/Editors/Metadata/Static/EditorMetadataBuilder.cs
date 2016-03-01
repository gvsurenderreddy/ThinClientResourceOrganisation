using System.ComponentModel.Composition;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Content;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static {

    /// <summary>
    ///     Generic Implementation of the <see cref="IEditorMetadataBuilder)"/> that uses  
    /// metadata builders to allow its's descendents to define the model metadata.
    /// </summary>
    /// <typeparam name="S">
    ///     Identifies the type of editor that metadata is for. Editors are defined for 
    /// types, so when a specilised version of the generic editor builder asks for
    /// its editor's metadata it will recieve the metadata that was defined by a descendent
    /// of this class that had been specialised with the matching type.
    /// </typeparam>
    [InheritedExport(typeof(IEditorMetadataBuilder))]
    public abstract class EditorMetadataBuilder<S> 
                            : IEditorMetadataBuilder {

        // to do: refactor change the dependency resolver to be a construction dependency.

        public void build
                        ( IDependencyResolver resolver ) {

            Guard.IsNotNull( resolver, "resolver" );

            content_repository = resolver.GetService<IContentRepository>();
            
            var model_metadata_builder = resolver.GetService<IEditorModelMetadataBuilder<S>>();
            build_model_metadata( model_metadata_builder );

            var fields_metadata_builder = resolver.GetService<IEditorFieldsMetadataBuilder<S>>();
            build_field_metadata( fields_metadata_builder );

            var actions_metadata_builder = resolver.GetService<IEditorActionsMetadataBuilder<S>>();
            build_action_metadata( actions_metadata_builder );
        }

        /// <summary>
        ///     provides a descendent with the builder that should be used to create the
        /// editor's model metadata.
        /// </summary>
        /// <param name="model_metadata_builder">
        ///     the builder is used to define/create the editor's model metadata
        /// </param>
        protected abstract void build_model_metadata
                                    ( IEditorModelMetadataBuilder<S> model_metadata_builder );

        /// <summary>
        ///     provides a descendent with the builder that should be used to create the
        /// editor's fields metadata.
        /// </summary>
        /// <param name="fields_metadata_builder">
        ///     the builder is used to define/create the editor's fields metadata
        /// </param>
        protected abstract void build_field_metadata
                                    ( IEditorFieldsMetadataBuilder<S> fields_metadata_builder );


        /// <summary>
        ///     provides a descendent with the builder that should be used to create the
        /// editor's fields metadata.
        /// </summary>
        /// <param name="actions_metadata_builder">
        ///     the builder is used to define/create the editor's actions metadata
        /// </param>
        protected abstract void build_action_metadata
                                    ( IEditorActionsMetadataBuilder<S> actions_metadata_builder );

        /// <summary>
        /// provides an instance of the IContentRepository for derived instances to get content from a known key
        /// </summary>
        protected IContentRepository content_repository { get; private set; }
    }

}