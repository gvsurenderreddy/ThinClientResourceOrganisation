using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.Remove;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Titles {

    public class DependencyConfiguration 
                    : ADependencyConfiguration {

        public override void configure
                                ( IKernel kernel
                                , Func<IContext, object> scope ) {
            
            // repository
            kernel
              .Rebind< IQueryRepository<Title>
                     , IEntityRepository<Title>
                     , FakeTitleRepository>()

              .To<FakeTitleRepository>()

              .InScope(x => scope)
              ;


            // builder
            kernel
              .Rebind< ReferenceDataBuilder<Title>
                     , TitleBuilder >()

              .To<TitleBuilder>()
              ;


            kernel
                .Rebind< IRequestHelper<CreateTitleRequest>
                       , NewTitleRequestHelper>()

                .To<NewTitleRequestHelper>()
                ;


            kernel
               .Rebind< IRequestHelper<UpdateTitleRequest>
                      , UpdateTitleRequestHelper>()
               .To<UpdateTitleRequestHelper>()
               ;

            kernel
               .Rebind< IRequestHelper<RemoveTitleRequest>
                      , RemoveTitleRequestHelper>()
               .To<RemoveTitleRequestHelper>()
               ;

        }
    }
}