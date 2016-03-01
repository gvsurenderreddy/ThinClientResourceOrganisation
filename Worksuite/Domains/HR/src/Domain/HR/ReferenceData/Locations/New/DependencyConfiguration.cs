using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.New.Create;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.New.GetCreateRequest;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Locations.New
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                       Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind<IGetCreateLocationRequest>()
                .To<GetCreateLocationRequest>()
                ;

            kernel
                .Bind<ICreateLocation>()
                .To<CreateLocation>()
                ;
        }
    }
}