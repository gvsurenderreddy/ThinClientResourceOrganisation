namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.Tiles._1 {

    /// <summary>
    /// Descendents identify what type of call to action a tile is
    /// </summary>
    public abstract class TileCallToActionModifier {
        public abstract string modifier { get; }
    }

    /// <summary>
    /// Identifies the tile as not having a call to action type.
    /// </summary>
    public class TileDoesNotHaveACallToAction
                    : TileCallToActionModifier {

        public override string modifier{ get { return string.Empty; }}
    }

    /// <summary>
    /// Identifies a tile as a primary call to action
    /// </summary>
    public class TileIsAPrimaryCallToAction
                    : TileCallToActionModifier {
        
        public override string modifier{ get { return "Tile_Primary"; }}
    }

    /// <summary>
    /// Identifies a tile as a secondary call to action
    /// </summary>
    public class TileIsASecondaryCallToAction
                    : TileCallToActionModifier {
        
        public override string modifier{ get { return "Tile_Secondary"; }}
    }

    /// <summary>
    /// Identifies a tile as a special call to action
    /// </summary>
    public class TileIsASpecialCallToAction
                    : TileCallToActionModifier {
        
        public override string modifier{ get { return "Tile_Special"; }}
    }
}
