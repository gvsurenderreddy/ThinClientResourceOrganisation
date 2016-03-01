using System.Collections.Generic;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.Audit.HR.Employees
{
    /// <summary>
    ///     Model that is the root of an employee audit trail.
    /// </summary>
    public class EmployeeAuditTrail
                    : BaseEntity<int>
    {
        public virtual int employee_id { get; set; }

        public virtual string employee_reference { get; set; }

        public virtual string forename { get; set; }

        public virtual string surname { get; set; }

        /// <summary>
        ///     Audit trail of commands that have been applied to the employee
        /// </summary>
        public ICollection<EmployeeAuditRecord> employee_audit
        {
            get { return employee_audit_ ?? (employee_audit_ = new HashSet<EmployeeAuditRecord>()); }
            set { employee_audit_ = value; }
        }

        public ICollection<EmergencyContactDetailsAuditRecord> emergency_contact_details_audit
        {
            get { return emergency_details_audit ?? (emergency_details_audit = new HashSet<EmergencyContactDetailsAuditRecord>()); }
            set { emergency_details_audit = value; }
        }

        public ICollection<EmployeeAddressDetailsAuditRecord> address_details_audit
        {
            get { return address_details_audit_ ?? (address_details_audit_ = new HashSet<EmployeeAddressDetailsAuditRecord>()); }
            set { address_details_audit_ = value; }
        }

        public ICollection<EmployeeContactDetailsAuditRecord> contact_details_audit
        {
            get { return contact_details_audit_ ?? (contact_details_audit_ = new HashSet<EmployeeContactDetailsAuditRecord>()); }
            set { contact_details_audit_ = value; }
        }

        public ICollection<EmployeeDocumentDetailsAuditRecord> document_details_audit
        {
            get { return document_details_audit_ ?? (document_details_audit_ = new HashSet<EmployeeDocumentDetailsAuditRecord>()); }
            set { document_details_audit_ = value; }
        }

        /// <summary>
        ///     Audit trails of an employees employment details changes
        /// </summary>
        public ICollection<EmployeeEmploymentDetailsAuditRecord> employment_details_audit
        {
            get { return employment_details_audit_ ?? (employment_details_audit_ = new HashSet<EmployeeEmploymentDetailsAuditRecord>()); }
            set { employment_details_audit_ = value; }
        }

        public ICollection<EmployeeImageDetailsAuditRecord> image_details_audit
        {
            get { return image_details_audit_ ?? (image_details_audit_ = new HashSet<EmployeeImageDetailsAuditRecord>()); }
            set { image_details_audit_ = value; }
        }

        public ICollection<EmployeeNoteDetailsAuditRecord> note_details_audit
        {
            get { return note_details_audit_ ?? (note_details_audit_ = new HashSet<EmployeeNoteDetailsAuditRecord>()); }
            set { note_details_audit_ = value; }
        }

        /// <summary>
        ///     Audit trails of an employees personal details changes
        /// </summary>
        public ICollection<EmployeePersonalDetailsAuditRecord> personal_details_audit
        {
            get { return personal_details_audit_ ?? (personal_details_audit_ = new HashSet<EmployeePersonalDetailsAuditRecord>()); }
            set { personal_details_audit_ = value; }
        }

        public ICollection<EmployeeQualificationDetailsAuditRecord> qualification_details_audit
        {
            get { return qualification_details_audit_ ?? (qualification_details_audit_ = new HashSet<EmployeeQualificationDetailsAuditRecord>()); }
            set { qualification_details_audit_ = value; }
        }

        public ICollection<EmployeeSkillDetailsAuditRecord> skill_details_audit
        {
            get { return skill_details_audit_ ?? (skill_details_audit_ = new HashSet<EmployeeSkillDetailsAuditRecord>()); }
            set { skill_details_audit_ = value; }
        }

        private ICollection<EmployeeAuditRecord> employee_audit_;
        private ICollection<EmergencyContactDetailsAuditRecord> emergency_details_audit;
        private ICollection<EmployeeAddressDetailsAuditRecord> address_details_audit_;
        private ICollection<EmployeeContactDetailsAuditRecord> contact_details_audit_;
        private ICollection<EmployeeDocumentDetailsAuditRecord> document_details_audit_;
        private ICollection<EmployeeEmploymentDetailsAuditRecord> employment_details_audit_;
        private ICollection<EmployeeImageDetailsAuditRecord> image_details_audit_;
        private ICollection<EmployeeNoteDetailsAuditRecord> note_details_audit_;
        private ICollection<EmployeePersonalDetailsAuditRecord> personal_details_audit_;
        private ICollection<EmployeeQualificationDetailsAuditRecord> qualification_details_audit_;
        private ICollection<EmployeeSkillDetailsAuditRecord> skill_details_audit_;
    }
}