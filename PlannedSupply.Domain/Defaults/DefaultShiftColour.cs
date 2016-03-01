using WTS.WorkSuite.Library.DomainTypes.Colour;

namespace WTS.WorkSuite.PlannedSupply.Defaults
{
    public class DefaultShiftColour
    {
        public static RGBColourRequest create()
        {
            return new RGBColourRequest() {R=255,G=255,B=255};
        }
    }
}