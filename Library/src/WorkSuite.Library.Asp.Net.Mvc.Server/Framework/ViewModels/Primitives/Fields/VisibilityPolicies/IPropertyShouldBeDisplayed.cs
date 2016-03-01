using System.Reflection;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.VisibilityPolicies {

    /// <summary>
    ///     Policy that is used to decide if a property should be displayed.
    /// </summary>
    public interface IPropertyShouldBeDisplayed : IPolicy<PropertyInfo> { }

}