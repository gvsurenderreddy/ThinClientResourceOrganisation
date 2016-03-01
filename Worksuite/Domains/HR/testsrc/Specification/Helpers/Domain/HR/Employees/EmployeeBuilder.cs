using System;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees
{
    /// <summary>
    /// Builder for Employee.
    /// </summary>
    public class EmployeeBuilder : IEntityBuilder<Employee>
    {
        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        public Employee entity
        {
            get { return employee; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeBuilder"/> class.
        /// </summary>
        /// <param name="the_employee">The the_employee.</param>
        public EmployeeBuilder(Employee the_employee)
        {
            Guard.IsNotNull(the_employee, "the_employee");

            employee = new Employee
            {
                id = the_employee.id,
                employeeReference = the_employee.employeeReference,
                forename = the_employee.forename,
                surname = the_employee.surname,
            };
        }

        /// <summary>
        /// The specified value of Employee reference
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>EmployeeBuilder</returns>
        public EmployeeBuilder employeeReference(string value)
        {
            employee.employeeReference = value;
            return this;
        }

        /// <summary>
        /// First_names the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>EmployeeBuilder</returns>
        public EmployeeBuilder forename(string value)
        {
            employee.forename = value;
            return this;
        }

        /// <summary>
        /// First_names the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>EmployeeBuilder</returns>
        public EmployeeBuilder surname(string value)
        {
            employee.surname = value;
            return this;
        }

        public EmployeeBuilder title(Title value)
        {
            employee.title = value;

            return this;
        }

        public EmployeeBuilder gender(Gender value)
        {
            employee.gender = value;

            return this;
        }

        public EmployeeBuilder maritalStatus(MaritalStatus value)
        {
            employee.maritalStatus = value;

            return this;
        }

        public EmployeeBuilder nationality(Nationality value)
        {
            employee.nationality = value;

            return this;
        }

        public EmployeeBuilder ethnic_origin(EthnicOrigin value)
        {
            employee.ethnicOrigin = value;

            return this;
        }

        public EmployeeBuilder employee_job_title(JobTitle value)
        {
            employee.job_title = value;

            return this;
        }

        public EmployeeBuilder employee_location(Location value)
        {
            employee.location = value;

            return this;
        }

        public EmployeeBuilder othername(string value)
        {
            employee.othername = value;
            return this;
        }

        public EmployeeBuilder birthplace(string value)
        {
            employee.birth_place = value;
            return this;
        }

        public EmployeeBuilder address(Address value)
        {
            employee.Address.Add(value);

            return this;
        }

        public EmployeeBuilder emergency_contact(EmergencyContact value)
        {
            employee.EmergencyContacts.Add(value);

            return this;
        }

        public EmployeeBuilder employee_document(EmployeeDocument value)
        {
            employee.EmployeeDocuments.Add(value);

            return this;
        }

        public EmployeeBuilder employee_skill(EmployeeSkill value)
        {
            employee.EmployeeSkills.Add(value);

            return this;
        }

        public EmployeeBuilder employee_qualification(EmployeeQualification value)
        {
            employee.EmployeeQualifications.Add(value);

            return this;
        }

        public EmployeeBuilder note(Note value)
        {
            employee.Note.Add(value);

            return this;
        }

        public EmployeeBuilder image_id(int value)
        {
            employee.image_id = value;

            return this;
        }

        public EmployeeBuilder dateofbirth(DateTime? value)
        {
            employee.dateofbirth = value;

            return this;
        }

        public EmployeeBuilder email(string value)
        {
            employee.email = value;

            return this;
        }

        public EmployeeBuilder mobile(string value)
        {
            employee.mobile = value;

            return this;
        }

        public EmployeeBuilder other(string value)
        {
            employee.other = value;

            return this;
        }

        private readonly Employee employee;
    }
}