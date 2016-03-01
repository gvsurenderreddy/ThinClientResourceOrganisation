using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Remove {

    public class DependencyConfiguration
                    : ADependencyConfiguration {


        public override void configure
                                ( IKernel kernel
                                , Func<IContext, object> scope ) {

            kernel
                .Bind<IRemoveRelationship>()
                .To<RemoveRelationship>()
                ;
        }
    }
}