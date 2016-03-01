using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.New.Create;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Genders.New {

    public class DependencyConfiguration
                    : ADependencyConfiguration {


        public override void configure
                                ( IKernel kernel
                                , Func<IContext, object> scope ) {
            
            kernel
                .Bind<ICreateGender>(  )
                .To<CreateGender>()
                ;

            kernel
                .Bind<IGetCreateGenderRequest>()
                .To<GetCreateGenderRequest>()
                ;
        }
    }
}