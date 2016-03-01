using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Fields.Name
{
    public class A_shift_calendar_pattern_name_should_be_unique
    {
        [TestClass]
        public class On_create
                        : PlannedSupplySpecification
        {
            [TestMethod]
            public void when_tries_to_create_a_shift_calendar_with_the_same_calendar_name_as_another_shift_calendar()
            {
                // Populate the shift calendar identity.
                var shift_calendar_identity = shift_calendar_identity_helper.get_identity();

                var operations_calendar = fake_operations_repository
                                                .Entities
                                                .Single(oc => oc.id == shift_calendar_identity.operations_calendar_id)
                                                ;

                var shift_calendar = operations_calendar
                                        .ShiftCalendars
                                        .Single(sc => sc.id == shift_calendar_identity.shift_calendar_id)
                                        ;

                // Add a new pattern with the same pattern name as the pattern name in the request.
                shift_calendar.ShiftCalendarPatterns.Add(shift_calendar_pattern_builder.pattern_name(fixture.request.pattern_name).entity);

                // Now create another shift calendar pattern with the pattern name same as the shift calendar pattern created above.
                fixture.execute_command(shift_calendar_identity);

                // should fail to create.
                fixture
                    .create_new_response
                    .Match(

                        has_value:
                            response => response.has_errors.Should().Be(true),

                        nothing:
                            () => Assert.Fail()

                    );
            }

            protected override void test_setup()
            {
                base.test_setup();

                fixture = DependencyResolver.resolve<NewShiftCalendarPatternFixture>();

                fake_operations_repository = DependencyResolver.resolve<FakeOperationsCalendarRepository>();
                shift_calendar_pattern_builder = DependencyResolver.resolve<ShiftCalendarPatternBuilder>();
                shift_calendar_identity_helper = new ShiftCalendarIdentityHelper();
            }

            private NewShiftCalendarPatternFixture fixture;
            private FakeOperationsCalendarRepository fake_operations_repository;
            private ShiftCalendarPatternBuilder shift_calendar_pattern_builder;
            private ShiftCalendarIdentityHelper shift_calendar_identity_helper;
        }

        [TestClass]
        public class On_update
                        : PlannedSupplySpecification
        {
            [TestMethod]
            public void update_shift_calendar_pattern_fixture_should_return_a_shift_calendar_pattern_entity()
            {
                ShiftCalendarPattern shift_calendar_pattern = fixture.entity;
                Assert.IsTrue(shift_calendar_pattern.id != 0);
            }

            [TestMethod]
            public void when_tries_to_update_a_shift_calendar_with_the_same_calendar_name_as_another_shift_calendar()
            {
                // Add a pattern to a shift calendar calendar and populate the request.
                var request = fixture.request;

                var operations_calendar = fake_operations_repository
                                                .Entities
                                                .Single(oc => oc.id == request.operations_calendar_id)
                                                ;

                var shift_calendar = operations_calendar
                                        .ShiftCalendars
                                        .Single(sc => sc.id == request.shift_calendar_id)
                                        ;

                // Add another pattern to the same shift calaendar.
                shift_calendar.ShiftCalendarPatterns.Add(shift_calendar_pattern_builder.pattern_name(request.pattern_name).entity);

                // Now update the first shift calendar pattern's pattern name with second shift calendar pattern's pattern name.
                fixture.execute_command();

                // should fail to update.
                fixture
                    .update_response
                    .Match(

                        has_value:
                            response => response.has_errors.Should().Be(true),

                        nothing:
                            () => Assert.Fail()

                    );
            }

            protected override void test_setup()
            {
                base.test_setup();

                fixture = DependencyResolver.resolve<UpdateShiftCalendarPatternFixture>();

                fake_operations_repository = DependencyResolver.resolve<FakeOperationsCalendarRepository>();
                shift_calendar_pattern_builder = DependencyResolver.resolve<ShiftCalendarPatternBuilder>();
            }

            private UpdateShiftCalendarPatternFixture fixture;
            private FakeOperationsCalendarRepository fake_operations_repository;
            private ShiftCalendarPatternBuilder shift_calendar_pattern_builder;
        }
    }
}