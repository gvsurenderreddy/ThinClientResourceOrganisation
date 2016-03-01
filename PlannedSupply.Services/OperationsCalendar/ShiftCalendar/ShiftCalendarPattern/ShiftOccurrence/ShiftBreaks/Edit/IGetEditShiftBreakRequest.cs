﻿using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.Edit
{
    public interface IGetEditShiftBreakRequest : ICommand<ShiftBreakIdentity, Response<EditShiftBreakRequest>>
    {
    }
}
