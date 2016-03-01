using System.Collections.Generic;
using WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Helpers;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.OrderList.Features.Reorder.Helpers {

    public class ThenForReorder
                    : Then {

        public ThenForReorder 
                       ( List<TestListElement> the_list ) 
                : base ( the_list ) {}

    }

}