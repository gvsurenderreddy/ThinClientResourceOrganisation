using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Queries
{
    public class DependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                        Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind<IGetDetailsOfAllMaritalStatuses>()
                .To<GetDetailsOfAllMaritalStatuses>()
                ;

            kernel
                .Bind<IGetDetailsOfASpecificMaritalStatus>()
                .To<GetDetailsOfASpecificMaritalStatus>()
                ; 
            kernel
                .Bind<IGetDetailsOfMaritalStatusesEligibleForEmployee>()
                .To<GetDetailsOfMaritalStatusesEligibleForEmployee>()
                ;
        }
    }
}
