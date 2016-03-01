using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists {

    public class DetailsList : IsAViewElement {

        public string id { get; set; }

        public DetailsListHeader header { get; set; }

        public IEnumerable<IsAViewElement> elements { get; set; }

        public string report_presenter_url { get; set; }

        public bool is_sortable { get; set; }
    }

}