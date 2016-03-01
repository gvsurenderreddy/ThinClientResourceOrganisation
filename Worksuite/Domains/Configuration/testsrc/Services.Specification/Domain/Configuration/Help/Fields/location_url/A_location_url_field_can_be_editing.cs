using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WorkSuite.Configuration.Service.Configuration.Help.Edit;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.Help;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.StaticContent;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Configuration.Service.Messages;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestUrl;

namespace WorkSuite.Configuration.Service.Domain.Configuration.Help.Fields.location_url
{
    [TestClass]
    public class A_location_url_field_can_be_editing 
                 : ConfigurationSpecification
    {
        [TestMethod]
        public void expected_value()
        {
            var request = new UpdateHelpRequest()
            {
                location_url = location_url_helper().location_url + "maps"
            };
            response(request);
        }

        private HelpUrls location_url_helper()
        {
            var help = help_url_helper
                                .add()
                                .location_url("https://maps.google.com/")
                                .entity;
            return help;
        }

        private void response(UpdateHelpRequest request)
        {
            var response = command.execute(request);
            response.has_errors.Should().BeFalse();
            help_url_helper.entities.Last().location_url.Should().Be(request.location_url);
        }

        private void messages(UpdateHelpRequest request)
        {
            var response = command.execute(request);
            response.has_errors.Should().BeFalse();
            help_url_helper.entities.Last().location_url.Should().Be(request.location_url);
            response.messages.Should().Contain(m => m.message == ErrorMessages.error_04_0022);
        }
        protected override void test_setup()
        {
            base.test_setup();
           help_url_helper = DependencyResolver.resolve<HelpUrlHelper>();
            command = DependencyResolver.resolve<IUpdateHelp>();
            _fakeUrlExist = DependencyResolver.resolve<FakeUrlExistTest>();
            _fakeUrlExist.response_status=UrlExistenceTestResponse.UrlEstablished;
        }

        private HelpUrlHelper help_url_helper;
        private IUpdateHelp command;
        private FakeUrlExistTest _fakeUrlExist;
    }
}