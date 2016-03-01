using WTS.WorkSuite.Audit.Framework.AuditRecords;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.HR.Employees.AggregateRoot {

    /// <summary>
    ///     Creates an Employee audit record 
    /// </summary>
    public class EmployeeAuditRecordBuilder<T> {


        public EmployeeAuditRecord build 
                                    ( NewEmployeeAuditRecordRequest request ) {

            var result = new EmployeeAuditRecord();

            set_default_audit_record_fields.execute( 
                new SetDefaultAuditRecordFieldsRequest(
                    received_at: request.received_at
                ), 
                result 
            );

            return result;
        }

        public EmployeeAuditRecordBuilder 
                    ( SetDefaultAuditRecordFields<T> set_default_audit_record_fields_command ) {

            set_default_audit_record_fields = Guard.IsNotNull( set_default_audit_record_fields_command, "set_default_audit_record_fields_command" );
        }

        private readonly SetDefaultAuditRecordFields<T> set_default_audit_record_fields;
    }

    public class NewEmployeeAuditRecordRequest {

        public UtcTime received_at { get; private set; }

        public NewEmployeeAuditRecordRequest 
                ( UtcTime received_at ) {

            this.received_at = received_at;
        }
    }
}