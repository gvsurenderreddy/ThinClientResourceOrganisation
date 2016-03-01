using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.New.Create;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.Features.New {

    [TestClass]
    public class New_operations_caledar_will_publish_an_operation_calendar_created_event
                    : PlannedSupplyResponseCommandSpecification< NewOperationsCalendarRequest
                                                               , NewOperationsCalendarResponse
                                                               , NewOperationsCalendarFixture> {

        [TestMethod]
        public void will_publish_an_operation_calendar_created_event () {

            fixture.execute_command();

            fixture
                .get_operation_calendar_created_event_for( fixture.entity )
                .Match( 

                    has_value:
                        e => { },  // happy case this should have occurred

                    nothing:
                        () => Assert.Fail( "An OperationCalendarCreatedEvent was not published"  )
                    
                );
        }
    }
}