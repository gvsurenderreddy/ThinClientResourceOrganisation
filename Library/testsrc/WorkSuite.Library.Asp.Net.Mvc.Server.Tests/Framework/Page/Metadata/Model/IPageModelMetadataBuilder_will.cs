using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Model;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.Page.Metadata.Model {

    [TestClass]
    public class IPageModelMetadataBuilder_will {
         
        [TestMethod]
        public void implement_IPageModelMetadataBuilder() {

            builder.Should().BeAssignableTo<IPageModelMetadataBuilder>();
        }

        [TestMethod]
        public void allow_the_page_title_to_be_set () {
            const string page_title = "ATitle";

            builder.title( page_title );
            metadata.title.Should().Be( page_title );
        }

        [TestMethod]
        public void returns_an_instance_of_the_builder_after_setting_the_page_title () {
            const string page_title = "ATitle";

            builder.title( page_title ).Should().NotBeNull();
        }

        [TestInitialize]
        public void before_each_test () {
            repository = new PageModelMetadataRepository();
            builder = new PageModelMetadataBuilder( repository.metadata_for( page_id ) );
        }

        private PageModelMetatdata metadata {
            get { return repository.metadata_for( page_id ); }
        }

        private const string page_id = "APage";
        private IPageModelMetadataBuilder builder;
        private IPageModelMetadataRepository repository;
    }
}