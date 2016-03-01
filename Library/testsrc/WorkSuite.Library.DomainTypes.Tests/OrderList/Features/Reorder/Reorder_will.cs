using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Features.Reorder.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Features.Reorder {

    [TestClass]
    public class Reorder_will {

        // up - move the element
        // up - move the element in between its starting position and its new position up one
        // up - not alter the position of elements either side of the starting and new position

        [TestMethod]
        public void when_moving_an_element_up_the_index_it_will_move_the_element ( ) {
            
            this
                .given
                .an_entry_in_the_list_at( 1 )
                .an_entry_in_the_list_at( 2 )
                .an_entry_in_the_list_at( 3 )
                .an_entry_in_the_list_at( 4 )
                .an_entry_in_the_list_at( 5 )

                .when()
                .element_x_is_moved_to_y( 2,4 )

                .then()
                .element_that_was_at_x_is_now_at_y( 2,4 )
                ;

        }

        [TestMethod]
        public void when_moving_an_element_up_the_index_it_will_move_the_element_in_between_its_starting_position_and_its_new_position_up_one () {
            
            this
                .given
                .an_entry_in_the_list_at( 1 )
                .an_entry_in_the_list_at( 2 )
                .an_entry_in_the_list_at( 3 )
                .an_entry_in_the_list_at( 4 )
                .an_entry_in_the_list_at( 5 )

                .when()
                .element_x_is_moved_to_y( 2,4 )

                .then()
                .element_that_was_at_x_is_now_at_y( 3, 2 )
                .element_that_was_at_x_is_now_at_y( 4, 3 )
                ;

        }

        [TestMethod]
        public void when_moving_an_element_up_the_index_it_will_not_alter_the_position_of_elements_either_side_of_the_starting_and_new_position () {
            
            this
                .given
                .an_entry_in_the_list_at( 1 )
                .an_entry_in_the_list_at( 2 )
                .an_entry_in_the_list_at( 3 )
                .an_entry_in_the_list_at( 4 )
                .an_entry_in_the_list_at( 5 )

                .when()
                .element_x_is_moved_to_y( 2,4 )

                .then()
                .element_that_was_at_x_is_now_at_y( 1, 1 )
                .element_that_was_at_x_is_now_at_y( 5, 5 )
                ;
        }



        [TestMethod]
        public void when_moving_an_element_down_the_index_it_will_move_the_element ( ) {
            
            this
                .given
                .an_entry_in_the_list_at( 1 )
                .an_entry_in_the_list_at( 2 )
                .an_entry_in_the_list_at( 3 )
                .an_entry_in_the_list_at( 4 )
                .an_entry_in_the_list_at( 5 )

                .when()
                .element_x_is_moved_to_y( 4,2 )

                .then()
                .element_that_was_at_x_is_now_at_y( 4,2 )
                ;

        }


        [TestMethod]
        public void when_moving_an_element_down_the_index_it_will_move_the_element_in_between_its_starting_position_and_its_new_position_down_one () {
            
            this
                .given
                .an_entry_in_the_list_at( 1 )
                .an_entry_in_the_list_at( 2 )
                .an_entry_in_the_list_at( 3 )
                .an_entry_in_the_list_at( 4 )
                .an_entry_in_the_list_at( 5 )

                .when()
                .element_x_is_moved_to_y( 4,2 )

                .then()
                .element_that_was_at_x_is_now_at_y( 2,3 )
                .element_that_was_at_x_is_now_at_y( 3,4 )
                ;
        }

        [TestMethod]
        public void when_moving_an_element_down_the_index_it_will_not_alter_the_position_of_elements_either_side_of_the_starting_and_new_position () {
            
            this
                .given
                .an_entry_in_the_list_at( 1 )
                .an_entry_in_the_list_at( 2 )
                .an_entry_in_the_list_at( 3 )
                .an_entry_in_the_list_at( 4 )
                .an_entry_in_the_list_at( 5 )

                .when()
                .element_x_is_moved_to_y( 4,2 )

                .then()
                .element_that_was_at_x_is_now_at_y( 1, 1 )
                .element_that_was_at_x_is_now_at_y( 5, 5 )
                ;
        }


        [TestMethod]
        public void when_an_element_is_not_moved_all_existing_postions_are_maintained () {
            
            this
                .given
                .an_entry_in_the_list_at( 1 )
                .an_entry_in_the_list_at( 2 )
                .an_entry_in_the_list_at( 3 )

                .when()
                .element_x_is_moved_to_y( 2,2 )

                .then()
                .element_that_was_at_x_is_now_at_y( 1, 1 )
                .element_that_was_at_x_is_now_at_y( 2, 2 )
                .element_that_was_at_x_is_now_at_y( 3, 3 )
                ;
        }

        [TestInitialize]
        public void before_each_test () {
            given = new GivenForReorder(  );
        }

        private GivenForReorder given; 
    }

}