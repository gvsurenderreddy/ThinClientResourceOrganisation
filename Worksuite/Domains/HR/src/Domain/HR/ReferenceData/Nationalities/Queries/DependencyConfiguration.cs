using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Queries
{
    public class DependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func< IContext, object > scope
                                      )
        {
            kernel
                .Bind< IGetDetailsOfAllNationalities >()
                .To< GetDetailsOfAllNationalities >()
                ;

            kernel
                .Bind< IGetDetailsOfASpecificNationality >()
                .To< GetDetailsOfASpecificNationality >()
                ;

            kernel
                .Bind< IGetDetailsOfNationalitiesEligibleForEmployee >()
                .To< GetDetailsOfNationalitiesEligibleForEmployee >()
                ;
        }
    }
}