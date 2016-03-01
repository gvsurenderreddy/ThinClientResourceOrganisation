using System;
using System.ComponentModel.Composition;
using Ninject;
using Ninject.Activation;

namespace WTS.WorkSuite.Library.Ninject.Configuration {
    
    [InheritedExport(typeof(IDependencyConfiguration))]
    public abstract class ADependencyConfiguration : IDependencyConfiguration {

        public abstract void configure ( IKernel kernel, Func<IContext, object> scope );
    }

}