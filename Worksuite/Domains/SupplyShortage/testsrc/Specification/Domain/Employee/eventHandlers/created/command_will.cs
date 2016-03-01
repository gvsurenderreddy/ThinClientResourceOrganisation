using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Domain.Specification;
using WTS.WorkSuite.SupplyShortage.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.SupplyShortage.Services.Domain.Employee.eventHandlers.created
{
    [TestClass]
    public class command_will : CommandCommitedChangesSpecification <SupplyShortagesTestBootstrap, EmployeeCreatedFixture>
    {
        public command_will( )
            : base(
            
                arrange:
                    (fixture) => { }, 
           
                execute:
                    (fixture) => fixture.event_handler.handle( fixture.create_event( ) ),

                commit_was_called:
                    (fixture) => Assert.IsTrue(fixture.unit_of_work.commit_was_called)
            )
        { }

    }
}
