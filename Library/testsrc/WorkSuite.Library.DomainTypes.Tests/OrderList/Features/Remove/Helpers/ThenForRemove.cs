using System.Collections.Generic;
using FluentAssertions;
using WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Features.Remove.Helpers {

    public class ThenForRemove 
                    : Then {

        public ThenForRemove the_element_that_was_at_x_has_been_removed 
                                ( int x ) {
            
            list.Contains( list_before_remove[ x-1 ] ).Should().BeFalse(  );
            return this;
        }

        public ThenForRemove the_list_is_empty () {

            list.Should(  ).BeEmpty(  );
            return this;
            
        }

        public ThenForRemove
                ( List<TestListElement> the_list_before_remove 
                , List<TestListElement> the_list_after_remove ) 
                : base ( the_list_after_remove ) {
            
            list_before_remove = the_list_before_remove;
        }
        
        private readonly List<TestListElement> list_before_remove;

    }
}