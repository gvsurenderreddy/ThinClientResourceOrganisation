using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Features.Insert.Helpers {

    public class ThenForInsert 
                    : Then {

        public ThenForInsert the_element_has_been_added_to_the_list ( ) {

            list.Should( ).Contain( element );
            return this;
        }

        public ThenForInsert the_inserted_element_is_at 
                        ( int expected_position ) {

            list.Single( e => e == element ).postion.Should(  ).Be( expected_position );
            return this;
        }

        public ThenForInsert the_index_entry_is_unique 
                        ( int i ) {
            
            list.Count( e => e.postion == i ).Should(  ).Be( 1 );
            return this;
        }

        public ThenForInsert the_list_contains_n_elements 
                        ( int expected_number_of_elements ) {

            list.Count().Should(  ).Be( expected_number_of_elements );
            return this;            
        }

        public ThenForInsert the_index_is_contiguous ( ) {
            var previous = 0;
            var is_contiguous = true;

            list
                .OrderBy( e => e.postion )
                .Do( e => { is_contiguous = is_contiguous && (e.postion == previous+1);
                            previous = e.postion ;})
                ;

            is_contiguous.Should(  ).BeTrue(  );
            return this;
        }

        public ThenForInsert an_out_of_range_exception_was_thrown ( ) {
            
            exception_thrown.Should(  ).BeOfType<ArgumentException>(  );
            return this;
        }



        public ThenForInsert 
                ( List<TestListElement> the_list
                , TestListElement the_element 
                , Exception the_exception_thrown ) 
            : base (  the_list ) {

            element = the_element;
            exception_thrown = the_exception_thrown;
        }

        private readonly TestListElement element;
        private readonly Exception exception_thrown;
    }

}