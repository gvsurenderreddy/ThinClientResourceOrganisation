using WorkSuite.Library.Persistence;

namespace WorkSuite.Library.Service.Specification.Helpers.Persistence {

    public class FakeUnitOfWork : IUnitOfWork {

        public void Commit ( ) {
            commit_was_called = true;
        }

        public bool commit_was_called { get; private set; }

    }

}