using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Relationships.Remove;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Relationships
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {

        public override void configure
                                (IKernel kernel
                                , Func<IContext, object> scope)
        {

            // repository
            kernel
              .Rebind<IQueryRepository<Relationship>
                     , IEntityRepository<Relationship>
                     , FakeRelationshipRepository>()

              .To<FakeRelationshipRepository>()

              .InScope(x => scope)
              ;


            // builder
            kernel
              .Rebind<ReferenceDataBuilder<Relationship>
                     , RelationshipBuilder>()

              .To<RelationshipBuilder>()
              ;

            kernel
                .Rebind<IRequestHelper<CreateRelationshipRequest>
                       , NewRelationshipRequestHelper>()

                .To<NewRelationshipRequestHelper>()
                ;


            kernel
                .Rebind<IRequestHelper<UpdateRelationshipRequest>
                       , UpdateRelationshipRequestHelper>()

                .To<UpdateRelationshipRequestHelper>()
                ;

            kernel
                .Rebind<IRequestHelper<RemoveRelationshipRequest>
                       , RemoveRelationshipRequestHelper>()

                .To<RemoveRelationshipRequestHelper>()
                ;


        }
    }
}