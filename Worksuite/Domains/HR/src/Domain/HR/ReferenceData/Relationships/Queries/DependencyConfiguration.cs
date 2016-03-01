using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Queries
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {

        public override void configure
                                (IKernel kernel
                                , Func<IContext, object> scope)
        {

            kernel
                .Bind<IGetDetailsOfASpecificRelationship>()
                .To<GetDetailsOfASpecificRelationship>()
                ;

            kernel
                .Bind<IGetDetailsOfAllRelationships>()
                .To<GetDetailsOfAllRelationships>()
                ;

            kernel
                .Bind<IGetDetailsOfRelationshipsEligibleForEmergencyContact>()
                .To<GetDetailsOfRelationshipsEligibleForEmergencyContact>()
                ;
        }
    }
}