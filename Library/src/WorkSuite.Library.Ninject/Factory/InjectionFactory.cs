using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Activation;
using Ninject.Parameters;
using WTS.WorkSuite.Library.CodeStrutures.Creational;

namespace WTS.WorkSuite.Library.Ninject.Factory
{
    public class NinjectDependencyFactory<T> : IFactory<T>
    {
        private readonly IKernel _kernel;
        private readonly IParameter[] _contextParameters;

        public NinjectDependencyFactory(IContext injectionContext)
        {
            _contextParameters = injectionContext.Parameters
                                                    .Where(p => p.ShouldInherit)
                                                    .ToArray();
            _kernel = injectionContext.Kernel;
        }

        public T create()
        {
            try
            {
                return _kernel.Get<T>(_contextParameters.ToArray());
            }
            catch (Exception)
            {
                throw new Exception(
                    string.Format("An error occurred while attempting to instantiate an object of type <{0}>",
                        typeof (T)));
            }
        }
    }
}
