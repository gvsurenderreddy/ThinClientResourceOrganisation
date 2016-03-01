using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.Remove;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.MaritalStatuses {

    public class DependencyConfiguration
                    : ADependencyConfiguration {

        public override void configure
                                ( IKernel kernel
                                , Func<IContext, object> scope ) {
            
            // repository
            kernel
              .Rebind< IQueryRepository<MaritalStatus>
                     , IEntityRepository<MaritalStatus>
                     , FakeMaritalStatusRepository>()

              .To<FakeMaritalStatusRepository>()

              .InScope(x => scope)
              ;


            // builder
            kernel
              .Rebind< ReferenceDataBuilder<MaritalStatus>
                     , MaritalStatusBuilder>()

              .To<MaritalStatusBuilder>()
              ;


            kernel
               .Rebind<IRequestHelper<CreateMaritalStatusRequest>,
                        NewMaritalStatusRequestHelper>()
               .To<NewMaritalStatusRequestHelper>()
               ;

            kernel
               .Rebind<IRequestHelper<UpdateMaritalStatusRequest>,
                        UpdateMaritalStatusRequestHelper>()
               .To<UpdateMaritalStatusRequestHelper>()
               ;

            kernel
               .Rebind<IRequestHelper<RemoveMaritalStatusRequest>,
                        RemoveMaritalStatusRequestHelper>()
               .To<RemoveMaritalStatusRequestHelper>()
               ;

        }
    }
}