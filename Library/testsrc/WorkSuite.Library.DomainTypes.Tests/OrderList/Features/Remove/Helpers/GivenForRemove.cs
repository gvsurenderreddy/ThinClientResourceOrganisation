using WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Features.Remove.Helpers {

    public class GivenForRemove 
                    : Given<When>{

        public override When when ( ) {
            return new When( list );
        }

    }

}