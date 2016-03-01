using WTS.WorkSuite.Service.HR.Employees.EmployeeImage.New;
using WTS.WorkSuite.Service.Helpers.Specifications;

namespace WTS.WorkSuite.Service.Domain.HR.Employees.EmployeeImage.New {

    public class NewEmployeeImage_will 
                    : CommandCommitedChangesSpecification<NewEmployeeImageRequest, NewEmployeeImageResponse, NewEmployeeImageFixture> { }
}
