using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.DomainTypes.Images;

namespace WTS.WorkSuite.HR.HR.Employees
{
    public class EmployeeSummaryDetails : EmployeeIdentity
    {
        /// <summary>
        /// Gets or sets the full name of employee.
        /// </summary>
        /// <value>
        /// The employee name.
        /// </value>
        public string employee_name { get; set; } 
        public ImageId image_id { get; set; } 
    }
}