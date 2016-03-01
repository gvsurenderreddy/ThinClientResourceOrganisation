using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Features.Remove.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Features.Remove {

    [TestClass]
    public class Remove_will {

        // done: remove an element from the list
        // done: moves elements that it is above up by one in the index
        // done: work when removing the only element in an index

        [TestMethod]
        public void remove_an_element_from_the_list ( ) {
            
            this
                .given
                .an_entry_in_the_list_at( 1 )
                .an_entry_in_the_list_at( 2 )
                
                .when()
                .the_element_at_x_is_removed( 2 )

                .then()
                .the_element_that_was_at_x_has_been_removed( 2 )
                ;
        }

        [TestMethod]
        public void moves_elements_that_it_is_above_up_by_one_in_the_index ( ) {
            
            this
                .given
                .an_entry_in_the_list_at( 1 )
                .an_entry_in_the_list_at( 2 )
                .an_entry_in_the_list_at( 3 )
                .an_entry_in_the_list_at( 4 )

                .when()
                .the_element_at_x_is_removed( 2 )

                .then()
                .element_that_was_at_x_is_now_at_y( 3,2 )
                .element_that_was_at_x_is_now_at_y( 4,3 )
                ;

        }

        [TestMethod]
        public void work_when_removing_the_only_element_in_an_index ( ) {

            this
                .given
                .an_entry_in_the_list_at( 1 )

                .when()
                .the_element_at_x_is_removed( 1 )

                .then()
                .the_list_is_empty( )
                ;
            
        }

        [TestInitialize]
        public void before_each_test () {
            given = new GivenForRemove(  );
        }

        private GivenForRemove given;
 
    }

}