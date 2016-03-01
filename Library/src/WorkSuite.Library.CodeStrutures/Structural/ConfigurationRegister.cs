using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.CodeStrutures.Structural {

    public class ConfigurationRegister<T,C> 
                : IConfiguration<T> 
        where C : IConfiguration<T> {

        public void configure ( T target_to_configure ) {
            
            Guard.IsNotNull( target_to_configure, "target_to_configure" );

            foreach ( var configuration in configurations ) {
                configuration.configure( target_to_configure );
            }             
        }

        public void register ( C configuration ) {
            Guard.IsNotNull( configuration, "configuration" );

            configurations.Add( configuration );
        }

        private readonly List<C> configurations = new List<C>( );

    }

}