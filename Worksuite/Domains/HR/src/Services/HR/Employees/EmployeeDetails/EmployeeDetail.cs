using System.Collections.Generic;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.DomainTypes.Images;

namespace WTS.WorkSuite.HR.HR.Employees
{
    public class EmployeeDetail : EmployeeIdentity
    {
        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>
        /// The surname.
        /// </value>
        public string forename { get; set; }

        /// <summary>
        /// Gets or sets the forename.
        /// </summary>
        /// <value>
        /// The forename.
        /// </value>
        public string surname { get; set; }

        /// <summary>
        /// Gets or sets employee reference.
        /// </summary>
        /// <value>
        /// The employeeReference.
        /// </value>
        public string employee_reference { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The mobile.
        /// </value>
        public string location { get; set; }

        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        /// <value>
        /// The mobile.
        /// </value>
        public string job_title { get; set; }

        /// <summary>
        /// Gets or sets the mobile.
        /// </summary>
        /// <value>
        /// The mobile.
        /// </value>
        public string mobile { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        public string phone { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string email { get; set; }

        /// <summary>
        /// Gets or sets the image id.
        /// </summary>
        public ImageId image_id { get; set; }

        /// <summary>
        /// Gets or sets the first address.
        /// </summary>
        //public string first_address_details { get; set; }
        public IEnumerable<string> first_address_details { get; set; }

        /// <summary>
        /// Gets or sets the Date Of Birth
        /// </summary>
        public string date_of_birth { get; set; }

        /// <summary>
        /// Determines the employees age from his date of birth
        /// </summary>
        public int? age { get; set; }

        /// <summary>
        /// Gets or sets the other field for contact details.
        /// </summary>
        public string other { get; set; }

        public string gender { get; set; }

        /// <summary>
        /// Gets or sets the othernames.
        /// </summary>
        /// <value>
        /// The othernames.
        /// </value>
        public string othername { get; set; }
    }
}