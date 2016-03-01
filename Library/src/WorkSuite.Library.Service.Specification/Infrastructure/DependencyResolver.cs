using Ninject;

namespace WorkSuite.Library.Service.Specification.Infrastructure {

    public static class DependencyResolver {

        public static T resolve<T>( ) {
            return kernel.Get<T>(  );
            
        }

        public static readonly IKernel kernel = new StandardKernel();


    }

}