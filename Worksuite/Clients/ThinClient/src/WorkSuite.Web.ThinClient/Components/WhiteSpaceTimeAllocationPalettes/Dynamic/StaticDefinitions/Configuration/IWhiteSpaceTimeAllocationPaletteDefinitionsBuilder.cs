using System.Web.Mvc;

namespace WTS.WorkSuite.Web.ThinClient.Components.WhiteSpaceTimeAllocationPalettes.Dynamic.StaticDefinitions.Configuration
{
    public interface IWhiteSpaceTimeAllocationPaletteDefinitionsBuilder
    {
        void build(IDependencyResolver resolver);
    }
}