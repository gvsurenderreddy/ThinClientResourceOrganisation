using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Titles.Queries {

    public class DependencyConfiguration
                    : ADependencyConfiguration {

        public override void configure 
                                ( IKernel kernel
                                , Func<IContext, object> scope ) {

            kernel
                .Bind<IGetDetailsOfASpecificTitle>()
                .To<GetDetailsOfASpecificTitle>()
                ;
            
            kernel
                .Bind<IGetDetailsOfAllTitles>(  )
                .To<GetDetailsOfAllTitles>()
                ;

            kernel
                .Bind<IGetDetailsOfTitlesEligibleForEmployee>()
                .To<GetDetailsOfTitlesEligibleForEmployee>()
                ;
        }

    }

}