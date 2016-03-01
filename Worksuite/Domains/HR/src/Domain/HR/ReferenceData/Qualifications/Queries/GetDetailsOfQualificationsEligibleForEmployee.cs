using System.Collections.Generic;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Queries
{
    public class GetDetailsOfQualificationsEligibleForEmployee
                        : IGetDetailsOfQualificationsEligibleForEmployee
    {
        public Response< IEnumerable< QualificationDetails > > execute( EmployeeIdentity request )
        {
            Employee employee = _employee_repository
                                    .Entities
                                    .Single(e => e.id == request.employee_id)
                                    ;

            ICollection<Qualification> qualifications_assigned_to_the_employee = employee
                                                                                    .EmployeeQualifications
                                                                                    .Select( q => q.qualification )
                                                                                    .ToList()
                                                                                    ;

            ICollection<Qualification> eligible_qualifications = _qualification_repository
                                                                        .Entities
                                                                        .Where( q => !q.is_hidden )
                                                                        .OrderBy( q => q.description )
                                                                        .ToList()
                                                                        .Where( q => !qualifications_assigned_to_the_employee.Any( eq => eq.id == q.id ) )
                                                                        .ToList()
                                                                        ;

            return new Response<IEnumerable<QualificationDetails>>
            {
                result = eligible_qualifications.Select(q=> new QualificationDetails
                {
                    id          = q.id,
                    description = q.description,
                    is_hidden   = q.is_hidden
                })
            };
        }

        public GetDetailsOfQualificationsEligibleForEmployee(   IQueryRepository<Employee> the_employee_repository,
                                                                IQueryRepository<Qualification> the_qualification_repository
                                                            )
        {
            _employee_repository        = Guard.IsNotNull( the_employee_repository, "the_employee_repository" );
            _qualification_repository   = Guard.IsNotNull( the_qualification_repository, "the_qualification_repository" );
        }

        private readonly IQueryRepository<Employee> _employee_repository;
        private readonly IQueryRepository<Qualification> _qualification_repository;
    }
}