using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.Subsystems.Routing._1 {

    /// <summary>
    ///   Request format that is expected by the javascript route_url_builder module. The request specifies the 
    ///   route name and the values that should be used to in the routes url template. 
    /// </summary>
    public class CreateRouteUrlRequest {
        public string route_name { get; set; }
        public object route_parameters { get; set; }
    }
}
