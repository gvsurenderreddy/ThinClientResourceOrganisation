using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.DomainTypes.OrderList;
using WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Features.Reorder.Helpers {

    public class When {

        public When element_x_is_moved_to_y 
                        ( int x
                        , int y ) {

            var to_index_mapper = new ListEntryIndexMapper<TestListElement>
                                        ( m => m.postion
                                        , ( m, value ) => m.postion = value );

            list_to_reorder
                .Select( to_index_mapper.map )
                .Move( new MoveIndexEntryRequest {
                    from = x,
                    to = y });

            return this;
        }


        public ThenForReorder then( ) {
            return new ThenForReorder( list_to_reorder );
        }

        public When 
                ( List<TestListElement> the_list_to_reorder ) {
            
            list_to_reorder = the_list_to_reorder;
        }

        private readonly List<TestListElement> list_to_reorder;
    }

}