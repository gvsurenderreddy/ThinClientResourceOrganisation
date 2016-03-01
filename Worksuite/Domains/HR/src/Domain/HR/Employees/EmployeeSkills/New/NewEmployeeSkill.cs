using Content.Services.HR.Messages;
using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Events;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.Library.DomainTypes.OrderList;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.New
{
    public class NewEmployeeSkill : INewEmployeeSkill
    {
        public NewEmployeeSkillResponse execute(NewEmployeeSkillRequest the_request)
        {
            return this
                .set_request(the_request)
                .find_employee()
                .find_skill()
                .validate_request()
                .create_employee_skill()
                .commit()
                .publish_skill_created_event()
                .publish_skill_auto_reordered_events()
                .build_response()
                ;
        }

        private NewEmployeeSkill set_request(NewEmployeeSkillRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");

            response_builder = new ResponseBuilder<EmployeeSkillIdentity, NewEmployeeSkillResponse>();

            response_builder.set_response(new EmployeeSkillIdentity
            {
                employee_id = request.employee_id,
                employee_skill_id = Null.Id
            });

            return this;
        }

        private NewEmployeeSkill find_employee()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            employee = repository
                            .Entities
                            .Single(e => e.id == request.employee_id)
                            ;
            return this;
        }

        private NewEmployeeSkill find_skill()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            skill = skill_repository
                            .Entities
                            .SingleOrDefault(r => r.id == request.skill_id && !r.is_hidden)
                            ;

            return this;
        }

        private NewEmployeeSkill validate_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");
            Guard.IsNotNull(employee, "employee");

            response_builder.add_errors(new_employee_skill_validator.validate(request));

            if (skill == null && request.skill_id > 0)
            {
                validator.field("skill_id")
                    .premise_holds(false, "Please select a skill that is not hidden");
            }
            else if (skill == null)
            {
                validator.field("skill_id")
                    .premise_holds(false, ValidationMessages.error_01_0003);
            }

            if (employee.EmployeeSkills.Any(es => es.skill != null && es.skill.id == request.skill_id))
            {
                validator.field("skill_id")
                            .premise_holds(false, ValidationMessages.error_00_0027);
            }

            response_builder.add_errors(validator.errors);

            return this;
        }

        private NewEmployeeSkill create_employee_skill()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(skill, "skill");

            new_employee_skill = new EmployeeSkill
            {
                skill = skill,
                priority = 1
            };

            var index_entry_mapper = new ListEntryIndexMapper<EmployeeSkill>
                                                    (em => em.priority,
                                                        (em, value) => em.priority = value
                                                    );

            employee
                .EmployeeSkills
                .Select(index_entry_mapper.map)
                .Insert(index_entry_mapper.map(new_employee_skill),
                            () => employee.EmployeeSkills.Add(new_employee_skill)
                       )
                ;
            return this;
        }

        private NewEmployeeSkill commit()
        {
            if (response_builder.has_errors) return this;

            unit_of_work.Commit();
            return this;
        }

        private NewEmployeeSkill publish_skill_created_event()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(new_employee_skill, "new_employee_skill");
            Guard.IsNotNull(new_employee_skill.skill, "new_employee_skill.skill");

            event_publisher_skill_created.publish(new EmployeeSkillCreatedEvent
            {
                employee_id = employee.id,
                employee_skill_id = new_employee_skill.skill.id,
                employee_skill_description = new_employee_skill.skill.description,
                priority = new_employee_skill.priority
            });

            return this;
        }

        private NewEmployeeSkill publish_skill_auto_reordered_events()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(employee, "employee");
            Guard.IsNotNull(employee.EmployeeSkills, "employee.EmployeeSkills");
            Guard.IsNotNull(new_employee_skill, "new_employee_skill");

            foreach (EmployeeSkill employee_skill in employee.EmployeeSkills)
            {
                if (employee_skill.id == new_employee_skill.id) continue; // there is no need to trigger an auto reorder event for the new skill added.

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

        private NewEmployeeSkillResponse build_response()
        {
            if (!response_builder.has_errors)
            {
                var confirmation = new List<string> { ValidationMessages.confirmation_04_0001 };
                response_builder.add_messages(confirmation);
                response_builder.set_response(new EmployeeSkillIdentity { employee_id = request.employee_id, employee_skill_id = new_employee_skill.id });
            }
            else
            {
                response_builder.add_errors(new List<string> {
                    ValidationMessages.warning_03_0001,
                });
            }
            return response_builder.build();
        }

        public NewEmployeeSkill(IEntityRepository<Employee> the_repository
                                    , IEntityRepository<Skill> the_skill_repository
                                    , IUnitOfWork the_unit_of_work
                                    , INewEmployeeSkillValidator the_new_employee_skill_validator
                                    , Validator the_validator
                                    , IEventPublisher<EmployeeSkillCreatedEvent> the_event_publisher_skill_created
                                    , IEventPublisher<EmployeeSkillAutoReorderedEvent> the_event_publisher_auto_reordered)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");
            skill_repository = Guard.IsNotNull(the_skill_repository, "the_skill_repository");
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            new_employee_skill_validator = Guard.IsNotNull(the_new_employee_skill_validator, "the_new_employee_skill_validator");
            validator = Guard.IsNotNull(the_validator, "the_validator");
            event_publisher_skill_created = Guard.IsNotNull(the_event_publisher_skill_created,
                                                            "the_event_publisher_skill_created"
                                                           );
            event_publisher_auto_reordered = Guard.IsNotNull(the_event_publisher_auto_reordered,
                                                             "the_event_publisher_auto_reordered"
                                                            );
        }

        private readonly IEntityRepository<Employee> repository;
        private readonly IEntityRepository<Skill> skill_repository;
        private readonly IUnitOfWork unit_of_work;
        private readonly INewEmployeeSkillValidator new_employee_skill_validator;
        private readonly Validator validator;
        private readonly IEventPublisher<EmployeeSkillCreatedEvent> event_publisher_skill_created;
        private readonly IEventPublisher<EmployeeSkillAutoReorderedEvent> event_publisher_auto_reordered;

        private EmployeeSkill new_employee_skill;
        private Employee employee;
        private Skill skill;
        private NewEmployeeSkillRequest request;
        private ResponseBuilder<EmployeeSkillIdentity, NewEmployeeSkillResponse> response_builder;
    }
}