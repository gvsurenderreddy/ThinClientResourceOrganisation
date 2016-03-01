using System;
using System.Linq;
using System.Linq.Expressions;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.Library.DomainTypes.PostalAddresses.Formatting;

namespace WTS.WorkSuite.HR.HR.Employees
{
    /// <summary>
    ///     Mapper to map employee to EmployeeSummary
    /// </summary>
    public class EmployeeDetailsMapper : IEmployeeDetailsDetailsMapper
    {
        /// <summary>
        /// Gets the map.
        /// </summary>
        /// <value>
        /// The map.
        /// </value>
        public Expression<Func<Employee, EmployeeDetail>> Map
        {
            get
            {
                return employee => new EmployeeDetail
                {
                    employee_id = employee.id,
                    employee_reference = employee.employeeReference,
                    forename = employee.forename,
                    surname = employee.surname,
                    gender = employee.gender != null ? employee.gender.description : string.Empty,
                    othername = employee.othername,
                    phone = employee.phone_number,
                    date_of_birth = employee.dateofbirth.FormatForReport(),
                    age = employee.dateofbirth.ToAge(null),
                    email = employee.email,
                    mobile = employee.mobile,
                    other = employee.other,
                    image_id = employee.image_id,
                    job_title = employee.job_title != null ? employee.job_title.description : string.Empty,
                    location = employee.location != null ? employee.location.description : string.Empty,

                    first_address_details =
                        employee
                        .Address
                        .OrderBy(a => a.priority)
                        // convert address to enumeration of strings
                        .Select(a =>
                            new PostalAddressFormatter().format(a))
                        // if there are no address just create an empty
                        .DefaultIfEmpty(new String[] { })
                        .First()
                };
            }
        }
    }
}