using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Configuration.StaticContent.Edit;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.StaticContent;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Library.Service.Specification.Infrastructure;

namespace WorkSuite.Configuration.Service.Domain.Configuration.StaticContent.Feature.Update
{
    [TestClass]
    public class GetCurrentUpdate
                 :ConfigurationSpecification
    {
        [TestMethod]
        public void get_last_location_url_in_edit_command()
        {
            var static_content = static_content_helper
                .add()
                .location_url("http://localhost:38901/")
                .entity;

            var response = command.execute();

            response.location_url.Should().Be(static_content.location_url);
        }

        protected override void test_setup()
        {
            base.test_setup();
            command = DependencyResolver.resolve<IGetUpdateStaticContentRequest>();
            static_content_helper = DependencyResolver.resolve<StaticContentHelper>();
           
        }

        private StaticContentHelper static_content_helper;
        private IGetUpdateStaticContentRequest command;
       
    }
}