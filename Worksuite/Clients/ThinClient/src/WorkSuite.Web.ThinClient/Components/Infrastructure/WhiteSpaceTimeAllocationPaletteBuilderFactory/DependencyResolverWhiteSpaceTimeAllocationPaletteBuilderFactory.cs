using System.Web.Mvc;
using WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.WhiteSpaceTimeAllocationPalette;
using WTS.WorkSuite.Web.ThinClient.Components.WhiteSpaceTimeAllocationPalettes.Dynamic;

namespace WTS.WorkSuite.Web.ThinClient.Components.Infrastructure.WhiteSpaceTimeAllocationPaletteBuilderFactory
{
    public class DependencyResolverWhiteSpaceTimeAllocationPaletteBuilderFactory<S> where S : WhiteSpacePaletteDetails
    {
        public BuildDynamicWhiteSpaceTimeAllocationPaletteFromStaticDefinition<S> create_builder()
        {
            return DependencyResolver.Current.GetService<BuildDynamicWhiteSpaceTimeAllocationPaletteFromStaticDefinition<S>>();
        }
    }
}