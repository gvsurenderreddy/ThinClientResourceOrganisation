using System.Reflection;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.Constructors.FieldBuilder {

    public interface IBuilder<S> {

        Field build( S source, PropertyInfo property );


    }

}