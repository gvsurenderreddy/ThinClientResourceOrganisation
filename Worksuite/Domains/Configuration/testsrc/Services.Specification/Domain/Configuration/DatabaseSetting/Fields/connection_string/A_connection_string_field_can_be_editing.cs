using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WorkSuite.Configuration.Service.Configuration.DatabaseSettings.Edit;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.DatabaseSetting;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Configuration.Service.Messages;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestConnections;

namespace WorkSuite.Configuration.Service.Domain.Configuration.DatabaseSetting.Fields.connection_string
{
    [TestClass]
    public class A_connection_string_field_can_be_editing:ConfigurationSpecification
    {
        [TestMethod]
        public void set_expected_value()
        {            
            var request = new UpdateDatabaseSettingRequest {
                connection_string = helper().connection_string 
            };

            response(request);
        }

        [TestMethod]
        public void A_connection_string_field_can_be_editing_succesfully()
        {              
            var request = new UpdateDatabaseSettingRequest {
                connection_string = helper().connection_string 
                                   
            };
            response(request);
            messages(request);
        }

        private DatabaseSettings helper()
        {
            var database_Settings = database_setting_helper
                                     .add()
                                     .connection_string
                                     ("Data Source=localhost;Initial Catalog=WORKSuite5_Experimental;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework")
                                     .entity;
            return database_Settings;
        }

        private void response(UpdateDatabaseSettingRequest request)
        {
            var response = command.execute(request);
            response.has_errors.Should().BeFalse();
            database_setting_helper.entities.Last().connection_string.Should().Be(request.connection_string);
        }

        private void messages(UpdateDatabaseSettingRequest request)
        {
            var response = command.execute(request);
            response.has_errors.Should().BeFalse();
            database_setting_helper.entities.Last().connection_string.Should().Be(request.connection_string);
            response.messages.Should().Contain(m => m.message == ErrorMessages.error_04_0013);
        }

        protected override void test_setup()
        {
            base.test_setup();
            database_setting_helper = DependencyResolver.resolve<DatabaseSettingHelper>();
            command = DependencyResolver.resolve<IUpdateDatabaseSettings>();

          fake_database_connection_test = DependencyResolver.resolve<FakeDatabaseConnectionTest>();
           fake_database_connection_test.response_status = DatabaseConnectionTestResponse.ConnectionEstablished;
        }

        private DatabaseSettingHelper database_setting_helper;
        private IUpdateDatabaseSettings command;
       private FakeDatabaseConnectionTest fake_database_connection_test;
    }
}