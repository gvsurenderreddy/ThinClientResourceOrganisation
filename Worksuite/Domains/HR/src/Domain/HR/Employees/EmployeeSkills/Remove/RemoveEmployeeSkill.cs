using Content.Services.HR.Messages;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.Library.DomainTypes.OrderList;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Remove
{
    public class RemoveEmployeeSkill : IRemoveEmployeeSkill
    {
        public RemoveEmployeeSkillResponse execute(EmployeeSkillIdentity the_request)
        {
            return this
                .set_request(the_request)
                .find_employee()
                .find_employee_skill()
                .create_employee_skill_removed_event()
                .identify_the_priority_of_the_skill_to_be_removed()
                .remove_employee_skill()
                .commit()
                .publish_skill_removed_event()
                .publish_skill_auto_reordered_events()
                .build_response()
                ;
        }

        private RemoveEmployeeSkill set_request(EmployeeSkillIdentity the_request)
        {
            request = Guard.IsNotNull(the_request, "the_remove_employee_skill_request");

            response_builder = new ResponseBuilder<EmployeeSkillIdentity, RemoveEmployeeSkillResponse>();

            response_builder.set_response(
                                        new EmployeeSkillIdentity
                                        {
                                            employee_id = Null.Id,
                                            employee_skill_id = Null.Id
                                        }
                                         );

            return this;
        }

        private RemoveEmployeeSkill find_employee()
        {
            if (response_builder.has_errors) return this;

            employee = employee_repository
                            .Entities
                            .Single(e => e.id == request.employee_id);
            return this;
        }

        private RemoveEmployeeSkill find_employee_skill()
        {
            if (response_builder.has_errors) return this;
            if (employee == null) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee.EmployeeSkills, "employee.EmployeeSkill");

            employee_skill = employee
                                    .EmployeeSkills
                                    .Single(a => a.id == request.employee_skill_id);
            return this;
        }

        private RemoveEmployeeSkill create_employee_skill_removed_event()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee_skill, "employee_skill");
            Guard.IsNotNull(employee_skill.skill, "employee_skill.skill");

            employee_skill_removed_event = new EmployeeSkillRemovedEvent
                                                {
                                                    employee_id = employee.id,
                                                    employee_skill_id = employee_skill.skill.id,
                                                    employee_skill_description = employee_skill.skill.description,
                                                    priority = employee_skill.priority
                                                };

            return this;
        }

        private RemoveEmployeeSkill identify_the_priority_of_the_skill_to_be_removed()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee_skill, "employee_skill");

            priority_of_the_skill_to_be_removed = employee_skill.priority;

            return this;
        }

        private RemoveEmployeeSkill remove_employee_skill()
        {
            if (response_builder.has_errors) return this;
            if (employee_skill == null) return this;

            Guard.IsNotNull(employee_skill, "employee_skill");

            var index_entry_mapper = new ListEntryIndexMapper<EmployeeSkill>
                                                    (a => a.priority,
                                                        (a, value) => a.priority = value
                                                    );
            employee
                .EmployeeSkills
                .Select(index_entry_mapper.map)
                .Remove(index_entry_mapper.map(employee_skill),
                            () =>
                            {
                                employee.EmployeeSkills.Remove(employee_skill);
                                employee_repository.remove(employee_skill);
                            }
                       );
            return this;
        }

        private RemoveEmployeeSkill commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();
            return this;
        }

        private RemoveEmployeeSkill publish_skill_removed_event()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee_skill_removed_event, "employee_skill_removed_event");

            event_publisher_skill_removed.publish(employee_skill_removed_event);

            return this;
        }

        private RemoveEmployeeSkill publish_skill_auto_reordered_events()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee.EmployeeSkills, "employee.EmployeeSkills");
            Guard.IsNotNull(priority_of_the_skill_to_be_removed, "priority_of_the_skill_to_be_removed");

            foreach (EmployeeSkill employee_skill in employee.EmployeeSkills)
            {
                if (employee_skill.priority < priority_of_the_skill_to_be_removed) continue; // there is no need to trigger an auto reorder event for the for employee skills that are not affected.

                Guard.IsNotNull(employee_skill.skill, "employee_skill.skill");

                event_publisher_auto_reordered.publish(new EmployeeSkillAutoReorderedEvent
                {
                    employee_id = employee.id,
                    employee_skill_id = employee_skill.skill.id,
                    skill_description = employee_skill.skill.description,
                    priority = employee_skill.priority
                });
            }

            return this;
        }

        private RemoveEmployeeSkillResponse build_response()
        {
            if (!response_builder.has_errors)
            {
                response_builder.add_message(ValidationMessages.remove_was_successfull);
            }

            return response_builder.build();
        }

        public RemoveEmployeeSkill(IUnitOfWork the_unit_of_work,
                                   IEntityRepository<Employee> the_employee_repository,
                                   IEventPublisher<EmployeeSkillRemovedEvent> the_event_publisher_skill_removed,
                                   IEventPublisher<EmployeeSkillAutoReorderedEvent> the_event_publisher_auto_reordered
                                  )
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            employee_repository = Guard.IsNotNull(the_employee_repository, "the_employee_repository");
            event_publisher_skill_removed = Guard.IsNotNull(the_event_publisher_skill_removed,
                                                            "the_event_publisher_skill_removed"
                                                           );
            event_publisher_auto_reordered = Guard.IsNotNull(the_event_publisher_auto_reordered,
                                                             "the_event_publisher_auto_reordered"
                                                            );
        }

        private readonly IEntityRepository<Employee> employee_repository;
        private readonly IUnitOfWork unit_of_work;
        private readonly IEventPublisher<EmployeeSkillRemovedEvent> event_publisher_skill_removed;
        private readonly IEventPublisher<EmployeeSkillAutoReorderedEvent> event_publisher_auto_reordered;

        private ResponseBuilder<EmployeeSkillIdentity, RemoveEmployeeSkillResponse> response_builder;
        private EmployeeSkillIdentity request;
        private Employee employee;
        private EmployeeSkill employee_skill;
        private int priority_of_the_skill_to_be_removed;
        private EmployeeSkillRemovedEvent employee_skill_removed_event;
    }
}