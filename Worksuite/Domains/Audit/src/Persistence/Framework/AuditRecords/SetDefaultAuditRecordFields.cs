using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Time.Clocks;

namespace WTS.WorkSuite.Audit.Framework.AuditRecords {

    /// <summary>
    ///     Set the default fields on an audit record
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SetDefaultAuditRecordFields<T> {

        public void execute
                    ( SetDefaultAuditRecordFieldsRequest request 
                    , DefaultAuditRecordFields audit_record ) {

            Guard.IsNotNull( audit_record, "audit_record" );

            audit_record.triggered_by_event = typeof (T).Name;
            audit_record.received_at = request.received_at.ToDateTime();
        }                                
    }

    public class SetDefaultAuditRecordFieldsRequest {

        public UtcTime received_at { get; private set; }

        public SetDefaultAuditRecordFieldsRequest 
                ( UtcTime received_at ) {

            Guard.IsNotNull( received_at, "received_at" );

            this.received_at = received_at;
        }
    }
}