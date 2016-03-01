using WorkSuite.Library.Persistence;

namespace WorkSuite.Configuration.Persistence.Domain.Configuration
{
    public class DatabaseSettings
                    :  BaseEntity<int> {

        public virtual string connection_string { get; set; }
    }
}