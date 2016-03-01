using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit.Update;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Edit
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Bind<IGetUpdateJobTitleRequest>()
                .To<GetUpdateJobTitleRequest>()
                ;

            kernel
                .Bind<IUpdateJobTitle>()
                .To<UpdateJobTitle>()
                ;
        }
    }
}