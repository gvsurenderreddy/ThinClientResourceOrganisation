using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Configuration.StaticContent.Edit;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.StaticContent;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Configuration.Service.Messages;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestUrl;

namespace WorkSuite.Configuration.Service.Domain.Configuration.StaticContent.Fields.location_url
{
    [TestClass]
    public class A_location_url_mandatory
                     : ConfigurationSpecification
    {

        [TestMethod]
        public void A_location_url_not_null()
        {
            var request = new UpdateStaticContentRequest() { location_url = null };
            location_url_messages(request);
        }

        [TestMethod]
        public void A_location_url_not_empty()
        {
            var request = new UpdateStaticContentRequest() { location_url = string.Empty };
            location_url_messages(request);
        }

        [TestMethod]
        public void A_location_url_white_space()
        {
            var request = new UpdateStaticContentRequest() { location_url = "\t" };
            location_url_messages(request);
        }


        private void location_url_messages(UpdateStaticContentRequest updateStaticContentRequest)
        {
            if (string.IsNullOrWhiteSpace(updateStaticContentRequest.location_url))
            {
                var response = command.execute(updateStaticContentRequest);

                response.has_errors.Should().BeTrue();
                response.messages.Should().Contain(m => m.field_name == "location_url" && m.message == ErrorMessages.error_00_0034);
                response.messages.Should().Contain(m => string.IsNullOrEmpty(m.field_name) && m.message == ErrorMessages.error_03_0013);
            }

        }

        protected override void test_setup()
        {
            base.test_setup();
            command = DependencyResolver.resolve<IUpdateStaticContents>();
            _fakeUrlExist = DependencyResolver.resolve<FakeUrlExistTest>();
            _fakeUrlExist.response_status = UrlExistenceTestResponse.UrlEstablished;
        }

        private IUpdateStaticContents command;
        private FakeUrlExistTest _fakeUrlExist;
    }
}