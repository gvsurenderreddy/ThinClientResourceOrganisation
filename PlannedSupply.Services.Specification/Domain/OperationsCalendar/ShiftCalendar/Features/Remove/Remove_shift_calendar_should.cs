using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.Remove
{
    [TestClass]
    public class Remove_shift_calendar_should
                        : PlannedSupplySpecification
    {
        [TestMethod]
        public void remove_the_shift_calendar()
        {
            fixture.execute_command();

            fixture
                .response
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

            fixture = new RemoveShiftCalendarFixture();
        }

        private RemoveShiftCalendarFixture fixture;
    }
}