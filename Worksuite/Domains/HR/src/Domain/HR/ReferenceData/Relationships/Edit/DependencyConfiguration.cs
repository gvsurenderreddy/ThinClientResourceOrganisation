using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit.Update;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit {

    public class DependencyConfiguration 
                    : ADependencyConfiguration {

        public override void configure
                                ( IKernel kernel
                                , Func<IContext, object> scope ) {

            kernel
                .Bind<IGetUpdateRelationshipRequest>()
                .To<GetUpdateRelationshipRequest>()
                ;

            kernel
                .Bind<IUpdateRelationship>()
                .To<UpdateRelationship>()
                ;
        }
    }
}