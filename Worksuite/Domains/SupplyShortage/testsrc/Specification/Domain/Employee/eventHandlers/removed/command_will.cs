using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Domain.Specification;
using WTS.WorkSuite.SupplyShortage.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.SupplyShortage.Services.Domain.Employee.eventHandlers.removed
{
    [TestClass]
    public class command_will : CommandCommitedChangesSpecification<SupplyShortagesTestBootstrap, EmployeeRemovedFixture>
    {
        public command_will()
            : base(

                arrange:
                    (fixture) => { },

                execute:
                    (fixture) =>
                    {
                        var employee_removed_event = fixture.create_remove_event_for_employee_id( fixture.add_employee_to_repository() );
                        fixture.event_handler.handle(employee_removed_event);
                    },

                commit_was_called:
                    (fixture) => Assert.IsTrue(fixture.unit_of_work.commit_was_called)
            )
        { }

    }
}
