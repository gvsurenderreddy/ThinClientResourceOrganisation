using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Configuration.Help.Edit;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.StaticContent;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Configuration.Service.Messages;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestUrl;

namespace WorkSuite.Configuration.Service.Domain.Configuration.Help.Fields.location_url
{
    [TestClass]
    public class A_location_url_mandatory
                 : ConfigurationSpecification
    {
        [TestMethod]
        public void A_location_url_not_null()
        {
            var request = new UpdateHelpRequest(){ location_url = null};
            location_url_message(request);
        }

        [TestMethod]
        public void A_location_url_not_empty()
        {
            var request = new UpdateHelpRequest() {location_url = string.Empty};
            location_url_message(request);
        }

        [TestMethod]
        public void A_location_url_white_space()
        {
            var request = new UpdateHelpRequest() {location_url = "\t"};
            location_url_message(request);
        }
        private void location_url_message(UpdateHelpRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.location_url))
            {
                var response = command.execute(request);
                response.has_errors.Should().BeTrue();
                response.messages.Should()
                    .Contain(m => m.field_name == "location_url" && m.message == ErrorMessages.error_00_0047);
                response.messages.Should()
                    .Contain(m => string.IsNullOrEmpty(m.field_name) && m.message == ErrorMessages.error_03_0018);
            }
        }

        protected override void test_setup()
        {
            base.test_setup();
            command = DependencyResolver.resolve<IUpdateHelp>();
            _fakeUrlExist = DependencyResolver.resolve<FakeUrlExistTest>();
            _fakeUrlExist.response_status=UrlExistenceTestResponse.UrlEstablished;
        }

        private IUpdateHelp command;
        private FakeUrlExistTest _fakeUrlExist;
    }
}