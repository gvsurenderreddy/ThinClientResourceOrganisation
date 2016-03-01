using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.Edit
{
    [TestClass]
    public class Update_shift_calendar_should
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void update_the_shift_calendar()
        {
            fixture.execute_command();

            fixture
                .update_response
                .Match(

                    has_value:
                        response => response.has_errors.Should().Be(false),

                    nothing:
                        () => Assert.Fail()

                );
        }

        protected override void test_setup()
        {
            base.test_setup();

            fixture = DependencyResolver.resolve<UpdateShiftCalendarFixture>();
        }

        private UpdateShiftCalendarFixture fixture;
    }
}