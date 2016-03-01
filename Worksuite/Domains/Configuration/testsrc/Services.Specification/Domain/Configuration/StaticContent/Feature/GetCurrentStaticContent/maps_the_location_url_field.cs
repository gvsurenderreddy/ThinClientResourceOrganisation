using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Configuration.StaticContent.GetCurrentStaticContent;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.StaticContent;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Library.Service.Specification.Infrastructure;

namespace WorkSuite.Configuration.Service.Domain.Configuration.StaticContent.Feature.GetCurrentStaticContent
{
    [TestClass]
    public class maps_the_location_url_field : ConfigurationSpecification

    {
        [TestMethod]
        public void check_location_url()
        {
            var static_content = static_content_helper.add().entity;
            static_content.location_url = "http://localhost:38901/";

            var response = query_static_content.execute();
            response.has_errors.Should().BeFalse();
            response.result.location_url.Should().Be(static_content.location_url);
        }

        protected override void test_setup()
        {
            base.test_setup();
            query_static_content = DependencyResolver.resolve<IGetCurrentStaticContent>();
            static_content_helper = DependencyResolver.resolve<StaticContentHelper>();
        }

        private StaticContentHelper static_content_helper;
        private IGetCurrentStaticContent query_static_content;
    }
}