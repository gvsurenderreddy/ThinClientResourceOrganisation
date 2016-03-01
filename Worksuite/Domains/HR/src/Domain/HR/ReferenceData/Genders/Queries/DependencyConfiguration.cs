using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Genders.Queries {

    public class DependencyConfiguration 
                    : ADependencyConfiguration {

        public override void configure 
                                ( IKernel kernel
                                , Func<IContext, object> scope ) {

            kernel
                .Bind<IGetDetailsOfASpecificGender>()
                .To<GetDetailsOfASpecificGender>()
                ;

            kernel
                .Bind<IGetDetailsOfAllGenders>( )
                .To<GetDetailsOfAllGenders>()
                ;

            kernel
                .Bind<IGetDetailsOfGendersEligibleForEmployee>( )
                .To<GetDetailsOfGendersEligibleForEmployee>()
                ;
        }
    }
}