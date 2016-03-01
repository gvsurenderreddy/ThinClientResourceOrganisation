using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.Service.HR.Employees.EmployeeImage.New;

namespace WTS.WorkSuite.Domain.HR.Employees.EmployeeImage.New
{
    class NewEmployeeImageDependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
               .Bind<IGetNewEmployeeImageRequest>()
               .To<GetNewEmployeeImageRequest>()
               ;

            kernel
                .Bind<INewEmployeeImage>()
                .To<NewEmployeeImage>()
                ;

            kernel
               .Bind<ICanAddNewEmployeeImage>()
               .To<CanAddNewEmployeeImage>()
               ;

        }
    }
}
