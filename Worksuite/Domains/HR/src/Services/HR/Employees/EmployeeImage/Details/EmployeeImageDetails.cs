
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.DomainTypes.Images;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Details
{
    public class EmployeeImageDetails : EmployeeIdentity
    {
        public ImageId image_id { get; set; }
    }
}
