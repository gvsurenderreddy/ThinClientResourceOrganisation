using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Features.Insert.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Features.Insert {

    [TestClass]
    public class Insert_will {

        // NOTE - the first position is 1

        // done: add an element to the list
        // done: add the element to the correct position in the index
        // done: ensure that the entry is unique in the index
        // done: will maintain contiguous nature of the index
        // done: moves elements that it is inserted above down by one in the index
        // done: you can not insert before the first position in the list
        // done: you can not insert beyond the last valid position in the list

        [TestMethod]
        public void add_an_element_to_the_list ( ) {
            
            this
                .given
                .an_element_to_be_inserted_at( 1 )

                .when()
                .the_element_is_inserted()

                .then()
                .the_element_has_been_added_to_the_list( )
                ;
        }

        [TestMethod]
        public void add_the_element_to_the_correct_position_in_the_index () {
            
            this
                .given
                .an_element_to_be_inserted_at( 1 )
                .an_entry_in_the_list_at( 1 )

                .when()
                .the_element_is_inserted( )

                .then()
                .the_inserted_element_is_at( 1 )
                ;
        }

        [TestMethod]
        public void ensure_that_the_entry_is_unique_in_the_index () {
            
            this
                .given
                .an_element_to_be_inserted_at( 1 )
                .an_entry_in_the_list_at( 1 )

                .when()
                .the_element_is_inserted(  )
                
                .then(  )
                .the_index_entry_is_unique( 1 )
                ;
        }

        [TestMethod]
        public void will_maintain_contiguous_nature_of_the_index () {
            
            this
                .given
                .an_element_to_be_inserted_at( 2 )
                .an_entry_in_the_list_at( 1 )
                .an_entry_in_the_list_at( 2 )
                .an_entry_in_the_list_at( 3 )

                .when()
                .the_element_is_inserted(  )
                
                .then()
                .the_index_is_contiguous()
                ;
        }

        [TestMethod]
        public void moves_elements_that_it_is_inserted_above_down_by_one_in_the_index ( ) {

            this
                .given
                .an_element_to_be_inserted_at( 2 )
                .an_entry_in_the_list_at( 1 )
                .an_entry_in_the_list_at( 2 )
                .an_entry_in_the_list_at( 3 )

                .when()
                .the_element_is_inserted(  )

                .then()
                .element_that_was_at_x_is_now_at_y( 1,1 )
                .element_that_was_at_x_is_now_at_y( 2,3 )
                .element_that_was_at_x_is_now_at_y( 3,4 )
                ;           
        }

        [TestMethod]
        public void you_can_not_insert_before_the_first_position_in_the_list () {
            
            this
                .given
                .an_element_to_be_inserted_at( 0 )

                .when(  )
                .the_element_is_inserted(  )

                .then(  )
                .an_out_of_range_exception_was_thrown()
                ;

        }

        [TestMethod]
        public void you_can_not_insert_after_the_last_position_in_the_list () {
            
            // NOTE - the last position that you can insert into a list is after the last 
            //        element in the index, this make updating the position of the elements
            //        that are to be moved when inserting a simple increment of each elements
            //        position.  If we allowed gaps in the list then we would have to check 
            //        whether we are still in a contiguous region which while not a nightmare
            //        I do not have any need for at the moment.
            //
            //        e.g. if an index has one entry then the last position that you can insert into 
            //             is position two

            this
                .given
                .an_element_to_be_inserted_at( 2 )

                .when(  )
                .the_element_is_inserted(  )

                .then(  )
                .an_out_of_range_exception_was_thrown()
                ;

        }


        [TestInitialize]
        public void before_each_test () {
            given = new GivenForInsert(  );
        }

        private GivenForInsert given;
 


    }

}