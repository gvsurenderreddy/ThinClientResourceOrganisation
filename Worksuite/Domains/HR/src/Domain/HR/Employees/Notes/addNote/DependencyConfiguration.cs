using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.Employees.Notes.addNote.get;
using WTS.WorkSuite.HR.HR.Employees.Notes.addNote.post;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.Employees.Notes.addNote
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
               .Bind<IGetAddNoteRequestHandler>()
               .To<GetAddNoteRequestHandler>()
               ;

            kernel
                .Bind<IAddNoteRequestHandler>()
                .To<AddNoteRequestHandler>()
                ;
        }
    }
}
