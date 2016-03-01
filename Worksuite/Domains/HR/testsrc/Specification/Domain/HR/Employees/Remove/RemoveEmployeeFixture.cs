using System.Collections.Generic;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WorkSuite.Library.Service.Specification.Helpers.Specifications.ForResponseCommands;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.Events;
using WTS.WorkSuite.HR.HR.Employees.Remove;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Remove {

    public class RemoveEmployeeFixture 
                    : ResponseCommandFixture<EmployeeIdentity,RemoveResponse,IRemoveEmployee> {

        public void clear_all_employees () {
            employee_repository.clear();
        }

        public IEnumerable<EmployeeRemovedEvent> published_events {
            get { return event_publisher.published_events; }
        }

        public RemoveEmployeeFixture
                       ( IRemoveEmployee the_command
                       , IRequestHelper<EmployeeIdentity> the_request_builder 
                       , FakeEmployeeRepository the_employee_repository
                       , FakeEventPublisher<EmployeeRemovedEvent> the_event_publisher ) 
                : base ( the_command
                       , the_request_builder ) {

            event_publisher = Guard.IsNotNull( the_event_publisher, "the_event_publisher" );
            employee_repository = Guard.IsNotNull( the_employee_repository, "the_employee_repository" );
        }

        private readonly FakeEventPublisher<EmployeeRemovedEvent> event_publisher;
        private readonly FakeEmployeeRepository employee_repository;

    }
}
