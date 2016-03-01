using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Remove;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.Remove;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.EthnicOrigins
{
    public class DependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func< IContext, object > scope
                                      )
        {
            // Fake Ethnic Original Repository
            kernel
                .Rebind<    IQueryRepository< EthnicOrigin >,
                            IEntityRepository< EthnicOrigin >,
                            FakeEthnicOriginRepository
                       >()
                .To< FakeEthnicOriginRepository >()
                .InScope( x => scope )
                ;

            // Ethnic origin Builder
            kernel
                .Rebind< ReferenceDataBuilder< EthnicOrigin >,
                            EthnicOriginBuilder
                       >()
                .To< EthnicOriginBuilder >()
                ;

            kernel
                .Rebind<    IRequestHelper< CreateEthnicOriginRequest >,
                            NewEthnicOriginRequestHelper
                       >()
                .To< NewEthnicOriginRequestHelper >()
                ;

            kernel
                .Rebind<    IRequestHelper< UpdateEthnicOriginRequest >,
                            UpdateEthnicOriginRequestHelper
                       >()
                .To< UpdateEthnicOriginRequestHelper >()
                ;

            kernel
                .Rebind<    IRequestHelper< RemoveEthnicOriginRequest >,
                            RemoveEthnicOriginRequestHelper
                    >()
                .To< RemoveEthnicOriginRequestHelper > ()
                ;
        }
    }
}