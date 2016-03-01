using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Events;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Reorder;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeSkills.Features.Reorder
{
    public class ReorderEmployeeSkillFixture
    {
        public ReorderEmployeeSkillRequest request
        {
            get
            {
                Guard.IsNotNull(employee_skill_to_be_reordered, "employee_skill_to_be_reordered");

                return new ReorderEmployeeSkillRequest
                {
                    employee_id = employee_skill_to_be_reordered.employee_id,
                    employee_skill_id = employee_skill_to_be_reordered.employee_skill_id,
                    priority = reordered_to_position
                };
            }
        }

        public Maybe<ReorderEmployeeSkillResponse> response
        {
            get;
            private set;
        }

        public void execute_command(EmployeeSkillIdentity the_employee_skill_to_be_reordered,
                                    int the_reorder_to_position
                                   )
        {
            employee_skill_to_be_reordered = Guard.IsNotNull(the_employee_skill_to_be_reordered, "the_employee_skill_to_be_reordered");
            reordered_to_position = the_reorder_to_position;

            response = command.execute(request).to_maybe();
        }

        public Maybe<EmployeeSkillManualReorderedEvent> get_last_shift_calendar_pattern_manual_reordered_event_for(EmployeeSkillIdentity the_employee_skill_identity)
        {
            var reordered_skill_event = _event_publisher_manual_reordered_event
                                            .published_events
                                            .LastOrDefault(e => e.employee_id == the_employee_skill_identity.employee_id)
                                            ;

            return reordered_skill_event != null
                        ? new Just<EmployeeSkillManualReorderedEvent>(reordered_skill_event) as Maybe<EmployeeSkillManualReorderedEvent>
                        : new Nothing<EmployeeSkillManualReorderedEvent>()
                        ;
        }

        public Maybe<EmployeeSkillAutoReorderedEvent> get_last_shift_calendar_pattern_auto_reordered_event_for(EmployeeIdentity the_employee_identity)
        {
            var reordered_address_event = _event_publisher_auto_reordered_event
                                            .published_events
                                            .LastOrDefault(e => e.employee_id == the_employee_identity.employee_id)
                                            ;

            return reordered_address_event != null
                        ? new Just<EmployeeSkillAutoReorderedEvent>(reordered_address_event) as Maybe<EmployeeSkillAutoReorderedEvent>
                        : new Nothing<EmployeeSkillAutoReorderedEvent>()
                        ;
        }

        public ReorderEmployeeSkillFixture()
        {
            this.response = new Nothing<ReorderEmployeeSkillResponse>();
            _event_publisher_manual_reordered_event = DependencyResolver.resolve<FakeEventPublisher<EmployeeSkillManualReorderedEvent>>();
            _event_publisher_auto_reordered_event = DependencyResolver.resolve<FakeEventPublisher<EmployeeSkillAutoReorderedEvent>>();

            command = DependencyResolver.resolve<IReorderEmployeeSkill>();
        }

        private IReorderEmployeeSkill command;
        private FakeEventPublisher<EmployeeSkillManualReorderedEvent> _event_publisher_manual_reordered_event;
        private FakeEventPublisher<EmployeeSkillAutoReorderedEvent> _event_publisher_auto_reordered_event;

        private EmployeeSkillIdentity employee_skill_to_be_reordered;
        private int reordered_to_position;
    }
}