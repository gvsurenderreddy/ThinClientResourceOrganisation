using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Configuration.Help.GetCurrentHelpUrl;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.Help;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Library.Service.Specification.Infrastructure;

namespace WorkSuite.Configuration.Service.Domain.Configuration.Help.Feature.GetCurrentHelpUrl
{
    [TestClass]
    public class maps_the_location_url_field 
                 : ConfigurationSpecification
    {
        [TestMethod]
        public void check_url()
        {
            var help_url = help_url_helper.add().entity;
            help_url.location_url = "http://localhost:38901/";

            var response = query_Help_url.execute();
            response.has_errors.Should().BeFalse();
            response.result.location_url.Should().Be(help_url.location_url);
        }

        protected override void test_setup()
        {
            base.test_setup();
            query_Help_url = DependencyResolver.resolve<IGetCurrentHelpUrl>();
            help_url_helper = DependencyResolver.resolve<HelpUrlHelper>();
        }

        private HelpUrlHelper help_url_helper;
        private IGetCurrentHelpUrl query_Help_url;
    }
}