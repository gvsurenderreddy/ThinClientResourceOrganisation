using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.Events;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.Remove;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Qualifications;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeQualifications.Features.Remove
{
    public class RemoveEmployeeQualificationFixture
                        : HRSpecification
    {
        public EmployeeQualificationIdentity create_remove_request
        {
            get
            {
                if (employee_qualification_identity == null)
                {
                    var employee_identity = employee_identity_helper.get_identity();
                    var skill_identity = qualification_identity_helper.get_identity();
                    employee_qualification_identity = new EmployeeQualificationIdentity
                    {
                        employee_id = employee_identity.employee_id,
                        employee_qualification_id = skill_identity.id
                    };
                }

                return employee_qualification_identity;
            }
        }

        public Maybe<RemoveEmployeeQualificationResponse> create_remove_response
        {
            get;
            private set;
        }

        public virtual void execute_command(EmployeeQualificationIdentity the_employee_qualification_identity)
        {
            employee_qualification_identity = the_employee_qualification_identity;

            create_remove_response = command.execute(create_remove_request).to_maybe();
        }

        public Maybe<EmployeeQualificationRemovedEvent> get_last_employee_qualification_removed_event_for(EmployeeIdentity the_employee_identity)
        {
            var removed_qualification_event = event_publisher
                                            .published_events
                                            .LastOrDefault(e => e.employee_id == the_employee_identity.employee_id)
                                            ;

            return removed_qualification_event != null
                        ? new Just<EmployeeQualificationRemovedEvent>(removed_qualification_event) as Maybe<EmployeeQualificationRemovedEvent>
                        : new Nothing<EmployeeQualificationRemovedEvent>()
                        ;
        }

        public RemoveEmployeeQualificationFixture()
        {
            this.create_remove_response = new Nothing<RemoveEmployeeQualificationResponse>();

            employee_identity_helper = DependencyResolver.resolve<EmployeeIdentityHelper>();
            qualification_identity_helper = DependencyResolver.resolve<QualificationIdentityHelper>();

            command = DependencyResolver.resolve<IRemoveEmployeeQualification>();
            event_publisher = DependencyResolver.resolve<FakeEventPublisher<EmployeeQualificationRemovedEvent>>();
        }

        private IRemoveEmployeeQualification command;
        private EmployeeIdentityHelper employee_identity_helper;
        private EmployeeQualificationIdentity employee_qualification_identity;
        private QualificationIdentityHelper qualification_identity_helper;
        private FakeEventPublisher<EmployeeQualificationRemovedEvent> event_publisher;
    }
}