using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Features.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Features.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Features.Remove;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Nationalities
{
    public class DependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func< IContext, object > scope
                                      )
        {
            // Fake Nationality repository
            kernel
                .Rebind<    IQueryRepository< Nationality >,
                            IEntityRepository< Nationality >,
                            FakeNationalityRepository
                       >()
                .To< FakeNationalityRepository >()
                .InScope( x => scope )
                ;

            // Nationality Builder
            kernel
                .Rebind<    ReferenceDataBuilder< Nationality >,
                            NationalityBuilder
                       >()
                .To< NationalityBuilder >()
                ;

            kernel
                .Rebind<    IRequestHelper< CreateNationalityRequest >,
                            NewNationalityRequestHelper >()
                .To< NewNationalityRequestHelper >()
                ;

            kernel
                .Rebind<    IRequestHelper< UpdateNationalityRequest >,
                            UpdateNationalityRequestHelper>()
                .To< UpdateNationalityRequestHelper >()
                ;

            kernel
                .Rebind<    IRequestHelper< RemoveNationalityRequest >,
                            RemoveNationalityRequestHelper >()
                .To< RemoveNationalityRequestHelper >()
                ;
        }
    }
}