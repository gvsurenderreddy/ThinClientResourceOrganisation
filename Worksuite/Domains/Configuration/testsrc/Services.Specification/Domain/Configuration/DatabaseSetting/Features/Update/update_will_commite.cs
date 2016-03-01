using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Configuration.Service.Configuration.DatabaseSettings.Edit;
using WorkSuite.Configuration.Service.Helpers.Domain.Configuration.DatabaseSetting;
using WorkSuite.Configuration.Service.Helpers.SpecificationTemplates.Base;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestConnections;

namespace WorkSuite.Configuration.Service.Domain.Configuration.DatabaseSetting.Features.Update
{
    [TestClass]
    public class update_will_commite:ConfigurationSpecification
    {
        [TestMethod]
        public void command_commited_changes()
        {
            var databaseSettings = database_setting_helper
                                       .add()
                                       .connection_string
                                       ("Data Source=localhost;Initial Catalog=WORKSuite5_Experimental;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework")
                                       .entity;
            var request = new UpdateDatabaseSettingRequest
            {
                connection_string = databaseSettings.connection_string 
            };
            command.execute(request);

            unit_of_work.commit_was_called.Should().BeTrue();

        }
        protected override void test_setup()
        {
            base.test_setup();
            database_setting_helper = DependencyResolver.resolve<DatabaseSettingHelper>();
            command = DependencyResolver.resolve<IUpdateDatabaseSettings>();
            unit_of_work = DependencyResolver.resolve<FakeUnitOfWork>();
           

        }

        private DatabaseSettingHelper database_setting_helper;
        private IUpdateDatabaseSettings command;
        private FakeUnitOfWork unit_of_work;
    }
}