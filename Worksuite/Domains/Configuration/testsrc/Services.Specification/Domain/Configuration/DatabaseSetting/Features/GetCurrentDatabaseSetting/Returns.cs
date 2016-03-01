using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Configuration.DatabaseSettings.GetCurrentDatabaseSetting;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.DatabaseSetting;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestConnections;

namespace WorkSuite.Configuration.Service.Domain.Configuration.DatabaseSetting.Features.GetCurrentDatabaseSetting
{
    [TestClass]
    public class Returns :ConfigurationSpecification
    {
        [TestMethod]
        public void return_null_database_setting_if_connection_string_does_not_exist()
        {
         
            var response = query.execute();
            response.result.Should().NotBeNull();
            response.result.connection_string.Should().Be("");
        }

        [TestMethod]
        public void current_database_settings_are_the_settings_with_the_highest_id()
        {
            
            var first_setting = helper.add().connection_string("first").entity;
            var second_setting = helper.add().connection_string("second").entity;

            query.execute().result.connection_string.Should().Be(second_setting.connection_string);
        }



        protected override void test_setup()
        {
            base.test_setup();
            helper = DependencyResolver.resolve<DatabaseSettingHelper>();
            query = DependencyResolver.resolve<IGetCurrentDatabaseSetting>();
            fake_database_connection_test = DependencyResolver.resolve<FakeDatabaseConnectionTest>();
            fake_database_connection_test.response_status = DatabaseConnectionTestResponse.ConnectionEstablished;
        }

        private DatabaseSettingHelper helper;
        private IGetCurrentDatabaseSetting query;
        private FakeDatabaseConnectionTest fake_database_connection_test;
    }
}