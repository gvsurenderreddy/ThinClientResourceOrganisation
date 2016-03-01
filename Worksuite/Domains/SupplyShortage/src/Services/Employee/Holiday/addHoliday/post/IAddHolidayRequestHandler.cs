using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.SupplyShortage.Employee.Holiday.addHoliday.post
{
    public interface IAddHolidayRequestHandler : IServiceStatusResponseCommand< AddHolidayRequest
                                                                              , AddHolidayResponse > { }
}
