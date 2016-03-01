using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.SectionedTileGrid.StaticallyDefined.Builder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids.StaticallyDefined.Builder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids.StaticallyDefined.Metadata.Model;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Definitions;
using WTS.WorkSuite.Library.Ninject.Configuration;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.DependencyConfiguration
{
    public class TileConfiguration
                        : ADependencyConfiguration
    {
        public override void configure( IKernel kernel,
                                        Func< IContext, object > scope
                                      )
        {
            kernel
                .Bind< StaticSectionedTileGridBuilder >()
                .To< StaticSectionedTileGridBuilder >()
                ;

            kernel
                .Bind< StaticTileStaticDefinitionBuilder >()
                .To< StaticTileStaticDefinitionBuilder >()
                ;

            kernel
                .Bind< BuildStaticTileFromStaticDefinition >()
                .To< BuildStaticTileFromStaticDefinition >()
                ;

            kernel
                .Bind< StaticTileGridMetadata >()
                .To< StaticTileGridMetadata >()
                ;

            kernel
                .Bind< StaticTileGridBuilder >()
                .To< StaticTileGridBuilder >()
                ;
        }
    }
}