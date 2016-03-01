using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Configuration.Help.GetCurrentHelpUrl;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.Help;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.StaticContent;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestUrl;

namespace WorkSuite.Configuration.Service.Domain.Configuration.Help.Feature.GetCurrentHelpUrl
{
    [TestClass]
    public class Returns :ConfigurationSpecification
    {
        [TestMethod]
        public void return_null_Help_url_if_url_does_not_exist()
        {
            var response = query_Help_url.execute();
            response.result.Should().NotBeNull();
            response.result.location_url.Should().Be("");
        }

        [TestMethod]
        public void return_last_static_content()
        {
            var first_help_url = help_url_helper.add().location_url("fisrt").entity;
            var second_help_url = help_url_helper.add().location_url("second").entity;
            query_Help_url.execute().result.location_url.Should().Be(second_help_url.location_url);
        }

        protected override void test_setup()
        {
            base.test_setup();
            query_Help_url = DependencyResolver.resolve<IGetCurrentHelpUrl>();
            help_url_helper = DependencyResolver.resolve<HelpUrlHelper>();
            _fakeUrlExist = DependencyResolver.resolve<FakeUrlExistTest>();
            _fakeUrlExist.response_status=UrlExistenceTestResponse.UrlEstablished;
        }

        private HelpUrlHelper help_url_helper;
        private IGetCurrentHelpUrl query_Help_url;
        private FakeUrlExistTest _fakeUrlExist;
    }
}