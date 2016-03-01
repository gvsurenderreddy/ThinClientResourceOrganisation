using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors {

    public class Editor : IsAViewElement {

        public string id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public string data_type { get; set; }

        public IEnumerable<Field> fields { get; set; }
        public IEnumerable<RoutedAction> actions { get; set; }

    }
}