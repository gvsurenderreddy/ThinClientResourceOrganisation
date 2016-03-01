using WorkSuite.Library.Persistence;

namespace WorkSuite.Configuration.Persistence.Domain.Configuration
{
    public class StaticContents
                 :BaseEntity <int>
    {
        public virtual string location_url { get; set; } 
    }
}