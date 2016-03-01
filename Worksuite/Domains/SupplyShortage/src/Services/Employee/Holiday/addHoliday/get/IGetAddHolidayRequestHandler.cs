using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.SupplyShortage.Employee.Holiday.addHoliday.get
{
    public interface IGetAddHolidayRequestHandler : IServiceStatusResponseCommand < GetAddHolidayRequest,
                                                                                    GetAddHolidayResponse
                                                                                  > { }
}
