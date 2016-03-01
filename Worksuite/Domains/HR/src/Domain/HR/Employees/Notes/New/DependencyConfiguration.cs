using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.Employees.Notes.New
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
              .Bind<IGetNewNoteRequest>()
              .To<GetNewNoteRequest>()
              ;

            kernel
                .Bind<INewNote>()
                .To<NewNote>()
                ;

            kernel
               .Bind<ICanAddNewNote>()
               .To<CanAddNewNote>()
               ;
        }
    }
}