using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New.Create;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New.GetCreateRequest;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New
{

    public class DependencyConfiguration
                    : ADependencyConfiguration
    {


        public override void configure
                                (IKernel kernel
                                , Func<IContext, object> scope)
        {

            kernel
                .Bind<ICreateRelationship>()
                .To<CreateRelationship>()
                ;

            kernel
                .Bind<IGetCreateRelationshipRequest>()
                .To<GetCreateRelationshipRequest>()
                ;
        }
    }
}