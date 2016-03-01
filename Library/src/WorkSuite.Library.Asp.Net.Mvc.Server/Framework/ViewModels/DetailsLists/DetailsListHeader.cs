using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists {

    public class DetailsListHeader {

        public string title { get; set; }

        public IEnumerable<RoutedAction> actions { get; set; }

        public string description { get; set; }
    }

}