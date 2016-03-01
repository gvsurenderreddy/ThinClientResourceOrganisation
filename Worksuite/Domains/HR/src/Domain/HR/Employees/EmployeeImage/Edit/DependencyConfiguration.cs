using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Edit
{
    class DependencyConfiguration : ADependencyConfiguration
    {

        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {

            kernel
                .Bind<IGetUpdateRequest>()
                .To<GetUpdateRequest>()
                ;

            kernel
                .Bind<IUpdate>()
                .To<Update>()
                ;

        }
    }
}
