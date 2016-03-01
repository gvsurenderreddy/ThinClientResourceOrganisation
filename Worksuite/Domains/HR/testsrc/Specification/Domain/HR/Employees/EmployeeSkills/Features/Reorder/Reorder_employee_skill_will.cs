using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Reorder;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeSkills.Features.Reorder
{
    public class Reorder_employee_skill_will
    {
        // move to a lower order
        //  move the element
        //  change the priority of the elements that have moved
        //  not change the priority of the elements that were not moved

        // move to a higher order
        //  move the element
        //  change the priority of the elements that have moved
        //  not change the priority of the elements that were not moved

        // move to the same position

        [TestClass]
        public class WhenMovingAnEmployeeSkillWorkSuiteToALowerOrderPosition
                            : ReorderEmployeeSkillWorkSuiteSpecification
        {
            //  move the element to a lower order
            //  change the priority of the elements that have moved
            //  not change the priority of the elements that were not moved

            [TestMethod]
            public void the_employee_skill_will_be_moved()
            {
                // Act
                reorder_employee_skill.execute( new ReorderEmployeeSkillRequest
                                                    {
                                                        employee_id = employee.id,
                                                        employee_skill_id = employee_skill_two.id,
                                                        priority = 5
                                                    }
                                                 );

                // Assert
                employee_skill_two.priority.Should().Be( 5 );
            }

            [TestMethod]
            public void change_the_priority_of_the_elements_that_have_moved()
            {
                // Act
                reorder_employee_skill.execute( new ReorderEmployeeSkillRequest
                                                    {
                                                        employee_id = employee.id,
                                                        employee_skill_id = employee_skill_two.id,
                                                        priority = 5
                                                    }
                                                 );

                // Assert
                employee_skill_three.priority.Should().Be( 2 );
                employee_skill_four.priority.Should().Be( 3 );
                employee_skill_five.priority.Should().Be( 4 );
            }

            [TestMethod]
            public void not_change_the_priority_of_the_elements_that_were_not_moved()
            {
                // Act
                reorder_employee_skill.execute( new ReorderEmployeeSkillRequest
                                                    {
                                                        employee_id = employee.id,
                                                        employee_skill_id = employee_skill_two.id,
                                                        priority = 5
                                                    }
                                                 );

                // Assert
                employee_skill_one.priority.Should().Be( 1 );
                employee_skill_six.priority.Should().Be( 6 );
            }

        }

        [TestClass]
        public class WhenMovingAnEmployeeSkillWorkSuiteToAHigherOrderPosition
                            : ReorderEmployeeSkillWorkSuiteSpecification
        {
            //  move the element to a higher order
            //  change the priority of the elements that have moved
            //  not change the priority of the elements that were not moved

            [TestMethod]
            public void the_employee_skill_will_be_moved()
            {
                // Act
                reorder_employee_skill.execute( new ReorderEmployeeSkillRequest
                                                        {
                                                            employee_id = employee.id,
                                                            employee_skill_id = employee_skill_five.id,
                                                            priority = 2
                                                        }
                                                  );

                // Assert
                employee_skill_five.priority.Should().Be( 2 );
            }

            [TestMethod]
            public void change_the_priority_of_the_elements_that_have_moved()
            {
                // Act
                reorder_employee_skill.execute( new ReorderEmployeeSkillRequest
                                                    {
                                                        employee_id = employee.id,
                                                        employee_skill_id = employee_skill_five.id,
                                                        priority = 2
                                                    }
                                                  );
                // Assert
                employee_skill_two.priority.Should().Be( 3 );
                employee_skill_three.priority.Should().Be( 4 );
                employee_skill_four.priority.Should().Be( 5 );
            }

            [TestMethod]
            public void not_change_the_priority_of_the_elements_that_were_not_moved()
            {
                // Act
                reorder_employee_skill.execute( new ReorderEmployeeSkillRequest
                                                    {
                                                        employee_id = employee.id,
                                                        employee_skill_id = employee_skill_five.id,
                                                        priority = 2
                                                    }
                                                  );
                // Assert
                employee_skill_one.priority.Should().Be( 1 );
                employee_skill_six.priority.Should().Be( 6 );
            }
            
        }

        [TestClass]
        public class WhenMovingAnEmployeeSkillWorkSuiteToTheSamePosition
                            : ReorderEmployeeSkillWorkSuiteSpecification
        {
            //  move the element to the same position
            //  change the priority of the elements that have moved
            //  not change the priority of the elements that were not moved

            [TestMethod]
            public void all_priorities_remain_as_they_were()
            {
                // Act
                reorder_employee_skill.execute( new ReorderEmployeeSkillRequest
                                                    {
                                                        employee_id = employee.id,
                                                        employee_skill_id = employee_skill_four.id,
                                                        priority = 4
                                                    }
                                                 );

                // Assert
                employee_skill_one.priority.Should().Be( 1 );
                employee_skill_two.priority.Should().Be( 2 );
                employee_skill_three.priority.Should().Be( 3 );
                employee_skill_four.priority.Should().Be( 4 );
                employee_skill_five.priority.Should().Be( 5 );
                employee_skill_six.priority.Should().Be( 6 );
            }
        }
    }
}