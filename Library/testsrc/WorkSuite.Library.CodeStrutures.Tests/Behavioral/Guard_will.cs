using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.CodeStrutures.Tests.Behavioral {

    public class Guard_will {


        [TestClass]
        public class IsNotNull_will {

            [TestMethod]
            public void let_an_instance_argument_pass ( ) {
                
                Guard.IsNotNull( new {}, "{}" );
            }


            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void catch_a_null_argument ( ) {
                
                Guard.IsNotNull( null, "null" );
            }

            
        }
        
        [TestClass]
        public class PredicateHolds {

            // done: let a predicate that holds pass
            // done: throw an argument exception if the predicated does not hold

            [TestMethod]
            public void let_a_predicate_that_holds_pass ( ) {
                
                Guard.PremiseHolds( true, "error message" );
            }


            [TestMethod]
            public void throw_an_argument_exception_if_the_predicated_does_not_hold ( ) {
                
                Action act = () => Guard.PremiseHolds( false, "error message" );
                
                act.ShouldThrow<ArgumentException>(  ).WithMessage( "error message" );
            }
        }

    }

}