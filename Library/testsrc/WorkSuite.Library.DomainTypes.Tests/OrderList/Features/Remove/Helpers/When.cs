using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.DomainTypes.OrderList;
using WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Features.Remove.Helpers {

    public class When {


        public When the_element_at_x_is_removed
                        ( int x ) {
            
            /* 
               employee
             *    .Addresses
             *    .Select( to_index_entry.map )
             *    .Remove( to_index_entry.map( new_address ) 
             *           , () => employee.Address.Add( new_address )
             *           );
            */
            var to_index_mapper = new ListEntryIndexMapper<TestListElement>
                                        ( m => m.postion
                                        , ( m, value ) => m.postion = value );

            list_to_remove_from
                .Select( to_index_mapper.map )
                .Remove( to_index_mapper.map( list_to_remove_from[ x-1 ])
                                , () => list_to_remove_from.Remove( list_to_remove_from[ x-1 ] ) )
                ;

            return this;
        }


        public ThenForRemove then() {
            return new ThenForRemove
                        ( list_prior_removal
                        ,list_to_remove_from );
        }

        public When
                ( List<TestListElement> the_list_to_remove_from ) {
            
            list_to_remove_from = the_list_to_remove_from;
            list_prior_removal = list_to_remove_from.ToList(  );
        }

        private readonly List<TestListElement> list_prior_removal;
        private readonly List<TestListElement> list_to_remove_from;
    }

}