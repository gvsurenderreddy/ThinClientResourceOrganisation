using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.LookupField
{
    public class ALookupField: Field<int> {

        public IEnumerable<LookupValue> lookup_values { get; set; }

    }
   
}