using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.New
{
    public class NewEmployeeDocumentDependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
               .Bind<IGetNewEmployeeDocumentRequest>()
               .To<GetNewEmployeeDocumentRequest>()
               ;

            kernel
                .Bind<INewEmployeeDocument>()
                .To<NewEmployeeDocument>()
                ;


            kernel
              .Bind<INewEmployeeDocumentValidator>()
              .To<NewEmployeeDocumentValidator>()
              ;
        }
    }
}