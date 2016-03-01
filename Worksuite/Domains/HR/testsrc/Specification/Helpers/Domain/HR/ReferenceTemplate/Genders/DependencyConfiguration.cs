using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.Remove;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Genders {

    public class DependencyConfiguration
                    : ADependencyConfiguration {

        public override void configure
                                ( IKernel kernel
                                , Func<IContext, object> scope ) {
            
            // repository
            kernel
              .Rebind< IQueryRepository<Gender>
                     , IEntityRepository<Gender>
                     , FakeGenderRepository>()

              .To<FakeGenderRepository>()

              .InScope(x => scope)
              ;


            // builder
            kernel
              .Rebind< ReferenceDataBuilder<Gender>
                     , GenderBuilder>()

              .To<GenderBuilder>()
              ;

            kernel
                .Rebind< IRequestHelper<CreateGenderRequest>
                       , NewGenderRequestHelper>()

                .To<NewGenderRequestHelper>()
                ;


            kernel
                .Rebind< IRequestHelper<UpdateGenderRequest>
                       , UpdateGenderRequestHelper>()

                .To<UpdateGenderRequestHelper>()
                ;

            kernel
                .Rebind< IRequestHelper<RemoveGenderRequest>
                       , RemoveGenderRequestHelper>()

                .To<RemoveGenderRequestHelper>()
                ;


        }
    }
}