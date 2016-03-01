using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Workflow.Model
{
    public class ActionToDestinationDictionary : Dictionary<string, DestinationSet>
    {
        
    }


    public class DestinationSet
    {
        public List<Destination> success_destinations { get; set; }
        public Destination error_destination { get; set; }
    }
}
