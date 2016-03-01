using System;
using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.DomainTypes.OrderList;
using WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Features.Insert.Helpers {

    public class When {

        public When 
                ( List<TestListElement> the_list_to_insert_into
                , TestListElement the_element_to_order ) {

            list_to_insert_into = the_list_to_insert_into;
            element_to_order = the_element_to_order;
        }

        public When the_element_is_inserted ( ) {

            /* 
               employee
             *    .Addresses
             *    .Select( to_index_entry.map )
             *    .Insert( to_index_entry.map( new_address ) 
             *           , () => employee.Address.Add( new_address )
             *           );
            */

            try {
                var to_index_mapper = new ListEntryIndexMapper<TestListElement>
                                            ( m => m.postion
                                            , ( m, value ) => m.postion = value );
            
                list_to_insert_into
                    .Select( to_index_mapper.map )
                    .Insert( to_index_mapper.map( element_to_order )
                           , () => list_to_insert_into.Add( element_to_order ))
                    ;
                
            } catch ( Exception e) {
                exception_thrown = e;
            }

            return this;
        }

        public ThenForInsert then () {
            
            return new ThenForInsert
                        ( list_to_insert_into
                        , element_to_order
                        , exception_thrown );
        }

        private readonly List<TestListElement> list_to_insert_into;
        //private readonly IEnumerable<IListEntryIndex> orderable_list;
        private readonly TestListElement element_to_order;
        private Exception exception_thrown;

    }

}