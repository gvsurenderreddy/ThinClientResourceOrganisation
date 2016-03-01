using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Remove
{
    class DependencyConfiguration : ADependencyConfiguration
    {

        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {

            kernel
                .Bind<IRemove>()
                .To<Remove>()
                ;

        }
    }
}
