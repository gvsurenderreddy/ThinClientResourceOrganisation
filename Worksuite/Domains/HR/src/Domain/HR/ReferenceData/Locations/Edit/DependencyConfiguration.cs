using Ninject;
using Ninject.Activation;
using System;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Edit.GetUpdateRequest;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Edit.Update;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Locations.Edit
{
    public class DependencyConfiguration
                    : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                       Func<IContext, object> scope
                                      )
        {
            kernel
                .Bind<IGetUpdateLocationRequest>()
                .To<GetUpdateLocationRequest>()
                ;

            kernel
                .Bind<IUpdateLocation>()
                .To<UpdateLocation>()
                ;
        }
    }
}