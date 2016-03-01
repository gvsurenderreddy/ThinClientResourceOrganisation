using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.SupplyShortage.Employee.Sickness.addSickness.post
{
    public interface IAddSicknessRequestHandler : IServiceStatusResponseCommand< AddSicknessRequest
        , AddSicknessResponse > { }
}
