using Content.Services.Common.Messages;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.OrderList;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Reorder
{
    public class ReorderEmployeeSkill : IReorderEmployeeSkill
    {
        public ReorderEmployeeSkillResponse execute(ReorderEmployeeSkillRequest request)
        {
            return this
                .set_request(request)
                .find_employee()
                .find_employee_skill()
                .get_a_copy_of_all_employee_skill()
                .create_employee_skill_move_request()
                .validate()
                .move_employee_skill()
                .commit()
                .publish_employee_skill_manual_reordered_event()
                .publish_employee_skill_auto_reordered_events()
                .build_response()
                ;
        }

        private ReorderEmployeeSkill set_request(ReorderEmployeeSkillRequest request)
        {
            reorder_employee_skill_request = Guard.IsNotNull(request, "reorderemployee_skill_request");

            response_builder = new ResponseBuilder<ReorderEmployeeSkillResponse>();

            return this;
        }

        private ReorderEmployeeSkill find_employee()
        {
            if (response_builder.has_errors) return this;

            employee = employee_repository
                            .Entities
                            .Single(e => e.id == reorder_employee_skill_request.employee_id);
            return this;
        }

        private ReorderEmployeeSkill find_employee_skill()
        {
            if (response_builder.has_errors) return this;
            if (employee == null) return this;

            Guard.IsNotNull(employee, "employee");

            employee_skill = employee
                                    .EmployeeSkills
                                    .Single(ec => ec.id == reorder_employee_skill_request.employee_skill_id);
            return this;
        }

        private ReorderEmployeeSkill get_a_copy_of_all_employee_skill()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee.EmployeeSkills, "employee.EmployeeSkills");

            cached_employee_skills = new EmployeeSkillPriority[employee.EmployeeSkills.Count];

            int count = 0;
            foreach (EmployeeSkill employee_skill in employee.EmployeeSkills)
            {
                cached_employee_skills[count] = new EmployeeSkillPriority { skill_id = employee_skill.id, priority = employee_skill.priority };
                count++;
            }

            cached_employee_skills.OrderBy(a => a.priority);

            return this;
        }

        private ReorderEmployeeSkill create_employee_skill_move_request()
        {
            if (response_builder.has_errors) return this;
            if (employee_skill == null) return this;

            Guard.IsNotNull(employee_skill, "employee_skill");

            move_request = new MoveIndexEntryRequest
            {
                @from = employee_skill.priority,
                to = reorder_employee_skill_request.priority
            };
            return this;
        }

        private ReorderEmployeeSkill validate()
        {
            if (response_builder.has_errors) return this;

            validator
                .field("priority")
                .premise_holds(move_request.to >= 1, ValidationMessages.error_03_0007)
                .premise_holds(move_request.to <= employee.EmployeeSkills.Count(),
                    ValidationMessages.error_03_0008)
                ;
            response_builder.add_errors(validator.errors);
            return this;
        }

        private ReorderEmployeeSkill move_employee_skill()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(move_request, "move_request");

            var to_index_mapper = new ListEntryIndexMapper<EmployeeSkill>
                                            (m => m.priority,
                                                (m, value) => m.priority = value
                                            );
            employee
                .EmployeeSkills
                .Select(to_index_mapper.map)
                .Move(move_request)
                ;
            return this;
        }

        private ReorderEmployeeSkill commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();
            return this;
        }

        private ReorderEmployeeSkill publish_employee_skill_manual_reordered_event()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee_skill, "employee_skill");
            Guard.IsNotNull(employee_skill.skill, "employee_skill.skill");

            event_publisher_manual_reordered.publish(new EmployeeSkillManualReorderedEvent
            {
                employee_id = employee.id,
                employee_skill_id = employee_skill.skill.id,
                skill_description = employee_skill.skill.description,
                priority = employee_skill.priority
            });

            return this;
        }

        private ReorderEmployeeSkill publish_employee_skill_auto_reordered_events()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(cached_employee_skills, "cached_employee_skills");
            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee.EmployeeSkills, "employee.EmployeeSkills");
            Guard.IsNotNull(employee_skill, "employee_skill");

            foreach (EmployeeSkillPriority skill_priority in cached_employee_skills)
            {
                if (move_request.from == move_request.to) break; // re-ordered to the same position, therefore no need to raise any auto reordered events.

                if (skill_priority.skill_id == employee_skill.id) continue; // a manual reordered event has been raised already for the employee skill re-ordered.

                var the_other_employee_skill = employee.EmployeeSkills.Single(es => es.id == skill_priority.skill_id); // Get the updated copy of the other employee skill.

                if (skill_priority.priority == the_other_employee_skill.priority) continue; // if there is no priority change made for the other employee skill, there is no need to trigger an auto reordered event.

                Guard.IsNotNull(the_other_employee_skill.skill, "the_other_employee_skill.skill");

                event_publisher_auto_reordered.publish(new EmployeeSkillAutoReorderedEvent
                {
                    employee_id = employee.id,
                    employee_skill_id = the_other_employee_skill.skill.id,
                    skill_description = the_other_employee_skill.skill.description,
                    priority = the_other_employee_skill.priority
                });
            }

            return this;
        }

        private ReorderEmployeeSkillResponse build_response()
        {
            if (!response_builder.has_errors)
            {
                response_builder.add_message(
                            ValidationMessages.reorder_was_successfull(move_request.from,
                                                                        move_request.to
                                                                      )
                                            );
            }

            return response_builder.build();
        }

        public ReorderEmployeeSkill(IUnitOfWork the_unit_of_work,
                                        IEntityRepository<Employee> the_employee_repository,
                                        Validator the_validator,
                                        IEventPublisher<EmployeeSkillManualReorderedEvent> the_event_publisher_manual_reordered,
                                        IEventPublisher<EmployeeSkillAutoReorderedEvent> the_event_publisher_auto_reordered
                                      )
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            employee_repository = Guard.IsNotNull(the_employee_repository, "theemployee_repository");
            validator = Guard.IsNotNull(the_validator, "thevalidator");
            event_publisher_manual_reordered = Guard.IsNotNull(the_event_publisher_manual_reordered,
                                                               "the_event_publisher_manual_reordered"
                                                              );
            event_publisher_auto_reordered = Guard.IsNotNull(the_event_publisher_auto_reordered,
                                                             "the_event_publisher_auto_reordered"
                                                            );
        }

        private readonly IUnitOfWork unit_of_work;
        private readonly IEntityRepository<Employee> employee_repository;
        private readonly Validator validator;
        private readonly IEventPublisher<EmployeeSkillManualReorderedEvent> event_publisher_manual_reordered;
        private readonly IEventPublisher<EmployeeSkillAutoReorderedEvent> event_publisher_auto_reordered;

        private ResponseBuilder<ReorderEmployeeSkillResponse> response_builder;
        private ReorderEmployeeSkillRequest reorder_employee_skill_request;
        private Employee employee;
        private EmployeeSkill employee_skill;
        private MoveIndexEntryRequest move_request;
        private EmployeeSkillPriority[] cached_employee_skills;
    }

    public class EmployeeSkillPriority
    {
        public int skill_id { get; set; }

        public int priority { get; set; }
    }
}