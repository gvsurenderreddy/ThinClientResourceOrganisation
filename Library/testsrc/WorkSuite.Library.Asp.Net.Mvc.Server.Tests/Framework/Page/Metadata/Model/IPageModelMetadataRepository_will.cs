using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Model;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.Page.Metadata.Model {

    [TestClass]
    public class IPageModelMetadataRepository_will {


        [TestMethod]
        public void return_the_metadata_for_the_specified_page () {

            repository.metadata_for( "APageID" ).Should().NotBeNull();
        }

        [TestMethod]
        public void always_returns_the_same_metadata_for_a_page () {

            repository.metadata_for( "APageID" ).Should().Be( repository.metadata_for( "APageID" ) );
        }

        [TestMethod]
        public void the_title_default_to_the_empty_string () {

            repository.metadata_for( "APageID" ).title.Should().BeEmpty(  );
        }

        [TestInitialize]
        public void before_each_test () {
            repository = new PageModelMetadataRepository();
        }

        private IPageModelMetadataRepository repository;

    }
}