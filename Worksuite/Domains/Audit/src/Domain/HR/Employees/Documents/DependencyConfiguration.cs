using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.Events;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.Audit.HR.Employees.Documents
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                       Func<IContext, object> scope
                                      )
        {
            kernel
               .Bind<IEventSubscriber<EmployeeDocumentUploadedEvent>>()
               .To<AddDocumentDetailsAuditRecordWhenDocumentIsUploaded>()
               .InScope(scope)
               ;

            kernel
               .Bind<IEventSubscriber<EmployeeDocumentRemovedEvent>>()
               .To<AddDocumentDetailsAuditRecordWhenDocumentIsRemoved>()
               .InScope(scope)
               ;
        }
    }
}