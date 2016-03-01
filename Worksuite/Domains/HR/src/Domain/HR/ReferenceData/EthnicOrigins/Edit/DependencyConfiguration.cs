using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit.Update;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit
{
    public class DependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func< IContext, object > scope
                                      )
        {
            kernel
                .Bind< IUpdateEthnicOrigin >()
                .To< UpdateEthnicOrigin >()
                ;

            kernel
                .Bind< IGetUpdateEthnicOriginRequest >()
                .To< GetUpdateEthnicOriginRequest >()
                ;
        }
    }
}