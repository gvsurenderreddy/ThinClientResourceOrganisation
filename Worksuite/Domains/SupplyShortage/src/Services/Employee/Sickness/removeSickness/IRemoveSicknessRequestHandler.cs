using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.SupplyShortage.Employee.Sickness.removeSickness
{
    public interface IRemoveSicknessRequestHandler : IServiceStatusResponseCommand<RemoveSicknessRequest
        , RemoveSicknessResponse> { }
}
