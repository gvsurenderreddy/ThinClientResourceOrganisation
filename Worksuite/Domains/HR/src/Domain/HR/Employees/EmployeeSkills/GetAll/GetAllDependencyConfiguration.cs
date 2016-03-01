using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.GetAll
{
    public class GetAllDependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel.Bind<IGetAllEmployeeSkills>()
                    .To<GetAllEmployeeSkills>()
           ;
        }
    }
}