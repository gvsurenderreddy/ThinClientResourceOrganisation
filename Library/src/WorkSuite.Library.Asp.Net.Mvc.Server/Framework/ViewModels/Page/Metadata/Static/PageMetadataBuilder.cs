using System.ComponentModel.Composition;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Content;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.BreadCrumbNavigation.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Workflow.Builder;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static
{

    /// <summary>
    ///     Generic Implementation of the <see cref="IPageMetadataBuilder)"/> that uses  
    /// metadata builders to allow its's descendents to create the metadata for a particular page, 
    /// identified by the page id.
    /// </summary>
    [InheritedExport(typeof(IPageMetadataBuilder))]
    public abstract class PageMetadataBuilder
                            : IPageMetadataBuilder
    {


        /// <summary>
        ///     Builds the metadata by executing the build page model metadata as defiend in it's descendent
        /// </summary>
        /// <param name="resolver">
        ///     Resolver that is used to get the metdata builders.
        /// </param>
        public void build
                        (IDependencyResolver resolver)
        {

            Guard.IsNotNull(resolver, "resolver");

            content_repository = resolver.GetService<IContentRepository>();


            var page_model_metadata_builder_factory = Guard.IsNotNull(resolver.GetService<IPageModelMetadataBuilderFactory>(), "page_model_metadata_builder");

            var bread_crumb_navigation_metadata_builder = Guard.IsNotNull(resolver.GetService<IBreadCrumbNavigationMetadataBuilder>(), "bread_crumb_navigation_metadata_builder");

            var workflow_metadata_builder = Guard.IsNotNull(resolver.GetService<IWorkflowMetadataBuilder>(), "workflow_metadata_builder");
            
            
            build_model_metadata(page_model_metadata_builder_factory.create(page_id));

            build_bread_crumb_navigation_metadata( bread_crumb_navigation_metadata_builder );

            build_worklow_metadata(workflow_metadata_builder);


        }

        /// <summary>
        ///     provides a descendent with a method of specifying the page id that the metadata is for.
        /// </summary>
        /// <remarks>
        ///     This is different to the other view model components because pages are not created for
        /// a specific class.  This means that we can not identify the metadata base on a type and 
        /// use generics, we have to have a unique identity for each page.  
        /// </remarks>
        // Improve: Each page has it's own resources which contain the details so we may be able to use that and generic. That would be too much of a change in one go so left as an improve option (WPM).
        protected abstract string page_id
        { get; }

        /// <summary>
        ///     provides a descendent with the builder that should be used to create the
        /// page's model metadata.
        /// </summary>
        /// <param name="model_metadata_builder">
        ///     the builder is used to define/create the page's model metadata
        /// </param>
        protected abstract void build_model_metadata
                                    (IPageModelMetadataBuilder model_metadata_builder);

        
        /// <summary>
        /// Optionally provides a descendant with the bread crumb 
        /// navigation metadata builder for creating navigation trails
        /// </summary>
        protected virtual void build_bread_crumb_navigation_metadata(IBreadCrumbNavigationMetadataBuilder bread_crumb_navigation_metadata_builder)
        {

        }

        /// <summary>
        /// Allows the action destination workflows to be configured for this page
        /// </summary>
        protected virtual void build_worklow_metadata(IWorkflowMetadataBuilder builder)
        {

        }

        protected IContentRepository content_repository { get; private set; }

    }
}
