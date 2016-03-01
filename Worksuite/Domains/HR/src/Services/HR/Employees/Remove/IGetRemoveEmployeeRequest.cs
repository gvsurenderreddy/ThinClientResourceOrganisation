﻿using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Remove
{
    public interface IGetRemoveEmployeeRequest : ICommand<EmployeeIdentity, Response<RemoveEmployeeRequest>> { }

}
