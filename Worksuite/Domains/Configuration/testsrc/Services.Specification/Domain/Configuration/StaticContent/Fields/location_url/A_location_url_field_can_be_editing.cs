using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WorkSuite.Configuration.Service.Configuration.StaticContent.Edit;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.StaticContent;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Configuration.Service.Messages;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestUrl;

namespace WorkSuite.Configuration.Service.Domain.Configuration.StaticContent.Fields.location_url
{
    [TestClass]
    public class A_location_url_field_can_be_editing
                             : ConfigurationSpecification
    {
        [TestMethod]
        public void expected_value()
        {
            var request = new UpdateStaticContentRequest
            {
                location_url = location_url_helper().location_url + "maps",
            };

            response(request);
        }
        // (WPM)  We have taken the test that checks that the location can be succesfully updated because 
        //        currently we have no way of faking the connections so we have to connect to actual 
        //        website in the unit test.
        //
        //        Once we have re-factored the connection into a separate component then we can re-introduce 
        //        this test.

        private StaticContents location_url_helper()
        {
            var static_content = static_contenct_helper
                                .add()
                                .location_url("https://maps.google.com/")
                                .entity;
            return static_content;
        }

        private void response(UpdateStaticContentRequest request)
        {
            var response = command.execute(request);
            response.has_errors.Should().BeFalse();
            static_contenct_helper.entities.Last().location_url.Should().Be(request.location_url);
        }

        private void messages(UpdateStaticContentRequest request)
        {
            var response = command.execute(request);
            response.has_errors.Should().BeFalse();
            static_contenct_helper.entities.Last().location_url.Should().Be(request.location_url);
            response.messages.Should().Contain(m => m.message == ErrorMessages.error_04_0016);
        }

        protected override void test_setup()
        {
            base.test_setup();
            command = DependencyResolver.resolve<IUpdateStaticContents>();
            static_contenct_helper = DependencyResolver.resolve<StaticContentHelper>();
            _fakeUrlExist = DependencyResolver.resolve<FakeUrlExistTest>();
            _fakeUrlExist.response_status=UrlExistenceTestResponse.UrlEstablished;
        }

        private StaticContentHelper static_contenct_helper;
        private IUpdateStaticContents command;
        private FakeUrlExistTest _fakeUrlExist;
    }
}