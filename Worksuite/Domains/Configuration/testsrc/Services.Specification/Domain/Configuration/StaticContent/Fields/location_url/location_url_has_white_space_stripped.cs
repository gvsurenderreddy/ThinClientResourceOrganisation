using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Configuration.StaticContent.Edit;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.StaticContent;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestUrl;

namespace WorkSuite.Configuration.Service.Domain.Configuration.StaticContent.Fields.location_url
{
    [TestClass]
    public class location_url_has_white_space_stripped
                    :ConfigurationSpecification
    {
        [TestMethod]
        public void url_does_not_have_white_space_at_start_and_end_on_update()
        {
            _fakUrlExistTest.response_status=UrlExistenceTestResponse.UrlEstablished;
            var request = new UpdateStaticContentRequest
            {
                location_url = "  https://www.google.co.uk/  "
            };

            var response = command.execute(request);

            static_contant_helper.entities.Last().location_url.Should().Be(request.location_url.Trim());
            response.has_errors.Should().BeFalse();
        }

        protected override void test_setup()
        {
            base.test_setup();
            command = DependencyResolver.resolve<IUpdateStaticContents>();
            static_contant_helper = DependencyResolver.resolve<StaticContentHelper>();
            _fakUrlExistTest = DependencyResolver.resolve<FakeUrlExistTest>();
        }

        private StaticContentHelper static_contant_helper;
        private IUpdateStaticContents command;
        private FakeUrlExistTest _fakUrlExistTest;
    }
}