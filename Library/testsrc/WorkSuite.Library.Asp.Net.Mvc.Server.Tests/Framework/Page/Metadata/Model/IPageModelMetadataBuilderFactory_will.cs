using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static.Model;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.Page.Metadata.Model {
    
    [TestClass]
    public class IPageModelMetadataBuilderFactory_will {
         
        // create a page model metadata builder that will configure the pages metadata

        [TestMethod]
        public void create_a_page_model_metadata_builder_that_will_configure_the_pages_metadata () {

            var repository = new PageModelMetadataRepository();
            var factory = new PageModelMetadataBuilderFactory( repository );

            factory.create( "APageId" )
                   .title( "ATitle" )
                   ;

            repository.metadata_for( "APageId" ).title.Should().Be( "ATitle" );
        }
    }
}