using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New.Create;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New.GetCreateRequest;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.New
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                       Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind<IGetCreateJobTitleRequest>()
                .To<GetCreateJobTitleRequest>()
                ;

            kernel
                .Bind<ICreateJobTitle>()
                .To<CreateJobTitle>()
                ;
        }
    }
}