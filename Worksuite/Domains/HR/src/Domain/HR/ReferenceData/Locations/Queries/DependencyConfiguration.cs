using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Locations.Queries
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                       Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind<IGetDetailsOfAllLocations>()
                .To<GetDetailsOfAllLocations>()
                ;

            kernel
                .Bind<IGetDetailsOfLocationsEligibleForEmployee>()
                .To<GetDetailsOfLocationsEligibleForEmployee>()
                ;
        }
    }
}