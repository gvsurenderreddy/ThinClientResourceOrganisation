using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.LookupField;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static.Lookup {

    public class LookupFieldValuesRepository<S> : ILookupFieldValuesRepository<S> {

        public IEnumerable<LookupValue> values_for ( string key ) {
            
            return repository.ContainsKey( key ) ? repository[ key ] : new LookupValue[]{};
        }

        public void set_vaules
            ( string key
            , IEnumerable<LookupValue> values ) {

            repository[ key ] = values;
        }

        private readonly Dictionary<string,IEnumerable<LookupValue>> repository = new Dictionary<string,IEnumerable<LookupValue>> ();
    }

}