﻿using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Notes.New {

    public interface INewNote 
                        : IResponseCommand<NewNoteRequest, NewNoteResponse>{}
}