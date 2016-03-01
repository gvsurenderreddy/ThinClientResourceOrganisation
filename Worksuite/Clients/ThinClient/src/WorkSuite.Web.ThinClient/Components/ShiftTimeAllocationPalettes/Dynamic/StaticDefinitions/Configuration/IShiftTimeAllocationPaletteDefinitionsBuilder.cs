using System.Web.Mvc;

namespace WTS.WorkSuite.Web.ThinClient.Components.ShiftTimeAllocationPalettes.Dynamic.StaticDefinitions.Configuration
{
    public interface IShiftTimeAllocationPaletteDefinitionsBuilder
    {
        void build(IDependencyResolver resolver);
    }
}