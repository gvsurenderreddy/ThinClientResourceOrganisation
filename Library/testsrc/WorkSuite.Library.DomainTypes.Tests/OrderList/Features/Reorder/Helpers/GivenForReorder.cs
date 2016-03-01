using WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Features.Reorder.Helpers {

    public class GivenForReorder 
                    : Given<When> {

        public override When when ( ) {
             return new When( list );
        }

    }

}