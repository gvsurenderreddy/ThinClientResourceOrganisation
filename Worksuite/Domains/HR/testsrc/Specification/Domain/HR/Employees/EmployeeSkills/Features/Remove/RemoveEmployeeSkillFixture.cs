using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Events;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Remove;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Skills;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeSkills.Features.Remove
{
    public class RemoveEmployeeSkillFixture
                        : HRSpecification
    {
        public EmployeeSkillIdentity create_remove_request
        {
            get
            {
                if (employee_skill_identity == null)
                {
                    var employee_identity = employee_identity_helper.get_identity();
                    var skill_identity = skill_identity_helper.get_identity();
                    employee_skill_identity = new EmployeeSkillIdentity
                    {
                        employee_id = employee_identity.employee_id,
                        employee_skill_id = skill_identity.id
                    };
                }

                return new EmployeeSkillIdentity
                {
                    employee_id = employee_skill_identity.employee_id,
                    employee_skill_id = employee_skill_identity.employee_skill_id
                };
            }
        }

        public Maybe<RemoveEmployeeSkillResponse> create_remove_response
        {
            get;
            private set;
        }

        public virtual void execute_command(EmployeeSkillIdentity the_employee_skill_identity)
        {
            employee_skill_identity = the_employee_skill_identity;

            create_remove_response = command.execute(create_remove_request).to_maybe();
        }

        public Maybe<EmployeeSkillAutoReorderedEvent> get_last_employee_skill_auto_reordered_event_for(EmployeeIdentity the_employee_identity)
        {
            var reordered_skill_event = event_publisher_auto_reordered_event
                                            .published_events
                                            .LastOrDefault(e => e.employee_id == the_employee_identity.employee_id)
                                            ;

            return reordered_skill_event != null
                        ? new Just<EmployeeSkillAutoReorderedEvent>(reordered_skill_event) as Maybe<EmployeeSkillAutoReorderedEvent>
                        : new Nothing<EmployeeSkillAutoReorderedEvent>()
                        ;
        }

        public Maybe<EmployeeSkillRemovedEvent> get_last_employee_skill_removed_event_for(EmployeeIdentity the_employee_identity)
        {
            var removed_address_event = event_publisher
                                            .published_events
                                            .LastOrDefault(e => e.employee_id == the_employee_identity.employee_id)
                                            ;

            return removed_address_event != null
                        ? new Just<EmployeeSkillRemovedEvent>(removed_address_event) as Maybe<EmployeeSkillRemovedEvent>
                        : new Nothing<EmployeeSkillRemovedEvent>()
                        ;
        }

        public RemoveEmployeeSkillFixture()
        {
            this.create_remove_response = new Nothing<RemoveEmployeeSkillResponse>();

            employee_identity_helper = DependencyResolver.resolve<EmployeeIdentityHelper>();
            skill_identity_helper = DependencyResolver.resolve<SkillIdentityHelper>();

            command = DependencyResolver.resolve<IRemoveEmployeeSkill>();
            event_publisher = DependencyResolver.resolve<FakeEventPublisher<EmployeeSkillRemovedEvent>>();
            event_publisher_auto_reordered_event = DependencyResolver.resolve<FakeEventPublisher<EmployeeSkillAutoReorderedEvent>>();
        }

        private IRemoveEmployeeSkill command;
        private EmployeeIdentityHelper employee_identity_helper;
        private EmployeeSkillIdentity employee_skill_identity;
        private SkillIdentityHelper skill_identity_helper;
        private FakeEventPublisher<EmployeeSkillRemovedEvent> event_publisher;
        private FakeEventPublisher<EmployeeSkillAutoReorderedEvent> event_publisher_auto_reordered_event;
    }
}