using WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Features.Insert.Helpers {

    public class GivenForInsert 
                    : Given<When> {


        public GivenForInsert an_element_to_be_inserted_at
                        ( int position ) {

            element_to_insert = new TestListElement {
                postion = position
            };
            return this;
        }

        public override When when ( ) {
            
            return new When( list, element_to_insert );
        }

    }

}