using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Model;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static.Model {


    /// <summary>
    ///     Implementation of <see cref="IPageModelMetadataBuilder"/> that loads the data into 
    /// the repository.
    /// </summary>
    public class PageModelMetadataBuilder
                    : IPageModelMetadataBuilder {

        /// <inheritdoc/>
        public IPageModelMetadataBuilder title
                                            ( string value ) {

            metadata.title = value;

            return this;
        }


        public PageModelMetadataBuilder
                ( PageModelMetatdata the_metadata ) {

            metadata = Guard.IsNotNull( the_metadata, "the_metadata" );
        }

        // metadata that is updated, it is passed into the constructor
        private readonly PageModelMetatdata metadata;
    }
}