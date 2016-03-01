using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.ApplyFromTemplate
{
    public interface IGetApplyShiftBreaksFromBreakTemplateRequest : 
                        ICommand<ShiftOccurrenceIdentity, 
                                    Response<ApplyShiftBreaksFromBreakTemplateRequest>> { }
}