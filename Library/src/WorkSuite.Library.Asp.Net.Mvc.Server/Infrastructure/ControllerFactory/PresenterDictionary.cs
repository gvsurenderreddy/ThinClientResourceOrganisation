using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory {

    /// <summary>
    ///     Dictionary of Types that implement the IPresenter interface
    /// </summary>
    public class PresenterDictionary {

        public Type GetPresenterType ( string presenter_name ) {
            Type presenter_type;

            cache.TryGetValue( presenter_name, out presenter_type );

            return presenter_type;
        }
        
        static PresenterDictionary () {
            
            var presenter_interface  = typeof (IPresenter);
            

            cache = AppDomain
                     .CurrentDomain
                     .GetAssemblies()
                     .SelectMany( a => a.GetTypes() )
                     .Where( presenter_interface.IsAssignableFrom )
                     .ToDictionary(  t => t.Name, t => t )
                     ;

        }

        private static readonly IDictionary<string, Type> cache;
    }
}