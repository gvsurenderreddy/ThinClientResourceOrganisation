using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Model;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static.Model {

    /// <summary>
    ///     Creates a Page model metadata builder for a page.  This is needed 
    /// because pages do not have a specific page class and are identified by
    /// an id. As such we can not just resolve the correct metadata repository
    /// we have to get metadata from a single repository that holds all the
    ///  page model metadata indexed by page id and then pass that into the builder. 
    /// </summary>
    public class PageModelMetadataBuilderFactory 
                    : IPageModelMetadataBuilderFactory {


        public IPageModelMetadataBuilder create 
                                            ( string page_id ) {

            return new PageModelMetadataBuilder( repository.metadata_for( page_id ) );
        }


        public PageModelMetadataBuilderFactory 
                    ( IPageModelMetadataRepository the_repository ) {

            repository = Guard.IsNotNull( the_repository, "the_repository" );
        }

        // repository used to get metadata needed to create the builder
        private readonly IPageModelMetadataRepository repository;
    }
}