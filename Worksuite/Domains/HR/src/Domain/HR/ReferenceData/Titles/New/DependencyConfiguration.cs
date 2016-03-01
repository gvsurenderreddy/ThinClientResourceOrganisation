using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Titles.New {

    public class DependencyConfiguration 
                    : ADependencyConfiguration {

        public override void configure 
                                ( IKernel kernel
                                , Func<IContext, object> scope ) {
            
            kernel
                .Bind<ICreateTitle>(  )
                .To<CreateTitle>()
                ;

            kernel
                .Bind<IGetCreateTitleRequest>()
                .To<GetCreateTitleRequest>()
                ;
        }

    }

}