using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.Employees.Notes
{
    public class NoteBuilder : IEntityBuilder<Note>
    {
        public Note entity { get; private set; }

        public NoteBuilder(Note the_note)
        {
            Guard.IsNotNull(the_note, "the_note");

            var note_identity_provider = new IntIdentityProvider<Note>();

            entity = new Note
            {
                id = note_identity_provider.next(),
                Notes = "Testing",
               
            };
        }

        public NoteBuilder Notes(string value)
        {
            entity.Notes = value;
            return this;
        }
    }

}