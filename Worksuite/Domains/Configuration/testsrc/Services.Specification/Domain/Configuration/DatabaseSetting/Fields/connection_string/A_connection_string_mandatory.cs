using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Configuration.DatabaseSettings.Edit;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.DatabaseSetting;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Configuration.Service.Messages;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestConnections;

namespace WorkSuite.Configuration.Service.Domain.Configuration.DatabaseSetting.Fields.connection_string
{
    
    public class A_connection_string_mandatory
    {
        
        [TestClass]
        public class verify_on_update 
                        : ConfigurationSpecification {


            [TestMethod]
            public void not_null()
            {
                var request = new UpdateDatabaseSettingRequest { connection_string = null };
                connection_string_messages(request);
            }

            [TestMethod]
            public void not_empty()
            {
                var request = new UpdateDatabaseSettingRequest { connection_string = string.Empty };
                connection_string_messages(request);
            }


            [TestMethod]
            public void not_white_space()
            {
                var request = new UpdateDatabaseSettingRequest { connection_string = "\t" };
                connection_string_messages(request);
            }

            private void connection_string_messages(UpdateDatabaseSettingRequest request)
            {
                var response = command.execute(request);

                response.has_errors.Should().BeTrue();
                response.messages.Should().Contain(m => m.field_name == "connection_string" && m.message == ErrorMessages.error_00_0032);
                response.messages.Should().Contain(m => string.IsNullOrEmpty(m.field_name) && m.message == ErrorMessages.error_04_0001);
            }

            protected override void test_setup()
            {
                base.test_setup();

                command = DependencyResolver.resolve<IUpdateDatabaseSettings>();
                fake_database_connection_test = DependencyResolver.resolve<FakeDatabaseConnectionTest>();
                fake_database_connection_test.response_status = DatabaseConnectionTestResponse.ConnectionEstablished;
            }

            private IUpdateDatabaseSettings command;
            private FakeDatabaseConnectionTest fake_database_connection_test;
            }         
    }
}