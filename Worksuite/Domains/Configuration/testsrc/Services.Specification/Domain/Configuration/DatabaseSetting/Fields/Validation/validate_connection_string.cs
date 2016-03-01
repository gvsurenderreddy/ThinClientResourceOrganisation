using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Configuration.DatabaseSettings.Edit;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.DatabaseSetting;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Configuration.Service.Messages;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestConnections;

namespace WorkSuite.Configuration.Service.Domain.Configuration.DatabaseSetting.Fields.Validation
{
    [TestClass]
    public class validate_connection_string :ConfigurationSpecification
    {
        [TestMethod]
        public void check_connection_string_is_validate()
        {
            const string connection_string = " A connection String ";

            var request = new UpdateDatabaseSettingRequest
            {
                connection_string = connection_string
            };
            var response = command.execute(request);

            response.has_errors.Should().BeFalse();
            response.messages.Should().Contain(m => m.message == ErrorMessages.error_04_0013);
        }
        
        protected override void test_setup()
        {
            base.test_setup();
            command = DependencyResolver.resolve<IUpdateDatabaseSettings>();
            check_connection_string = DependencyResolver.resolve<ValidateConnectionString>();
            check_connection_string.status = DatabaseConnectionTestResponse.ConnectionEstablished;

        }
        private IUpdateDatabaseSettings command;
        private ValidateConnectionString check_connection_string;
    }
}