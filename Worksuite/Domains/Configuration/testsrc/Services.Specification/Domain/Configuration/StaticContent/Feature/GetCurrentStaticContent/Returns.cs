using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Configuration.StaticContent.GetCurrentStaticContent;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.StaticContent;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestUrl;

namespace WorkSuite.Configuration.Service.Domain.Configuration.StaticContent.Feature.GetCurrentStaticContent
{
    [TestClass]
    public class Returns:ConfigurationSpecification
    {
        [TestMethod]
        public void return_null_static_content_if_location_url_dose_not_exit()
        {
            var response = query_static_content.execute();
            response.result.Should().NotBeNull();
            response.result.location_url.Should().Be("");
        }
        [TestMethod]
        public void return_last_static_content()
        {
            var first_static_Contents = static_content_helper.add().location_url("fisrt").entity;
            var second_static_Contents = static_content_helper.add().location_url("second").entity;
            query_static_content.execute().result.location_url.Should().Be(second_static_Contents.location_url);
        }

        protected override void test_setup()
        {
            base.test_setup();
            query_static_content = DependencyResolver.resolve<IGetCurrentStaticContent>();
            static_content_helper = DependencyResolver.resolve<StaticContentHelper>();
            _fakeUrlExist = DependencyResolver.resolve<FakeUrlExistTest>();
            _fakeUrlExist.response_status=UrlExistenceTestResponse.UrlEstablished;
        }

        private StaticContentHelper static_content_helper;
        private IGetCurrentStaticContent query_static_content;
        private FakeUrlExistTest _fakeUrlExist;
    }
}