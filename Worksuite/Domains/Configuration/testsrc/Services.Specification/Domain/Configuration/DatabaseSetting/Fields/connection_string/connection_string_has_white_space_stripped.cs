using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Configuration.DatabaseSettings.Edit;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.DatabaseSetting;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestConnections;

namespace WorkSuite.Configuration.Service.Domain.Configuration.DatabaseSetting.Fields.connection_string
{
    [TestClass]
    public class connection_string_has_white_space_stripped:ConfigurationSpecification
    {
        [TestMethod]
        public void connection_string_does_not_have_white_space_at_start_and_end_on_update()
        {
           fake_database_connection_test.response_status = DatabaseConnectionTestResponse.ConnectionEstablished;
            var request = new UpdateDatabaseSettingRequest()
            {
                connection_string = "   Data Source=localhost;Initial Catalog=WORKSuite5_Experimental;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework   ",
            };
            var response = command.execute(request);


            database_setting_helper.entities.Last().connection_string.Should().Be(request.connection_string.Trim());
            response.has_errors.Should().BeFalse();
        }
        protected override void test_setup()
        {
            base.test_setup();
            database_setting_helper = DependencyResolver.resolve<DatabaseSettingHelper>();
            command = DependencyResolver.resolve<IUpdateDatabaseSettings>();
           fake_database_connection_test = DependencyResolver.resolve<FakeDatabaseConnectionTest>();
           
        }
        private DatabaseSettingHelper database_setting_helper;
        private IUpdateDatabaseSettings command;
        private FakeDatabaseConnectionTest fake_database_connection_test;
    }
}