using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.CodeStrutures.Tests.Behavioral {

    [TestClass]
    public class DefaultedLookup_will {

        // done: needs a default value specifying at construction time
        // done: return a registered value for a key that exists
        // done: return a the default value for a key that does not exist
        // done: overwrite existing values if the same key is registered twice

        [TestMethod]
        public void needs_a_default_value_specifying_at_construction_time ( ) {
           
            new DefaultedLookup<char,int>( -1 );
 
        }

        [TestMethod]
        public void register_is_a_fluent_interface () {
            
            lookup.register( 'a', 1 ).Should().Be(  lookup );
        }

        [TestMethod]
        public void return_a_registered_value_for_a_key_that_exists () {

            lookup.register( 'a', 1 )[ 'a' ].Should().Be( 1 );
        }

        [TestMethod]
        public void return_a_the_default_value_for_a_key_that_does_not_exist ( ) {

            lookup['a'].Should(  ).Be( default_value );            
        }

        [TestMethod]
        public void overwrite_existing_values_if_the_same_key_is_registered_twice () {
            
            lookup
                .register( 'a', 1 )
                .register( 'a',2 )
                ['a'].Should(  ).Be( 2 )
                ;
        }


        [TestInitialize]
        public void before_each_test() {
            lookup = new DefaultedLookup<char,int>( default_value );
        }

        private DefaultedLookup<char,int> lookup;
        private int default_value = -1;
    }
}