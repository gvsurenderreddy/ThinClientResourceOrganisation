using System.ComponentModel.Composition;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Content;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Model;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static
{


    /// <summary>
    ///     Generic Implementation of the <see cref="IDetailsListMetadataBuilder)"/> that uses  
    /// metadata builders to allow its's descendents to define the model metadata.
    /// </summary>
    /// <typeparam name="S">
    ///     Identifies the type of DetailsList that metadata is for. DetailsList are defined for 
    /// types, so when a specilised version of the generic DetailsList builder asks for
    /// its DetailsList's metadata it will recieve the metadata that was defined by a descendent
    /// of this class that had been specialised with the matching type.
    /// </typeparam>
    [InheritedExport(typeof(IDetailsListMetadataBuilder))]
    public abstract class DetailsListMetadataBuilder<S>
                            : IDetailsListMetadataBuilder
    {

        /// <summary>
        ///     Builds the metadata by creating the DetailsList model and actions
        /// metadata as defiend in it's specilised descendent
        /// </summary>
        /// <param name="resolver">
        ///     Resolver that is used to get the metdata builders.
        /// </param>
        public void build
                        (IDependencyResolver resolver)
        {

            Guard.IsNotNull(resolver, "resolver");

            content_repository = resolver.GetService<IContentRepository>();

            Guard.IsNotNull(content_repository, "content_repository");

            var list_metadata_builder = resolver.GetService<IDetailsListMetadataBuilder<S>>();
            build_list_metadata(list_metadata_builder);

            var list_actions_metadata_builder = resolver.GetService<IDetailsListActionsMetadataBuilder<S>>();
            build_list_actions_metadata(list_actions_metadata_builder);

        }

        /// <summary>
        ///     provides a descendent with the builder that should be used to create the
        /// DetailsList's model metadata.
        /// </summary>
        /// <param name="builder">
        ///     the builder is used to define/create the DetailsList's model metadata
        /// </param>
        protected abstract void build_list_metadata
                                    (IDetailsListMetadataBuilder<S> builder);


        /// <summary>
        ///     provides a descendent with the builder that should be used to create the
        /// DetailsList's fields metadata.
        /// </summary>
        /// <param name="builder">
        ///     the builder is used to define/create the DetailsList's actions metadata
        /// </param>
        protected abstract void build_list_actions_metadata
                                    (IDetailsListActionsMetadataBuilder<S> builder);

        protected IContentRepository content_repository { get; private set; }

    }

}