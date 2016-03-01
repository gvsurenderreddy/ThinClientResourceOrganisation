using System;
using Ninject;
using Ninject.Activation;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.addSickness.get;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.addSickness.post;

namespace WTS.WorkSuite.SupplyShortage.Employee.Sickness.addSickness
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Bind<IGetAddSicknessRequestHandler>()
                .To<GetAddSicknessRequestHandler>()
                ;


            kernel
               .Bind<IAddSicknessRequestHandler>()
               .To<AddSicknessRequestHandler>()
               ;
        }
    }
}
