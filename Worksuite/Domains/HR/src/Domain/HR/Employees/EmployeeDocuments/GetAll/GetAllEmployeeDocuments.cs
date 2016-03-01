using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.GetAll
{
    public class GetAllEmployeeDocuments : IGetAllEmployeeDocuments
    {
        public GetAllEmployeeDocuments(IQueryRepository<Employee> the_repository)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository");
        }

        private readonly IQueryRepository<Employee> repository;
        private Employee employee;


        public GetAllEmployeeDocumentsResponse execute(EmployeeIdentity request)
        {
            employee = repository
                      .Entities
                      .Single(e => e.id == request.employee_id);

            return new GetAllEmployeeDocumentsResponse
            {
                result = employee.EmployeeDocuments.Select(ec => new EmployeeDocumentDetails
                {
                    employee_id = request.employee_id,
                    document_id = ec.document_id,
                    employee_document_id = ec.id,
                    md5_value = ec.md5_hash,
                    content_type = ec.content_type,
                    description = ec.description,
                    name = ec.name,
                }),
            };
        }
    }
}