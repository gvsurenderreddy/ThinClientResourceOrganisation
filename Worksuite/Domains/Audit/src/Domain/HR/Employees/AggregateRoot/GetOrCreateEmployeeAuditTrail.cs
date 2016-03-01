using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Audit.HR.Employees.AggregateRoot
{
    public class GetOrCreateEmployeeAuditTrail<T>
    {
        /// <summary>
        ///     Will get the audit trail for an employee if it exists otherwise it will
        /// create a new audit trail for the employee.
        /// </summary>
        /// <param name="request">
        ///     Request that holds the details that are used if an audit trail has to be created
        /// it also contains the identity of the employee that we want the audit trail for.
        /// </param>
        /// <returns></returns>
        public EmployeeAuditTrail execute
                                (GetOrCreateEmployeeAuditTrailRequest request)
        {
            Guard.IsNotNull(request, "request");

            return employee_repository
                    .GetSingle(at => at.employee_id == request.employee_id)
                    .Match(

                        has_value:
                            employee_audit_trail => employee_audit_trail,

                        nothing: () =>
                        {
                            var employee_audit_trail = audit_trail_builder.build(new NewEmployeeAuditTrailRequest(
                                employee_id: request.employee_id,
                                employee_reference: string.Empty,
                                forename: string.Empty,
                                surname: string.Empty,
                                received_at: request.received_at
                            ));

                            employee_repository.add(employee_audit_trail);

                            return employee_audit_trail;
                        });
        }

        public GetOrCreateEmployeeAuditTrail
                    (IEntityRepository<EmployeeAuditTrail> the_employee_repository
                    , EmployeeAuditTrailBuilder<T> the_audit_trail_builder)
        {
            employee_repository = Guard.IsNotNull(the_employee_repository, "the_employee_repository");
            audit_trail_builder = Guard.IsNotNull(the_audit_trail_builder, "the_audit_trail_builder");
        }

        private readonly IEntityRepository<EmployeeAuditTrail> employee_repository;
        private readonly EmployeeAuditTrailBuilder<T> audit_trail_builder;
    }
}