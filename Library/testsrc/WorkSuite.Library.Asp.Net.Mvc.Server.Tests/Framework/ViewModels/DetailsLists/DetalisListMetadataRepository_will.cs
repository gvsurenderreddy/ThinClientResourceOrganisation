using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Model;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.DetailsLists {

    [TestClass]
    public class DetalisListMetadataRepository_will {

        // done: implement IDetailsListMetadataRepository
        // done: return a default if the metadata has not been defined  
        // done: return the metadata if it is set

        [TestMethod]
        public void implement_IDetailsListMetadataRepository ( ) {
            

            repository.Should().BeAssignableTo<IDetailsListMetadataRepository<DetailsListModel>>(  );
        }

        [TestMethod]
        public void return_a_default_if_the_metadata_has_not_been_defined ( ) {
            
            repository.metadata_for(  ).Should(  ).NotBeNull(  );
        }

        [TestMethod]
        public void return_the_metadata_if_it_is_set ( ) {
            var metadata = new DetailsListMetadata();

            repository.set_metadata( metadata );
            
            repository.metadata_for(  ).Should().Be( metadata );
        }

        [TestInitialize]
        public void test_setup() {
            repository = new DetailsListMetadataRepository<DetailsListModel>();
            
        }

        private DetailsListMetadataRepository<DetailsListModel> repository;

    }

}