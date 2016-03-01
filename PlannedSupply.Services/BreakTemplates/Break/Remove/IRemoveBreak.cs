﻿using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Remove
{
    public interface IRemoveBreak
                    : IResponseCommand<BreakIdentity,
                                       RemoveBreakResponse
                                      > { }
}