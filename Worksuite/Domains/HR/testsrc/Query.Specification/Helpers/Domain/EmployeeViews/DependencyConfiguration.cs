using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WTS.WorkSuite.HR.Query.Helpers.Domain.EmployeeViews
{

    public class DependencyConfiguration
                    : ADependencyConfiguration
    {

        public override void configure
                                (IKernel kernel
                                , Func<IContext, object> scope)
        {

            kernel
                .Rebind<IEntityRepository<EmployeeView>, FakeEmployeeRepository>()
                .To<FakeEmployeeRepository>()
                .InScope(scope)
                ;
        }
    }
}