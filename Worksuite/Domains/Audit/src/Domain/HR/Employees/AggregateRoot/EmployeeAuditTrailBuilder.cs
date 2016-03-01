using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees.AggregateRoot
{
    /// <summary>
    ///     Creates an Employee audit trail for the specified request
    /// </summary>
    public class EmployeeAuditTrailBuilder<T>
    {
        public EmployeeAuditTrail build
                                    (NewEmployeeAuditTrailRequest the_request)
        {
            return this
                    .set_request(the_request)
                    .sanatise_request()
                    .create_audit_trail()
                    .create_audit_record()
                    .build_response()
                    ;
        }

        public EmployeeAuditTrailBuilder
                    (IEntityRepository<EmployeeAuditTrail> the_model_repository
                    , EmployeeAuditRecordBuilder<T> the_audit_record_builder)
        {
            model_repository = Guard.IsNotNull(the_model_repository, "the_model_repository");
            audit_record_builder = Guard.IsNotNull(the_audit_record_builder, "the_audit_record_builder ");
        }

        private EmployeeAuditTrailBuilder<T> set_request
                                                (NewEmployeeAuditTrailRequest the_request)
        {
            request = Guard.IsNotNull(the_request, "the_request");
            return this;
        }

        private EmployeeAuditTrailBuilder<T> sanatise_request()
        {
            Guard.IsNotNull(request, "request");

            request = new NewEmployeeAuditTrailRequest(
                employee_id: request.employee_id,
                employee_reference: request.employee_reference.normalise_for_persistence(),
                forename: request.forename.normalise_for_persistence(),
                surname: request.surname.normalise_for_persistence(),
                received_at: request.received_at
            );
            return this;
        }

        private EmployeeAuditTrailBuilder<T> create_audit_trail()
        {
            Guard.IsNotNull(request, "request");

            model = new EmployeeAuditTrail
            {
                employee_id = request.employee_id,
                employee_reference = request.employee_reference,
                forename = request.forename,
                surname = request.surname,
            };
            model_repository.add(model);
            return this;
        }

        private EmployeeAuditTrailBuilder<T> create_audit_record()
        {
            Guard.IsNotNull(model, "model");
            Guard.IsNotNull(request, "request");

            var audit_record = audit_record_builder.build(new NewEmployeeAuditRecordRequest(
                received_at: request.received_at
            ));

            model.employee_audit.Add(audit_record);
            return this;
        }

        private EmployeeAuditTrail build_response()
        {
            Guard.IsNotNull(model, "model");

            return model;
        }

        private readonly IEntityRepository<EmployeeAuditTrail> model_repository;
        private readonly EmployeeAuditRecordBuilder<T> audit_record_builder;

        private NewEmployeeAuditTrailRequest request;
        private EmployeeAuditTrail model;
    }

    public class NewEmployeeAuditTrailRequest
                    : EmployeeIdentity
    {
        public string employee_reference { get; private set; }

        public string forename { get; private set; }

        public string surname { get; private set; }

        public UtcTime received_at { get; private set; }

        public string othername { get; set; }

        public NewEmployeeAuditTrailRequest
                (int employee_id
                , string employee_reference
                , string forename
                , string surname
                , UtcTime received_at)
        {
            Guard.IsNotNull(received_at, "received_at");

            this.employee_id = employee_id;
            this.employee_reference = employee_reference;
            this.forename = forename;
            this.surname = surname;
            this.received_at = received_at;
        }
    }

    public class GetOrCreateEmployeeAuditTrailRequest
                        : EmployeeIdentity
    {
        public UtcTime received_at { get; private set; }

        public GetOrCreateEmployeeAuditTrailRequest(int employee_id,
                                                UtcTime received_at
                                            )
        {
            this.employee_id = employee_id;
            this.received_at = received_at;
        }
    }
}