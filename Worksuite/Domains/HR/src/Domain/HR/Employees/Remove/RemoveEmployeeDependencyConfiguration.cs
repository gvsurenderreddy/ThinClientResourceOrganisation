using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.Employees.Remove
{
    public class RemoveEmployeeDependencyConfiguration : ADependencyConfiguration
    {

        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {


            kernel
                .Bind<IGetRemoveEmployeeRequest>()
                .To<GetRemoveEmployeeRequest>()
                ;

            kernel
                .Bind<ICanRemoveEmployee>()
                .To<CanRemoveEmployee>()
                ;

        }
    }
}
