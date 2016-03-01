using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Library.Service.Specification.Helpers.Persistence {

    public class DependencyConfiguration : ADependencyConfiguration {


        public override void configure ( IKernel kernel, Func<IContext, object> scope ) {
            kernel.Rebind<IUnitOfWork, FakeUnitOfWork>( ).To<FakeUnitOfWork>( ).InScope( x => scope );            

        }

    }

}