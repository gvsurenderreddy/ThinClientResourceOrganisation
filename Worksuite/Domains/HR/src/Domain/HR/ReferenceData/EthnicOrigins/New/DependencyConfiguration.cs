using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New.Create;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New.GetCreateRequest;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New
{
    public class DependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func< IContext, object > scope
                                      )
        {
            kernel
                .Bind< ICreateEthnicOrigin > ()
                .To< CreateEthnicOrigin > ()
                ;

            kernel
                .Bind< IGetCreateEthnicOriginRequest >()
                .To< GetCreateEthnicOriginRequest > ()
                ;
        }
    }
}