using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Queries
{
    public class DependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func< IContext, object > scope
                                      )
        {
            kernel
                .Bind< IGetDetailsOfAllEthnicOrigins >()
                .To< GetDetailsOfAllEthnicOrigins >()
                ;

            kernel
                .Bind< IGetDetailsOfASpecificEthnicOrigin >()
                .To< GetDetailsOfASpecificEthnicOrigin >()
                ;

            kernel
                .Bind< IGetDetailsOfEthnicOriginsEligibleForEmployee > ()
                .To< GetDetailsOfEthnicOriginsEligibleForEmployee > ()
                ;
        }
    }
}