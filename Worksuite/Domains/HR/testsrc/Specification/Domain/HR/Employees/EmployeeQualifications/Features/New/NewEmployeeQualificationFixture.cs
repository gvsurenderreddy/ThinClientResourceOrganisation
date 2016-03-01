using System.Linq;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.Events;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.New;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Qualifications;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeQualifications.Features.New
{
    public class NewEmployeeQualificationFixture
                        : ResponseCommandVerifiedByAnEntitiesStateFixture<  NewEmployeeQualificationRequest,
                                                                            NewEmployeeQualificationResponse,
                                                                            INewEmployeeQualification,
                                                                            EmployeeQualification
                                                                         >
    {
        public NewEmployeeQualificationRequest create_new_request
        {
            get
            {
                var qualification_identity = qualification_identity_helper.get_identity();

                return new NewEmployeeQualificationRequest
                {
                    employee_id = employee_identity.employee_id,
                    qualification_id = qualification_identity.id
                };
            }
        }

        public Maybe<NewEmployeeQualificationResponse> create_new_response
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

        public Maybe<EmployeeQualificationCreatedEvent> get_employee_qualification_created_event_for(NewEmployeeQualificationRequest request)
        {
            var create_event = events_publisher
                                    .published_events
                                    .SingleOrDefault(e => e.employee_id == request.employee_id)
                                    ;

            return create_event != null
                    ? new Just<EmployeeQualificationCreatedEvent>(create_event) as Maybe<EmployeeQualificationCreatedEvent>
                    : new Nothing<EmployeeQualificationCreatedEvent>()
                    ;
        }

        public override EmployeeQualification entity
        {
            get
            {
                Guard.IsNotNull ( response, "response" );

                return _employee_repository
                    .Entities
                    .Single( e => e.id == response.result.employee_id )
                    .EmployeeQualifications
                    .Single( eq => eq.id == response.result.employee_qualification_id )
                    ;
            }
        }

        public NewEmployeeQualificationFixture( INewEmployeeQualification the_command,
                                                IRequestHelper< NewEmployeeQualificationRequest > the_request_builder,
                                                IEntityRepository< Employee > the_employee_repository
                                              ) : base( the_command, the_request_builder )
        {
            _employee_repository = Guard.IsNotNull( the_employee_repository, "the_employee_repository" );

            this.create_new_response = new Nothing<NewEmployeeQualificationResponse>();

            employee_identity_helper = DependencyResolver.resolve<EmployeeIdentityHelper>();
            qualification_identity_helper = DependencyResolver.resolve<QualificationIdentityHelper>();

            command = DependencyResolver.resolve<INewEmployeeQualification>();
            events_publisher = DependencyResolver.resolve<FakeEventPublisher<EmployeeQualificationCreatedEvent>>();
        }

        private readonly IEntityRepository< Employee > _employee_repository;

        private INewEmployeeQualification command;
        private EmployeeIdentityHelper employee_identity_helper;
        private EmployeeIdentity employee_identity;
        private QualificationIdentityHelper qualification_identity_helper;
        private FakeEventPublisher<EmployeeQualificationCreatedEvent> events_publisher;
    }
}
