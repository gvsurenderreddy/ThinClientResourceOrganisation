using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Persistence.Domain.HR;
using WTS.WorkSuite.Service.Helpers.Framework.Request;
using WTS.WorkSuite.Service.Helpers.Framework.Specifications.ForResponseCommands.VerifiedByAnEntitiesState;
using WTS.WorkSuite.Service.HR.Employees;
using WTS.WorkSuite.Service.HR.Employees.EmployeeImage.Remove;

namespace WTS.WorkSuite.Service.Domain.HR.Employees.EmployeeImage.Features.Remove
{
    public class RemoveFixture
                    : ResponseCommandVerifiedByAnEntitiesStateFixture<EmployeeIdentity, RemoveResponse, IRemove, Employee>
    {

        public override Employee entity
        {

            get
            {
                return repository
                        .Entities
                        .Single(e => e.id == request.employee_id)
                        ;
            }
        }

        public RemoveFixture
                       (IRemove the_command
                       , IRequestBuilder<EmployeeIdentity> the_request_builder
                       , IEntityRepository<Employee> the_repository)
            : base(the_command
                   , the_request_builder)
        {

            Guard.IsNotNull(the_repository, "the_repository");

            repository = the_repository;
        }

        private readonly IEntityRepository<Employee> repository;
    }
}