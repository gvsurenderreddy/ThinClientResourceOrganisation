using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.Reorder
{
    public class Reorder_shift_calendar_pattern_will
    {
        [TestClass]
        public class when_moved_to_a_lower_position : ReorderShiftCalendarPatternSpecifiction
        {
            [TestMethod]
            public void the_item_will_be_set_to_the_new_position()
            {
                // act
                fixture.execute_command(new ShiftCalendarPatternIdentity
                                                {
                                                    operations_calendar_id = operational_calendar.id,
                                                    shift_calendar_id = shift_calendar.id,
                                                    shift_calendar_pattern_id = pattern_two.id
                                                },
                                        5
                                       );

                // assert
                pattern_two.priority.Should().Be(5);
            }

            [TestMethod]
            public void move_the_affected_items()
            {
                // act
                fixture.execute_command(new ShiftCalendarPatternIdentity
                                                {
                                                    operations_calendar_id = operational_calendar.id,
                                                    shift_calendar_id = shift_calendar.id,
                                                    shift_calendar_pattern_id = pattern_two.id
                                                },
                                        5
                                       );

                // assert
                pattern_three.priority.Should().Be(2);
                pattern_four.priority.Should().Be(3);
                pattern_five.priority.Should().Be(4);
            }

            [TestMethod]
            public void leave_unaffected_items_unchanged()
            {
                // act
                fixture.execute_command(new ShiftCalendarPatternIdentity
                                                {
                                                    operations_calendar_id = operational_calendar.id,
                                                    shift_calendar_id = shift_calendar.id,
                                                    shift_calendar_pattern_id = pattern_two.id
                                                },
                                        5
                                       );

                pattern_one.priority.Should().Be(1);
                pattern_six.priority.Should().Be(6);
            }

            protected override void test_setup()
            {
                base.test_setup();

                fixture = new ReorderShiftCalendarPatternFixture();
            }

            private ReorderShiftCalendarPatternFixture fixture;
        }

        [TestClass]
        public class when_moved_to_a_higher_position : ReorderShiftCalendarPatternSpecifiction
        {
            [TestMethod]
            public void the_item_will_be_set_to_the_new_position()
            {
                // act
                fixture.execute_command(new ShiftCalendarPatternIdentity
                                                {
                                                    operations_calendar_id = operational_calendar.id,
                                                    shift_calendar_id = shift_calendar.id,
                                                    shift_calendar_pattern_id = pattern_five.id
                                                },
                                        2
                                       );

                // assert
                pattern_five.priority.Should().Be(2);
            }

            [TestMethod]
            public void move_the_affected_items()
            {
                // act
                fixture.execute_command(new ShiftCalendarPatternIdentity
                                                {
                                                    operations_calendar_id = operational_calendar.id,
                                                    shift_calendar_id = shift_calendar.id,
                                                    shift_calendar_pattern_id = pattern_five.id
                                                },
                                        2
                                       );

                // assert
                pattern_two.priority.Should().Be(3);
                pattern_three.priority.Should().Be(4);
                pattern_four.priority.Should().Be(5);
            }

            [TestMethod]
            public void leave_unaffected_items_unchanged()
            {
                // act
                fixture.execute_command(new ShiftCalendarPatternIdentity
                                                {
                                                    operations_calendar_id = operational_calendar.id,
                                                    shift_calendar_id = shift_calendar.id,
                                                    shift_calendar_pattern_id = pattern_five.id
                                                },
                                        2
                                       );

                pattern_one.priority.Should().Be(1);
                pattern_six.priority.Should().Be(6);
            }

            protected override void test_setup()
            {
                base.test_setup();

                fixture = new ReorderShiftCalendarPatternFixture();
            }

            private ReorderShiftCalendarPatternFixture fixture;
        }

        [TestClass]
        public class when_moved_to_the_same_position : ReorderShiftCalendarPatternSpecifiction
        {
            [TestMethod]
            public void all_items_remain_unchanged()
            {
                // act
                fixture.execute_command(new ShiftCalendarPatternIdentity
                                                {
                                                    operations_calendar_id = operational_calendar.id,
                                                    shift_calendar_id = shift_calendar.id,
                                                    shift_calendar_pattern_id = pattern_five.id
                                                },
                                        5
                                       );

                // assert
                pattern_one.priority.Should().Be(1);
                pattern_two.priority.Should().Be(2);
                pattern_three.priority.Should().Be(3);
                pattern_four.priority.Should().Be(4);
                pattern_five.priority.Should().Be(5);
                pattern_six.priority.Should().Be(6);
            }

            protected override void test_setup()
            {
                base.test_setup();

                fixture = new ReorderShiftCalendarPatternFixture();
            }

            private ReorderShiftCalendarPatternFixture fixture;
        }
    }
}