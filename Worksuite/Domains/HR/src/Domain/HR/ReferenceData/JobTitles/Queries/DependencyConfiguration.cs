using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Queries
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                       Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind<IGetDetailsOfAllJobTitles>()
                .To<GetDetailsOfAllJobTitles>()
                ;

            kernel
                .Bind<IGetDetailsOfJobTitlesEligibleForEmployee>()
                .To<GetDetailsOfJobTitlesEligibleForEmployee>()
                ;
        }
    }
}