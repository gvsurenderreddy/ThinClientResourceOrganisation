using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New.Create;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New.GetCreateRequest;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New
{
    public class DependencyConfiguration
                            :   ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind< ICreateMaritalStatus >()
                .To < CreateMaritalStatus >()
                ;

            kernel
                .Bind< IGetCreateMaritalStatusRequest >()
                .To< GetCreateMaritalStatusRequest >()
                ;
        }
    }
}
