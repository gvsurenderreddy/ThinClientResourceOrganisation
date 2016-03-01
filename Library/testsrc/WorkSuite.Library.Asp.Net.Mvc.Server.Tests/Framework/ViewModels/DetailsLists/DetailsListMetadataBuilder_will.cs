using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Metadata.Static.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists.Model;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.DetailsLists {

    [TestClass]
    public class DetailsListMetadataBuilder_will {

        // done: implement IDetailsMetadataBuilder 
        // done: allow the title to be set 
        // do do: allow the id to be set


        [TestMethod]
        public void implement_IDetailsMetadataBuilder ( ) {
            
            builder.Should(  ).BeAssignableTo<IDetailsListMetadataBuilder<DetailsListModel>>(  );
        }

        [TestMethod]
        public void allow_the_title_to_be_set ( ) {
            
            builder.title(  "A Title" );

            metadata.title.Should(  ).Be( "A Title" );
        }

        [TestMethod]
        public void allow_the_id_to_be_set ( ) {

            builder.id( "An Id" );

            metadata.id.Should(  ).Be( "An Id" );            
        }

        [TestMethod]
        public void allow_the_presenter_id_to_be_set ( ) {

            builder.presenter_id( "A presenter Id" );

            metadata.presenter_id.Should(  ).Be( "A presenter Id" );            
        }



        [TestInitialize]
        public void test_setup () {
            // This is a slight violation of Unit testing as I have not faked the
            // the repository but as the builders sole purpose is to populate the 
            // repositories metadata it struck me as making more work than it
            // was worth to fake out ther repository as I was going to have to 
            // change the repository interface.  Really I should change the repository
            // interface to have a metadata property that can be written as well as read.
            repository = new DetailsListMetadataRepository<DetailsListModel>(  );
            builder = new DetailsListMetadataBuilder<DetailsListModel>( repository );
        }

        private DetailsListMetadata metadata {
            get {
                return repository.metadata_for(  );
            }
        }
        private DetailsListMetadataRepository<DetailsListModel> repository;
        private DetailsListMetadataBuilder<DetailsListModel> builder;
 
    }

}