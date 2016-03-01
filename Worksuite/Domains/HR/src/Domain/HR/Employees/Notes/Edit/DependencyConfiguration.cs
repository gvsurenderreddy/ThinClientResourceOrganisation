using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.Employees.Notes.Edit
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
              .Bind<IGetUpdateRequest>()
              .To<GetUpdateNoteRequest>()
              ;

            kernel
                .Bind<IUpdate>()
                .To<UpdateNote>()
                ;

            kernel
                .Bind<ICanUpdateNote>()
                .To<CanUpdateNote>()
                ;
        }
    }
}