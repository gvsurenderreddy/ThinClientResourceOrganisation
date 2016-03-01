using System.Collections.Generic;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.LookupField {

    public interface ILookupFieldValuesRepository<S> {

        IEnumerable<LookupValue> values_for ( string key );

    }

}