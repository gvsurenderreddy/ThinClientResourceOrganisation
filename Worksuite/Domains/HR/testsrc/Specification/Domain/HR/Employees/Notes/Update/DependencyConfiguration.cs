using Ninject;
using Ninject.Activation;
using System;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.Employees.Notes.Edit;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Notes.Update
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                       Func<IContext, object> scope
                                      )
        {
            kernel
                .Rebind<IRequestHelper<UpdateRequest>,
                    UpdateNoteRequestHelper>()
                .To<UpdateNoteRequestHelper>()
                ;
        }
    }
}