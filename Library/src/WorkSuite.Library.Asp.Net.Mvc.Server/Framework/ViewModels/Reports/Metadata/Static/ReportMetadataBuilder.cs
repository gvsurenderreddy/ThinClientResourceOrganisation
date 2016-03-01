using System.ComponentModel.Composition;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Content;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static {

    /// <summary>
    ///     Generic Implementation of the <see cref="IReportMetadataBuilder)"/> that uses  
    /// metadata builders to allow its's descendents to define the model metadata.
    /// </summary>
    /// <typeparam name="S">
    ///     Identifies the type of report that metadata is for. Reports are defined for 
    /// types, so when a specilised version of the generic report builder asks for
    /// its report's metadata it will recieve the metadata that was defined by a descendent
    /// of this class that had been specialised with the matching type.
    /// </typeparam>
    [InheritedExport(typeof(IReportMetadataBuilder))]
    public abstract class ReportMetadataBuilder<S> 
                            : IReportMetadataBuilder {

        /// <summary>
        ///     Builds the metadata by executing creating the reports model, fields and actions
        /// metadata as defiend in it's specilised descendent
        /// </summary>
        /// <param name="resolver">
        ///     Resolver that is used to get the metdata builders.
        /// </param>
        public void build 
                        ( IDependencyResolver resolver ) {

            Guard.IsNotNull( resolver, "resolver" );

            content_repository = resolver.GetService<IContentRepository>();

            var model_metadata_builder = resolver.GetService<IReportModelMetadataBuilder<S>>();
            build_model_metadata( model_metadata_builder );

            var fields_metadata_builder = resolver.GetService<IReportFieldsMetadataBuilder<S>>();
            build_field_metadata( fields_metadata_builder );

            var actions_metadata_builder = resolver.GetService<IReportActionsMetadataBuilder<S>>();
            build_action_metadata( actions_metadata_builder );

        }

        /// <summary>
        ///     provides a descendent with the builder that should be used to create the
        /// report's model metadata.
        /// </summary>
        /// <param name="model_metadata_builder">
        ///     the builder is used to define/create the report's model metadata
        /// </param>
        protected abstract void build_model_metadata 
                                    ( IReportModelMetadataBuilder<S> model_metadata_builder );

        /// <summary>
        ///     provides a descendent with the builder that should be used to create the
        /// report's fields metadata.
        /// </summary>
        /// <param name="fields_metadata_builder">
        ///     the builder is used to define/create the report's fields metadata
        /// </param>
        protected abstract void build_field_metadata
                                    ( IReportFieldsMetadataBuilder<S> fields_metadata_builder );

        /// <summary>
        ///     provides a descendent with the builder that should be used to create the
        /// report's fields metadata.
        /// </summary>
        /// <param name="actions_metadata_builder">
        ///     the builder is used to define/create the report's actions metadata
        /// </param>
        protected abstract void build_action_metadata 
                                    ( IReportActionsMetadataBuilder<S> actions_metadata_builder );

        /// <summary>
        /// provides an instance of the IContentRepository for derived instances to get content from a known key
        /// </summary>
        protected IContentRepository content_repository { get; private set; }
    }

}