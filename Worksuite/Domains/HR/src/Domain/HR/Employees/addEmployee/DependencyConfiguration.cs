using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.Employees.addEmployee.get;
using WTS.WorkSuite.HR.HR.Employees.addEmployee.post;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.Employees.addEmployee
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel
                                      , Func<IContext, object> scope)
        {

            kernel
                .Bind<IGetAddEmployeeRequestHandler>()
                .To<GetAddEmployeeRequestHandler>()
                ;

            kernel
                .Bind<IAddEmployeeRequestHandler>()
                .To<AddEmployeeRequestHandler>()
                ;

        }
    }
}
