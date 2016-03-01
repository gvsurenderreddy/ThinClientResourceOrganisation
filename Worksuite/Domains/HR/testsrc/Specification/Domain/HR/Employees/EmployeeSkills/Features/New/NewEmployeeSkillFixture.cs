using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.Events;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.New;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Skills;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeSkills.Features.New
{
    public class NewEmployeeSkillFixture
                    : ResponseCommandVerifiedByAnEntitiesStateFixture<NewEmployeeSkillRequest, NewEmployeeSkillResponse, INewEmployeeSkill, EmployeeSkill>
    {
        public NewEmployeeSkillRequest create_new_request
        {
            get
            {
                var skill_identity = skill_identity_helper.get_identity();

                return new NewEmployeeSkillRequest
                {
                    employee_id = employee_identity.employee_id,
                    skill_id = skill_identity.id
                };
            }
        }

        public Maybe<NewEmployeeSkillResponse> create_new_response
        {
            get;
            private set;
        }

        public virtual void execute_command(EmployeeIdentity the_employee_identity)
        {
            employee_identity = the_employee_identity;
            if (employee_identity == null)
                employee_identity = employee_identity_helper.get_identity();

            create_new_response = command.execute(create_new_request).to_maybe();
        }

        public Maybe<EmployeeSkillCreatedEvent> get_employee_skill_created_event_for(NewEmployeeSkillRequest request)
        {
            var create_event = events_publisher
                                    .published_events
                                    .Single(e => e.employee_id == request.employee_id)
                                    ;

            return create_event != null
                    ? new Just<EmployeeSkillCreatedEvent>(create_event) as Maybe<EmployeeSkillCreatedEvent>
                    : new Nothing<EmployeeSkillCreatedEvent>()
                    ;
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

        public override EmployeeSkill entity
        {
            get
            {
                Guard.IsNotNull(response, "response");

                return repository
                    .Entities
                    .Single(e => e.id == response.result.employee_id)
                    .EmployeeSkills
                    .Single(a => a.id == response.result.employee_skill_id)
                    ;
            }
        }

        public NewEmployeeSkillFixture
                       (INewEmployeeSkill the_command
                       , IRequestHelper<NewEmployeeSkillRequest> the_request_builder
                       , IEntityRepository<Employee> the_employee_repository)
            : base(the_command
                   , the_request_builder)
        {
            repository = Guard.IsNotNull(the_employee_repository, "the_employee_repository");

            this.create_new_response = new Nothing<NewEmployeeSkillResponse>();

            employee_identity_helper = DependencyResolver.resolve<EmployeeIdentityHelper>();
            skill_identity_helper = DependencyResolver.resolve<SkillIdentityHelper>();

            command = DependencyResolver.resolve<INewEmployeeSkill>();
            events_publisher = DependencyResolver.resolve<FakeEventPublisher<EmployeeSkillCreatedEvent>>();
            event_publisher_auto_reordered_event = DependencyResolver.resolve<FakeEventPublisher<EmployeeSkillAutoReorderedEvent>>();
        }

        private readonly IEntityRepository<Employee> repository;

        private INewEmployeeSkill command;
        private EmployeeIdentityHelper employee_identity_helper;
        private EmployeeIdentity employee_identity;
        private SkillIdentityHelper skill_identity_helper;
        private FakeEventPublisher<EmployeeSkillCreatedEvent> events_publisher;
        private FakeEventPublisher<EmployeeSkillAutoReorderedEvent> event_publisher_auto_reordered_event;
    }
}