using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Helpers {

    public class Then {

        public Then element_that_was_at_x_is_now_at_y 
                        ( int x
                        , int y ) {
            
            var lement_originally_at_x = list
                                            .Where( e => e.initial_position == x )
                                            .DefaultIfEmpty( new TestListElement {initial_position = -1, postion = -1} )
                                            .First(  );
            

            lement_originally_at_x.postion.Should(  ).Be( y );
            return this;
        }
         
        public Then 
                ( List<TestListElement> the_list ) {

            list = the_list;
        }

        protected readonly List<TestListElement> list;
    }

}