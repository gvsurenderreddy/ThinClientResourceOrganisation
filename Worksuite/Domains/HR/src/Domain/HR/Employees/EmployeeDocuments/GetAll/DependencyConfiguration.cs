using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.GetAll
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
           .Bind<IGetAllEmployeeDocuments>()
           .To<GetAllEmployeeDocuments>()
           ;
        }
    }
}