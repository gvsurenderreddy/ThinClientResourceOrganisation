using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.HR.HR;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees {

    public class EmployeeHelper 
                    : EnityHelper<Employee,int,EmployeeBuilder,FakeEmployeeRepository> {}
}
