using System;
using System.Collections.Generic;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData;

namespace WTS.WorkSuite.HR.HR
{
    // to do: change all properties to be virtual
    public class Employee : BaseEntity<int>
    {
        public virtual Title title { get; set; }

        public virtual string employeeReference { get; set; }

        public virtual string forename { get; set; }

        public virtual string surname { get; set; }

        public virtual Gender gender { get; set; }

        public virtual MaritalStatus maritalStatus { get; set; }

        public virtual string othername { get; set; }

        public virtual string phone_number { get; set; }

        public virtual string birth_place { get; set; }

        public virtual DateTime? dateofbirth { get; set; }

        public virtual string email { get; set; }

        public virtual string mobile { get; set; }

        public virtual string other { get; set; }

        public virtual Nationality nationality { get; set; }

        public virtual EthnicOrigin ethnicOrigin { get; set; }

        public virtual JobTitle job_title { get; set; }

        public virtual Location location { get; set; }

        public virtual ICollection<EmergencyContact> EmergencyContacts
        {
            get { return emergency_contacts ?? (emergency_contacts = new HashSet<EmergencyContact>()); }
            set { emergency_contacts = value; }
        }

        public virtual ICollection<Address> Address
        {
            get { return address ?? (address = new HashSet<Address>()); }
            set { address = value; }
        }

        public virtual ICollection<Note> Note
        {
            get { return note ?? (note = new HashSet<Note>()); }
            set { note = value; }
        }

        public virtual ICollection<EmployeeDocument> EmployeeDocuments
        {
            get { return employee_documents ?? (employee_documents = new HashSet<EmployeeDocument>()); }
            set { employee_documents = value; }
        }

        public virtual ICollection<EmployeeSkill> EmployeeSkills
        {
            get { return employee_skills ?? (employee_skills = new HashSet<EmployeeSkill>()); }
            set { employee_skills = value; }
        }

        public virtual ICollection<EmployeeQualification> EmployeeQualifications
        {
            get { return employee_qualifications ?? (employee_qualifications = new HashSet<EmployeeQualification>()); }
            set { employee_qualifications = value; }
        }

        public virtual int image_id { get; set; }

        private ICollection<EmergencyContact> emergency_contacts;
        private ICollection<Address> address;
        private ICollection<Note> note;

        private ICollection<EmployeeDocument> employee_documents;

        private ICollection<EmployeeSkill> employee_skills;
        private ICollection<EmployeeQualification> employee_qualifications;
    }
}